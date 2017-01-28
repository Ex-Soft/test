use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('sp_AnyTest')
            and    type = 'P')
   drop procedure sp_AnyTest
go

create procedure sp_AnyTest
with recompile
as 
begin
  declare
    @tmpInt int,
    @tmpString varchar(1024)

  set @tmpInt=3

  if (@tmpInt & 0x2) = 0x2
    begin
      set @tmpString='(@tmpInt & 0x2) = 0x2'
      print @tmpString

      if not exists (select 1
                     from
                       sysobjects
                     where
                       id=object_id('TableAnyTest')
                       and type='U')
        create table TableAnyTest (
          Id numeric(18) identity,
          Name varchar(256) null,
          constraint pkTableAnyTest primary key (Id)
        )
      else
        delete from TableAnyTest

      insert into TableAnyTest (Name) values ('������ ���� ��������')
      insert into TableAnyTest (Name) values ('������ ���� ��������')
      insert into TableAnyTest (Name) values ('������� ����� ���������')
      insert into TableAnyTest (Name) values ('�������� ������� ����������')
    end
end
go
