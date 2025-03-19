declare @tmpInt int;
declare @str nvarchar(100);

set @str = N'100';
set @tmpInt = try_parse(@str as int);
select @str, @tmpInt; /* '100' 100 */

set @str = N'abc';
set @tmpInt = try_parse(@str as int);
select @str, @tmpInt; /* '100' NULL */

select N'100', try_parse(N'100' as int), N'abc', try_parse(N'abc' as int);
