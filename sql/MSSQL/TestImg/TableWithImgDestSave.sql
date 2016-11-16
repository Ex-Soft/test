if object_id(N'TableWithImgDestSave', N'p') is not null
  drop procedure TableWithImgDestSave
go

create procedure TableWithImgDestSave
  @Id int,
  @Img [image]
as
begin
  set nocount on

  if exists (select
               1
             from
               TableWithImgDest
             where
               (Id=@Id))
    update
      TableWithImgDest
    set
      Img=@Img
    where
      (Id=@Id)
  else
    insert into TableWithImgDest (Img) values (@Img)
end
go