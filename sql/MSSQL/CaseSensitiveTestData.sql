insert into CaseSensitiveTest (Val) values ('TEST')
insert into CaseSensitiveTest (Val) values ('test')
insert into CaseSensitiveTest (Val) values ('Test')
insert into CaseSensitiveTest (Val) values ('TEST1')
insert into CaseSensitiveTest (Val) values ('test1')
insert into CaseSensitiveTest (Val) values ('Test1')
insert into CaseSensitiveTest (Val) values ('123Test')
go

select serverproperty('Collation')
go

sp_helpsort
go

select
  *
from
  CaseSensitiveTest
where
  Val='test' collate Cyrillic_General_CI_AS
  
select
  *
from
  CaseSensitiveTest
where
  Val like '%Test%' collate Cyrillic_General_CI_AS

select
  *
from
  CaseSensitiveTest
where
  cast(Val as varbinary) = cast('test' as varbinary)

select
  *
from
  CaseSensitiveTest
where
  cast(Val as varbinary) like cast('%Test%' as varbinary)

