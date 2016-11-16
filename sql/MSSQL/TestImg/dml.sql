declare
	@Path nvarchar(max)=N'D:\temp\images\',
	@ImageFileName nvarchar(max)=N'add.png'

update TableWithImgSrc set Img=null

exec(N'
	update
		TableWithImgSrc
	set
		Img=(select pic.* from openrowset(bulk '''+@Path+@ImageFileName+N''', single_blob) as pic)
	where
		id=1
	'
)

update TableWithImgSrc set ImgOut=dbo.PatchImage(Img, 100) where id=1