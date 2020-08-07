
CREATE PROCEDURE [dbo].[sp_ImportImages4GoodsFromXls]
	@FileName				nvarchar(1000)
	,@Path					nvarchar(1000)
	,@idDistributor			bigint
	,@idPhysicalPerson		bigint
	,@guid					nvarchar(50)
AS
BEGIN

-------------DEBUG---------------------------------------
--declare
--	@FileName nvarchar(1000)=N'd:\temp\15450\ImportImagesFromXls.xlsx'
--	,@Path nvarchar(1000)=N'd:\temp\images'
--	,@idDistributor bigint=281474976711134
--	,@idPhysicalPerson bigint=562954261371445
--	,@guid nvarchar(50)=newid()
---------------------------------------------------

SET NOCOUNT ON

DECLARE
	@idSession nvarchar(10)=CONVERT(nvarchar(10), @@SPID)

----------Таблица отчета об Результатах------------
IF OBJECT_ID(N'tempdb..#importReport') IS NOT NULL
	DROP TABLE #importReport

CREATE TABLE #importReport(
	[Причина/Ошибка] [nvarchar](2000) NULL,
	[Номер строки] [bigint] NULL,
	[Код] [nvarchar](2000) NULL,
	[Имя файла] [nvarchar](2000) NULL
)

----------Таблица для содержимого файла------------
IF OBJECT_ID(N'tempdb..#importTmpData') IS NOT NULL
	DROP TABLE #importTmpData

CREATE TABLE #importTmpData(
	[idRow] [bigint] primary key NOT NULL,
	[outercode] [nvarchar](50) NULL,
	[ImageFileName] [nvarchar](35) NULL
)

set @FileName=ltrim(rtrim(isnull(@FileName, N'')))
IF @FileName=N''
BEGIN
	INSERT #importReport([Причина/Ошибка]) VALUES (N'Не выбран файл')
	GOTO RETURN_POINT
END

set @Path=ltrim(rtrim(isnull(@Path, N'')))
IF @Path=N''
BEGIN
	INSERT #importReport([Причина/Ошибка]) VALUES (N'Не выбран путь к каталогу хранения изображений')
	GOTO RETURN_POINT
END
if right(@Path, 1)!=N'\'
	set @Path+=N'\'

if (@idDistributor is null) or (@idDistributor=0)
	select
		@idDistributor=id
	from
		dbo.refDistributors
	where
		(IsRoot=1)
		and (deleted=0)

---Получаем содержимое файла Excel------------
DECLARE
	@result int,
	@OriginalXlsData varchar(30)=N'_Images_'+@idSession

BEGIN TRY
exec @result = dbo.sp_ReadExcel
   @isFirstRowColumnNames=1
 , @FileName=@FileName
 , @SQLTableName=@OriginalXlsData
 , @SheetName=N''
 , @ColumnCount=0
END TRY
BEGIN CATCH
	INSERT #importReport([Причина/Ошибка]) VALUES (N'Ошибка чтения файла. ' + ERROR_MESSAGE())
	GOTO RETURN_POINT
END CATCH

if object_id(@OriginalXlsData, N'u') is null
begin
	insert #importReport([Причина/Ошибка]) values (N'Отсутствует временная таблица для импорта')
	goto return_point
end

if not exists(select 1 from sys.columns where name=N'Код' and object_id=object_id(@OriginalXlsData, N'u'))
begin
	insert #importReport([Причина/Ошибка]) values (N'Поле [Код] не существует или названо неправильно')
	goto return_point
end

if not exists(select 1 from sys.columns where name=N'Имя файла' and object_id=object_id(@OriginalXlsData, N'u'))
begin
	insert #importReport([Причина/Ошибка]) values (N'Поле [Имя файла] не существует или названо неправильно')
	goto return_point
end

BEGIN TRY
exec(N'
IF NOT EXISTS(select 1 from '+@OriginalXlsData+N')
	RAISERROR(N''Отсутствуют данные для импорта'', 16, 1);
'
)
END TRY
BEGIN CATCH
	INSERT #importReport([Причина/Ошибка]) VALUES (ERROR_MESSAGE())
	GOTO RETURN_POINT
END CATCH

