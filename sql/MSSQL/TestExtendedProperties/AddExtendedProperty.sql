/* F. Adding an extended property to a table */
exec sys.sp_addextendedproperty
@name = N'MS_DescriptionExample',
@value = N'Extended property value for table dbo.TableWExtendedProperties',
@level0type = N'SCHEMA', @level0name = 'dbo',
@level1type = N'TABLE',  @level1name = 'TableWExtendedProperties';
go

/* B. Adding an extended property to a column in a table */
exec sys.sp_addextendedproperty
@name = N'Caption',
@value = N'Extended property value for column dbo.TableWExtendedProperties.FNVarchar',
@level0type = N'Schema', @level0name = 'dbo',
@level1type = N'Table',  @level1name = 'TableWExtendedProperties',
@level2type = N'Column', @level2name = 'FNVarchar';
go
