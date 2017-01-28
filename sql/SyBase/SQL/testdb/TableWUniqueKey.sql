use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('TableWUniqueKey')
            and    type = 'U')
   drop table TableWUniqueKey
go

create table TableWUniqueKey
(
   Id numeric(18,0) not null,
   Value varchar(254)
) lock datarows
go

if not exists(select 1
              from
                sysindexes i,
                sysobjects o
              where
                (o.id=i.id)
                and (upper(ltrim(rtrim(i.name)))='TableWUniqueKeyId'))
  create unique index TableWUniqueKeyId on TableWUniqueKey(Id)
else
  print 'TableWUniqueKey.TableWUniqueKeyId already exists!!!'
go