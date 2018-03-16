declare @t table
(
	id int not null primary key,
	fVarBinaryMaxNull varbinary(max) null,
	fVarBinaryMaxNotNull varbinary(max) not null
);

insert into @t (id, fVarBinaryMaxNull, fVarBinaryMaxNotNull) values (1, null, 0x);
insert into @t (id, fVarBinaryMaxNull, fVarBinaryMaxNotNull) values (2, 0x, 0x);
insert into @t (id, fVarBinaryMaxNull, fVarBinaryMaxNotNull) values (3, 0x656667686970, 0x656667686970);

declare
	@tmpStr nvarchar(max),
	@len int,
	@i int,
	@tmpChar nchar(1);

set @tmpStr = N'ABCDEF';

set @len = len(@tmpStr);
set @i = 1;
while @i <= @len
	begin
		set @tmpChar = substring(@tmpStr, @i, 1);
		print ascii(@tmpChar);
		set @i += 1;
	end;

insert into @t (id, fVarBinaryMaxNull, fVarBinaryMaxNotNull) values (4, convert(varbinary(max), @tmpStr), convert(varbinary(max), @tmpStr));
insert into @t (id, fVarBinaryMaxNull, fVarBinaryMaxNotNull) values (5, cast(@tmpStr as varbinary(max)), cast(@tmpStr as varbinary(max)));

set @tmpStr = N'ҐґЇїЄє';

set @len = len(@tmpStr);
set @i = 1;
while @i <= @len
	begin
		set @tmpChar = substring(@tmpStr, @i, 1);
		print ascii(@tmpChar);
		set @i += 1;
	end;

insert into @t (id, fVarBinaryMaxNull, fVarBinaryMaxNotNull) values (6, convert(varbinary(max), @tmpStr), convert(varbinary(max), @tmpStr));
insert into @t (id, fVarBinaryMaxNull, fVarBinaryMaxNotNull) values (7, cast(@tmpStr as varbinary(max)), cast(@tmpStr as varbinary(max)));

select
	datalength(fVarBinaryMaxNull) as [datalength(fVarBinaryMaxNull)],
	len(fVarBinaryMaxNull) as [len(fVarBinaryMaxNull)],
	datalength(fVarBinaryMaxNotNull) as [datalength(fVarBinaryMaxNotNull)],
	len(fVarBinaryMaxNotNull) as [len(fVarBinaryMaxNotNull)],
	*
from
	@t;

select @tmpStr = fVarBinaryMaxNotNull from @t where id = 3;

if @tmpStr is null
	print N'null'
else
	print '''' + @tmpStr + '''';

print len(@tmpStr);

set @len = len(@tmpStr);
set @i = 1;
while @i <= @len
	begin
		set @tmpChar = substring(@tmpStr, @i, 1);
		print ascii(@tmpChar);
		set @i += 1;
	end;

select @tmpStr = fVarBinaryMaxNotNull from @t where id = 4;

if @tmpStr is null
	print N'null'
else
	print '''' + @tmpStr + '''';

print len(@tmpStr);

set @len = len(@tmpStr);
set @i = 1;
while @i <= @len
	begin
		set @tmpChar = substring(@tmpStr, @i, 1);
		print ascii(@tmpChar);
		set @i += 1;
	end;

select @tmpStr = fVarBinaryMaxNotNull from @t where id = 6;

if @tmpStr is null
	print N'null'
else
	print '''' + @tmpStr + '''';

print len(@tmpStr);

set @len = len(@tmpStr);
set @i = 1;
while @i <= @len
	begin
		set @tmpChar = substring(@tmpStr, @i, 1);
		print ascii(@tmpChar);
		set @i += 1;
	end;
