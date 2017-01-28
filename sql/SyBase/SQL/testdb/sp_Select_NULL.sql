use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('sp_Select_NULL')
            and    type = 'P')
   drop procedure sp_Select_NULL
go

create procedure sp_Select_NULL
  @IsSelectNull bit=0
as 
begin
  create table #tmpTable(
    Id int null,
    Name varchar(256) null)

  insert into #tmpTable (Name) values ('Иванов Иван Иванович')
  insert into #tmpTable (Name) values ('Петров Петр Петрович')
  insert into #tmpTable (Name) values ('Сидоров Сидор Сидорович')
  insert into #tmpTable (Name) values ('Александров Александр Александрович')

  if @IsSelectNull=1
    select Id, Name from #tmpTable
  else
    select Name from #tmpTable

  drop table #tmpTable
end
go
