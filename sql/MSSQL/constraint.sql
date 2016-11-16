
select * from sys.objects where name = N'FK_refAttributesValues_refRoutes'

 select object_id(N'FK_refAttributesValues_refRoutes', N'f')

if not exists(select 1 from INFORMATION_SCHEMA.TABLE_CONSTRAINTS where TABLE_SCHEMA = N'dbo' and TABLE_NAME = N'refAttributesValues' and CONSTRAINT_TYPE = N'FOREIGN KEY' and CONSTRAINT_NAME = N'FK_refAttributesValues_refRoutes')
		ALTER TABLE [dbo].[refAttributesValues] WITH NOCHECK ADD CONSTRAINT [FK_refAttributesValues_refRoutes] FOREIGN KEY([idElement])
		REFERENCES [dbo].[refRoutes] ([id])
		NOT FOR REPLICATION
