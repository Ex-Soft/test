if object_id(N'TableWithImgSrc', N'u') is not null
	drop table TableWithImgSrc
go

create table TableWithImgSrc
(
	Id int identity,
	Img [image],
	ImgOut [image]
)
go