declare
	@a bit,
	@b bit,
	@c bit,
	@d bit,
	@tmpStr nvarchar(255)

print N'A and B or C = (A and B) or C'
print N'-----------------------------'

set @a=0
set @b=0
set @c=0
set @tmpStr = convert(nvarchar(1),@a) + N' and '+convert(nvarchar(1),@b) + N' or ' +convert(nvarchar(1),@c)
if @a=1 and @b=1 or @c=1
  set @tmpStr=@tmpStr+' = true'
else
  set @tmpStr=@tmpStr+' = false' -- FALSE
print @tmpStr

set @a=0
set @b=0
set @c=1
set @tmpStr = convert(nvarchar(1),@a) + N' and '+convert(nvarchar(1),@b) + N' or ' +convert(nvarchar(1),@c)
if @a=1 and @b=1 or @c=1
  set @tmpStr=@tmpStr+' = true' -- TRUE
else
  set @tmpStr=@tmpStr+' = false'
print @tmpStr

set @a=0
set @b=1
set @c=0
set @tmpStr = convert(nvarchar(1),@a) + N' and '+convert(nvarchar(1),@b) + N' or ' +convert(nvarchar(1),@c)
if @a=1 and @b=1 or @c=1
  set @tmpStr=@tmpStr+' = true'
else
  set @tmpStr=@tmpStr+' = false' -- FALSE
print @tmpStr

set @a=0
set @b=1
set @c=1
set @tmpStr = convert(nvarchar(1),@a) + N' and '+convert(nvarchar(1),@b) + N' or ' +convert(nvarchar(1),@c)
if @a=1 and @b=1 or @c=1
  set @tmpStr=@tmpStr+' = true' -- TRUE
else
  set @tmpStr=@tmpStr+' = false'
print @tmpStr

set @a=1
set @b=0
set @c=0
set @tmpStr = convert(nvarchar(1),@a) + N' and '+convert(nvarchar(1),@b) + N' or ' +convert(nvarchar(1),@c)
if @a=1 and @b=1 or @c=1
  set @tmpStr=@tmpStr+' = true'
else
  set @tmpStr=@tmpStr+' = false' -- FALSE
print @tmpStr

set @a=1
set @b=0
set @c=1
set @tmpStr = convert(nvarchar(1),@a) + N' and '+convert(nvarchar(1),@b) + N' or ' +convert(nvarchar(1),@c)
if @a=1 and @b=1 or @c=1
  set @tmpStr=@tmpStr+' = true' -- TRUE
else
  set @tmpStr=@tmpStr+' = false'
print @tmpStr

set @a=1
set @b=1
set @c=0
set @tmpStr = convert(nvarchar(1),@a) + N' and '+convert(nvarchar(1),@b) + N' or ' +convert(nvarchar(1),@c)
if @a=1 and @b=1 or @c=1
  set @tmpStr=@tmpStr+' = true' -- TRUE
else
  set @tmpStr=@tmpStr+' = false'
print @tmpStr

set @a=1
set @b=1
set @c=1
set @tmpStr = convert(nvarchar(1),@a) + N' and '+convert(nvarchar(1),@b) + N' or ' +convert(nvarchar(1),@c)
if @a=1 and @b=1 or @c=1
  set @tmpStr=@tmpStr+' = true' -- TRUE
else
  set @tmpStr=@tmpStr+' = false'
print @tmpStr

print N'-----------------------------'

set @a = 1
set @b = 0
set @c = 1
set @d = 1
set @tmpStr = convert(nvarchar(1), @a) + N' and not ' + convert(nvarchar(1), @b) + N' and ' + convert(nvarchar(1), @c) + N' and ' + convert(nvarchar(1), @d)
if (@a=1) and not (@b=1) and (@c=1) and (@d=1)
	set @tmpStr = @tmpStr + ' = true' -- TRUE
else
	set @tmpStr = @tmpStr + ' = false'
print @tmpStr

------------------------------------------------------------

/*

case when ((N2."deleted" = 0) and (N2."idChief" <> 0) and (N2."idChief" = N1."id")) then 1 else 0 end = 1

select top 1
	count(*)
from
	"dbo"."refPhysicalPersons" N0 with (nolock)
where
(
	(N0."id" <> @p0)
	and (N0."deleted" = @p1)
	and
	(
		(
			N0."idDistributor" in (@p2,@p3)
			and not (exists(
					select
						*
					from
						("dbo"."refEmployeesPositions" N1 left join "dbo"."refPositions" N2 on (N1."idPosition" = N2."id"))
					where
					(
						(N0."id" = N1."idEmployee")
						and (N2."deleted" = 0)
						and (N1."deleted" = 0)
						and (case when ((N2."deleted" = 0) and (N2."idChief" <> 0) and (N2."idChief" = N1."id")) then 1 else 0 end = 1)
					)
			))
		)
		or
			exists(
				select
					*
				from
					("dbo"."refEmployeesPositions" N3 left join "dbo"."refPositions" N4 on (N3."idPosition" = N4."id"))
				where
				(
					(N0."id" = N3."idEmployee")
					and N4."idDistributor" in (@p2,@p3)
					and (N3."deleted" = 0)
					and (case when ((N4."deleted" = 0) and (N4."idChief" <> 0) and (N4."idChief" = N3."id")) then 1 else 0 end = 1)
				)
			)
	)
)

*/