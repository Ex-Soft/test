use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('TestDefault')
            and    type = 'U')
   drop table TestDefault
go

create table TestDefault
(
   Id int identity,
   DateBeginWODefault date not null,
   DateEndWODefault date not null,
   DateBeginWDefault date default '00010101' not null,
   DateEndWDefault date default '99991231' not null
) lock datarows with identity_gap=10
go

exec sp_bindefault 'DATE_MIN', 'TestDefault.DateBeginWODefault'
exec sp_bindefault 'DATE_MAX', 'TestDefault.DateEndWODefault'
go