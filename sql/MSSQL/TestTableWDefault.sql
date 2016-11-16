if object_id('TestTableWDefault', 'u') is not null
	drop table TestTableWDefault
go

create table TestTableWDefault
(
	Id int identity,
	Val int,
	UsrName nvarchar(256),
	DtTm datetime
)
go

alter table TestTableWDefault alter column UsrName nvarchar(256) not null
go

alter table TestTableWDefault alter column DtTm datetime not null
go

alter table TestTableWDefault add constraint dfUsrName default user_name() for UsrName
go

alter table TestTableWDefault add constraint dfDtTm default getdate() for DtTm
go

if not exists (select 1 from syscolumns where id = object_id(N'TestTableWDefault', N'u') and name = N'UsrNameNullable')
	alter table TestTableWDefault add UsrNameNullable nvarchar(256) null constraint dfUsrNameNullable default user_name()
go

if not exists (select 1 from syscolumns where id = object_id(N'TestTableWDefault', N'u') and name = N'DtTmNullable')
	alter table TestTableWDefault add DtTmNullable datetime null constraint dfDtTmNullable default getdate()
go

select * from sys.objects where name like N'df%'
select * from sys.default_constraints

------------------------------------------------------------

insert into TestTableWDefault (Val) values (null)						-- UsrNameNullable == user_name()	dfDtTmNullable == getdate()
insert into TestTableWDefault (Val, UsrNameNullable) values (null, null)			-- UsrNameNullable == null		dfDtTmNullable == getdate()
insert into TestTableWDefault (Val, UsrNameNullable, DtTmNullable) values (null, null, null)	-- UsrNameNullable == null		dfDtTmNullable == null

------------------------------------------------------------

if object_id('tr_IUD_TestTableWDefault', 'tr') is not null
  drop trigger tr_IUD_TestTableWDefault
go

create trigger tr_IUD_TestTableWDefault
on TestTableWDefault
for insert, update, delete
as
begin

  set nocount on

  print 'tr_IUD_TestTableWDefault'

  declare
    @cnt int,
    @tmpStr varchar(255)

  select
    @cnt=count(*)
  from
    inserted
  set @tmpStr='inserted count(*)='+convert(varchar(255),@cnt)
  print @tmpStr

  select
    @cnt=count(*)
  from
    deleted
  set @tmpStr='deleted count(*)='+convert(varchar(255),@cnt)
  print @tmpStr

end
go