exec(N'
INSERT #importTmpData([idRow], [outercode], [ImageFileName])
SELECT
	[idRow]
	, left(ltrim(rtrim(isnull([Код], N''''))), 50) as [outercode]
	, left(ltrim(rtrim(isnull([Имя файла], N''''))), 35) as [ImageFileName]
FROM '+@OriginalXlsData
)

exec(N'drop table '+@OriginalXlsData)

-- Удаляем дубли
;with cte
as
(
	select
		row_number() over (partition by outercode, ImageFileName order by idRow) as rn
	from
		#importTmpData
)
delete from cte
where rn>1;

if object_id(N'tempdb..#tImage', N'u') is not null
	drop table #tImage

create table #tImage(
	id int,
	ImageBody image
)

insert into #tImage (id) values (1)

declare
	@idRow bigint,
	@outercode nvarchar(50),
	@ImageFileName nvarchar(35),
	@idGoods bigint,
	@HtmlBody nvarchar(max),
	@signature nvarchar(max),
	@posBegin bigint,
	@posEnd bigint

declare CursorImportTmpData cursor for
select
	idRow,
	outercode,
	ImageFileName
from
	#importTmpData
for read only

open CursorImportTmpData
fetch from CursorImportTmpData into @idRow, @outercode, @ImageFileName
while @@fetch_status=0
begin
	set @idGoods=null
	set @HtmlBody=null

	select
		@idGoods=g.id,
		@HtmlBody=g.HtmlBody
	from
		dbo.refOutercodes oc
		join dbo.refGoods g on (g.id=oc.idItem)
	where
		(oc.outercode=@outercode)
		and (oc.TableName=N'refGoods')
		and (oc.idDistr=@idDistributor)

	if @idGoods is null
		begin
			insert #importReport([Причина/Ошибка], [Номер строки], [Код], [Имя файла]) VALUES (N'[Код]='''+@outercode+N''' не найден. Строка не импортирована.', @idRow+1, @outercode, @ImageFileName)
			goto nextData
		end

	if isnull(@HtmlBody, N'')=N''
		set @HtmlBody=N'<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">'+char(13)+char(10)+N'<HTML><HEAD>'+char(13)+char(10)+N'<META content="text/html; charset=windows-1251" http-equiv=Content-Type>'+char(13)+char(10)+N'<META name=GENERATOR content="MSHTML 10.00.9200.16660"></HEAD>'+char(13)+char(10)+N'<BODY contentEditable=true>'+char(13)+char(10)+N'<P><IMG '+char(13)+char(10)+N'src="'+@ImageFileName+N'"></P></BODY></HTML>'+char(13)+char(10)
	else
		begin
			set @signature=N'%<IMG '+char(13)+char(10)+N'src="%'
			set @posBegin=patindex(@signature, @HtmlBody)
			if @posBegin=0
				begin
					set @signature=N'%<IMG src="%'
					set @posBegin=patindex(@signature, @HtmlBody)
				end
			if @posBegin!=0
				begin
					set @posBegin+=len(@signature)-3
					set @posEnd=charindex(N'"', @HtmlBody, @posBegin+1)
					set @HtmlBody=substring(@HtmlBody, 1, @posBegin)+@ImageFileName+substring(@HtmlBody, @posEnd, len(@HtmlBody)-@posEnd+1)
				end
			else
				begin
					set @signature=N'%</BODY>%'
					set @posBegin=patindex(@signature, @HtmlBody)
					set @HtmlBody=substring(@HtmlBody, 1, @posBegin-1)+N'<P><IMG '+char(13)+char(10)+N'src="'+@ImageFileName+N'"></P>'+substring(@HtmlBody, @posBegin, len(@HtmlBody)-@posBegin-1)
				end
		end

	update #tImage set ImageBody=null where id=1

	begin try
		exec(N'
			update
				#tImage
			set
				ImageBody=(select pic.* from openrowset(bulk '''+@Path+@ImageFileName+N''', single_blob) as pic)
			where
				id=1
		')
	end try
	begin catch
		insert #importReport([Причина/Ошибка], [Номер строки], [Код], [Имя файла]) values (error_message(), @idRow+1, @outercode, @ImageFileName)
		goto nextData
	end catch

	update
		dbo.refGoods
	set
		HtmlBody=@HtmlBody,
		HtmlCRC=dbo.fn_getStringCRC(@HtmlBody),
		ImageFileName=@ImageFileName,
		ImageBody=(select ImageBody from #tImage where id=1),
		ImageCRC=(select dbo.fn_getBinaryCRC(ImageBody) from #tImage where id=1)
	where
		id=@idGoods

	nextData:
	fetch from CursorImportTmpData into @idRow, @outercode, @ImageFileName
end
close CursorImportTmpData
deallocate CursorImportTmpData

drop table #tImage

RETURN_POINT:

if object_id(@OriginalXlsData, N'u') is not null
	exec(N'drop table '+@OriginalXlsData)

drop table #importTmpData

if not exists(select 1 from #importReport)
	insert #importReport([Причина/Ошибка]) values (N'Импорт успешно произведен')

select * from #importReport

drop table #importReport

END
