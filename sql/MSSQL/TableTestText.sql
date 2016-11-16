if object_id(N'TableTestText', N'u') is not null
  drop table TableTestText
go

create table TableTestText
(
   Id bigint identity,
   FText text,
   FNText ntext,
   FImage image
)
go

insert into TableTestText (FNText) values (null)

declare
  @ptrval binary(16)

/*
update
  TableTestText
set
  FNText='blah-blah-blah'
where
  Id=1
*/
  
select
  @ptrval=textptr(FNText)
from
  TableTestText
where
  Id=1

updatetext TableTestText.FNText @ptrval null null 'halb-halb-halb'

select
  *
from
  TableTestText