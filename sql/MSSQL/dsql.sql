-- http://www.sommarskog.se/dynamic_sql.html
-- http://support.microsoft.com/kb/262499
-- http://www.simple-talk.com/sql/learn-sql-server/pop-rivetts-sql-server-faq/

declare
  @a bigint,
  @cmd nvarchar(max),
  @prm nvarchar(max),
  @isExist bit,
  @name nvarchar(255),
  @result int,
  @id int

declare
  @t table(id bigint)

/*
set @a=999
set @cmd=N'select @a = id from Staff where (Name = N''Хрущев Никита Сергеевич'')'
execute (@cmd) -- Error: Must declare the scalar variable "@a".
select @a -- 999
*/

set @cmd = N'select @fInt, @fBit from Victim where id = @id'
set @prm = N'@fInt int, @fBit int, @id bigint'
insert into Victim (f_Int, f_Bit) exec sp_executesql @cmd, @prm, @fInt = 2, @fBit = 1, @id = 1
select * from Victim

set @cmd=N'select @aout = id from Staff where (Name = N''Хрущев Никита Сергеевич'')'
set @prm=N'@aout bigint output'
exec sp_executesql @cmd, @prm, @aout=@a output
select @a

set @cmd=N'select @aout = id from Staff where (Name = @name)'
set @prm=N'@aout bigint output, @name nvarchar(255)'
set @name = N'Вашингтон Джордж'
exec @result = sp_executesql @cmd, @prm, @aout=@a output, @name=@name
select @a as [Id], @result as [RETURN_VALUE]

set @cmd=N'select * from Staff where (Name = N''Хрущев Никита Сергеевич'')'
execute (@cmd)

set @cmd=N'select id from Staff where (dep=@dep)'
set @prm=N'@dep int'
insert into @t exec sp_executesql @cmd, @prm, @dep=1
select * from @t

set @cmd=N'select Name from Staff'
exec(@cmd) -- oB!

/*
set @cmd=N'select UnknownField from Staff'
exec(@cmd) -- Error: Invalid column name 'UnknownField'
*/

set @cmd=N'
if exists(select 1 from sys.columns where name=N''Name'' and object_id=object_id(N''Staff'', N''U''))
	set @isExistOut=1
else
	set @isExistOut=0
'
set @prm=N'@isExistOut bit output'
exec sp_executesql @cmd, @prm, @isExistOut=@isExist output
select @isExist

set @cmd=N'
if exists(select 1 from sys.columns where name=N''UnknownField'' and object_id=object_id(N''Staff'', N''U''))
	set @isExistOut=1
else
	set @isExistOut=0
'
exec sp_executesql @cmd, @prm, @isExistOut=@isExist output
select @isExist

set @cmd=N'
set @idOut = dbo.TestFunctionReturnOnly(1, 2)
'
set @prm=N'@idOut int output'
exec sp_executesql @cmd, @prm, @idOut=@id output
select @id
