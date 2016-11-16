set nocount on

declare @t table (id int, val nvarchar(254))

insert into @t (id, val) values (1, N'10')
insert into @t (id, val) values (1, N'11')
insert into @t (id, val) values (1, N'12')
insert into @t (id, val) values (2, N'20')
insert into @t (id, val) values (2, N'21')
insert into @t (id, val) values (2, N'22')
insert into @t (id, val) values (3, N'30')
insert into @t (id, val) values (3, N'31')
insert into @t (id, val) values (3, N'32')

declare
	@cnt int,
	@i int,
	@PhotoFiles nvarchar(max)

select @cnt = count(distinct id) from @t
set @i = 1

while @i <= @cnt
	begin
		set @PhotoFiles = N''
		
		declare @dt table (val nvarchar(254))
		
		insert into @dt
			(val)
		select
			val
		from
			@t
		where
			id = @i

		select
			 @PhotoFiles = @PhotoFiles + case when @PhotoFiles = N'' then N'' else ';' end + val
		from
			@dt

		print @i
		print @PhotoFiles

		set @i = @i +1
	end