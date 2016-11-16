if object_id(N'TableWithImgDest', N'u') is not null
  drop table TableWithImgDest
go

create table TableWithImgDest
(
   Id int identity,
   Img [image]
)
go