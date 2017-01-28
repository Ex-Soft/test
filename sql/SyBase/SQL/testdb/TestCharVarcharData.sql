use testdb
go

delete from TestCharVarchar
go

insert into TestCharVarchar (Id, FChar, FVarchar) values (1,'A','A')
insert into TestCharVarchar (Id, FChar, FVarchar) values (2,'B','B')
insert into TestCharVarchar (Id, FChar, FVarchar) values (3,'C','C')
go

select
  FChar,
  char_length(FChar)
from
  TestCharVarchar
where
  FChar='B'

select
  FVarchar,
  char_length(FVarchar)
from
  TestCharVarchar
where
  FVarchar='A'
