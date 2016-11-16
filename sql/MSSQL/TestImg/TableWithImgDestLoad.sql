if object_id(N'TableWithImgDestLoad', N'p') is not null
  drop procedure TableWithImgDestLoad
go

create procedure TableWithImgDestLoad
  @Id int
as
begin
  set nocount on

  select
    *
  from
    TableWithImgDest
  where
    Id=@Id
end
go