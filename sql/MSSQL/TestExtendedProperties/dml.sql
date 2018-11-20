select
	schema_name(tbl.schema_id) as SchemaName,
	tbl.name as TableName,
	ex_prop.name as  ExtendedPropertyName,
	cast(ex_prop.value as sql_variant) as ExtendedPropertyValue
from
	 sys.tables tbl
	 join sys.extended_properties ex_prop on ex_prop.major_id = tbl.object_id and ex_prop.minor_id = 0;

select
	schema_name(tbl.schema_id) as SchemaName,
	tbl.name as TableName,
	col.name as ColumnName,
	ex_prop.name as  ExtendedPropertyName,
	cast(ex_prop.value as sql_variant) as ExtendedPropertyValue
from
	 sys.tables tbl
	 join sys.all_columns col on col.object_id = tbl.object_id
	 join sys.extended_properties ex_prop on ex_prop.major_id = tbl.object_id and ex_prop.minor_id = col.column_id and ex_prop.class = 1;

select
	*
from
	::fn_listextendedproperty(N'Caption', N'Schema', N'dbo', N'Table', N'TableWExtendedProperties', N'Column', N'FNVarChar');

select
	*
from
	 sys.tables;

select
	*
from
	sys.all_columns;

select
	*
from
	 sys.extended_properties;
