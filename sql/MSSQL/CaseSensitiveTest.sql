select serverproperty('Collation')

exec sp_helpsort

select * from fn_helpcollations();

declare @CaseSensitiveTest table(id numeric(18,0) not null identity, Val varchar(255))

insert into @CaseSensitiveTest (Val) values ('TEST')
insert into @CaseSensitiveTest (Val) values ('test')
insert into @CaseSensitiveTest (Val) values ('Test')
insert into @CaseSensitiveTest (Val) values ('TEST1')
insert into @CaseSensitiveTest (Val) values ('test1')
insert into @CaseSensitiveTest (Val) values ('Test1')
insert into @CaseSensitiveTest (Val) values ('123Test')

select * from @CaseSensitiveTest where Val='test' collate Cyrillic_General_CI_AS
select * from @CaseSensitiveTest where Val='test' collate Cyrillic_General_CS_AS

select * from @CaseSensitiveTest where Val like '%Test%' collate Cyrillic_General_CI_AS
select * from @CaseSensitiveTest where Val like '%Test%' collate Cyrillic_General_CS_AS

select * from @CaseSensitiveTest where cast(Val as varbinary) = cast('test' as varbinary)
select * from @CaseSensitiveTest where cast(Val as varbinary) like cast('%Test%' as varbinary)
