use testdb
go

declare
  @InputParam int,
  @InputOutputParam int,
  @OutputParam int,
  @tmpStr varchar(1024)

set @InputParam=1
set @InputOutputParam=2
set @OutputParam=3

set @tmpStr='@InputParam='||convert(varchar(64),@InputParam)||', @InputOutputParam='||convert(varchar(64),@InputOutputParam)||', @OutputParam='||convert(varchar(64),@OutputParam)
print @tmpStr

exec sp_WithInputOutput @InputParam, @InputOutputParam output, @OutputParam output

set @tmpStr='@InputParam='||convert(varchar(64),@InputParam)||', @InputOutputParam='||convert(varchar(64),@InputOutputParam)||', @OutputParam='||convert(varchar(64),@OutputParam)
print @tmpStr
