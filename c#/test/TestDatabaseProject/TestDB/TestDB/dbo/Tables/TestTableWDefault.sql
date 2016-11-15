CREATE TABLE [dbo].[TestTableWDefault] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Val]             INT            NULL,
    [UsrName]         NVARCHAR (256) CONSTRAINT [dfUsrName] DEFAULT (user_name()) NOT NULL,
    [DtTm]            DATETIME       CONSTRAINT [dfDtTm] DEFAULT (getdate()) NOT NULL,
    [UsrNameNullable] NVARCHAR (256) CONSTRAINT [dfUsrNameNullable] DEFAULT (user_name()) NULL,
    [DtTmNullable]    DATETIME       CONSTRAINT [dfDtTmNullable] DEFAULT (getdate()) NULL
);


GO

create trigger tr_IUD_TestTableWDefault
on TestTableWDefault
for insert, update, delete
as
begin

  set nocount on

  print 'tr_IUD_TestTableWDefault'

  declare
    @cnt int,
    @tmpStr varchar(255)

  select
    @cnt=count(*)
  from
    inserted
  set @tmpStr='inserted count(*)='+convert(varchar(255),@cnt)
  print @tmpStr

  select
    @cnt=count(*)
  from
    deleted
  set @tmpStr='deleted count(*)='+convert(varchar(255),@cnt)
  print @tmpStr

end
