declare @source table
(
	Id int identity not null,
	App nvarchar(50) null,
	Tenant int null,
	Domain int null,
	Culture [nvarchar](10) null,
	[Key] [nvarchar](50) not null
);

declare @target table
(
	Id int identity not null,
	App nvarchar(50) null,
	Tenant int null,
	Domain int null,
	Culture [nvarchar](10) null,
	[Key] [nvarchar](50) not null,
	[Value] [nvarchar](max) not null,
	Deleted bit not null default 0,
	Markdown bit not null default 0
);

insert into @source ([Key]) values (N'K1');
insert into @source ([Key], App) values (N'K1', N'DESKTOP');
insert into @source ([Key], App, Tenant) values (N'K1', N'DESKTOP', 3);
insert into @source ([Key], App, Tenant, Domain) values (N'K1', N'DESKTOP', 3, 122);
insert into @source ([Key], App, Tenant, Domain, Culture) values (N'K1', N'DESKTOP', 3, 122, N'se');
insert into @source ([Key]) values (N'K2');
insert into @source ([Key]) values (N'K3');

insert into @target ([Key], [Value], App, Tenant, Domain, Culture) values (N'K1', N'K1_V1', null, null, null, null);
insert into @target ([Key], [Value], App, Tenant, Domain, Culture) values (N'K1', N'K1_V2', N'DESKTOP', null, null, null);
insert into @target ([Key], [Value], App, Tenant, Domain, Culture) values (N'K1', N'K1_V3', N'DESKTOP', 3, null, null);
insert into @target ([Key], [Value], App, Tenant, Domain, Culture) values (N'K1', N'K1_V4', N'DESKTOP', 3, 122, null);
insert into @target ([Key], [Value], App, Tenant, Domain, Culture) values (N'K1', N'K1_V5', N'DESKTOP', 3, 122, N'se');

insert into @target ([Key], [Value], App, Tenant, Domain, Culture) values (N'K2', N'K2_V1', null, null, null, null);
insert into @target ([Key], [Value], App, Tenant, Domain, Culture) values (N'K2', N'K2_V2', N'DESKTOP', null, null, null);
insert into @target ([Key], [Value], App, Tenant, Domain, Culture) values (N'K2', N'K2_V3', N'DESKTOP', 3, null, null);
insert into @target ([Key], [Value], App, Tenant, Domain, Culture) values (N'K2', N'K2_V4', N'DESKTOP', 3, 122, null);

select
	*
from
	@source src
	cross apply
	(
		select top 1
			Id, App, Tenant, Domain, Culture, [Key], [Value], Markdown
		from
		(
			select top 1000
				Id, App, Tenant, Domain, Culture, [Key], [Value], Markdown
			from
				@target tgt
			where
				tgt.[Key] = src.[Key] and tgt.Deleted = 0
			order by Culture desc, App desc, Tenant desc, Domain desc
		) tmp
		where
			(Culture = src.Culture or (Culture is null))
			and (App = src.App or (App is null))
			and (Tenant = src.Tenant or (Tenant is null))
			and (Domain = src.Domain or (Domain is null))
	) tmpTmp

