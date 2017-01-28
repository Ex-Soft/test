use testdb
go

if exists (select 1
            from  sysobjects
            where  id = object_id('vDoc')
            and    type = 'V')
   drop view vDoc
go

create view vDoc
as
select
  D.Id,
  D.DocNo,
  D.DocSeries,
  D.DocSeries||(case when (D.DocSeries is not null) and (D.DocNo is not null) then ' ' end)||(case when D.DocNo is not null then 'N ' end)||D.DocNo as DocFullByStd,
  D.DocSeries+(case when (D.DocSeries is not null) and (D.DocNo is not null) then ' ' end)+(case when D.DocNo is not null then 'N ' end)+D.DocNo as DocFullByPlus
from
  Doc D
go