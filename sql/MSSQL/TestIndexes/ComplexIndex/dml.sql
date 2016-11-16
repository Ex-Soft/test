declare
	@idSmthII_1 int = 1,
	@FieldI nvarchar(50) = N'TableName'

select
	N0."id",N0."idSmthI",N1."FieldI",N0."FieldI",N0."FieldII",N0."idSmthII",N0."FieldIII",N0."FieldIV"
from
(
	"dbo"."TestTableWithIndexes4LockI" N0 with (nolock)
	left join "dbo"."TestTableWithIndexes4LockII" N1 with (nolock) on (N0."idSmthI" = N1."id")
)
where
(
	N0."idSmthII" in (@idSmthII_1)
	and (N0."FieldI" = @FieldI)
)