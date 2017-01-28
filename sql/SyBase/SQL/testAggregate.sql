select
  TT1.Id as TT1_Id,
  TT2.Id as TT2_Id,
  TT2.FInt as TT2_FInt
from
  TT1
  join TT2 on (TT2.TT1_Id=TT1.Id)
order by TT1.Id, TT2.Id

select
  TT1.Id as TT1_Id,
  sum(TT2.FInt) as SUM_TT2_FInt
from
  TT1
  join TT2 on (TT2.TT1_Id=TT1.Id)
group by
  TT1.Id
order by TT1.Id

select
  TT1.Id as TT1_Id,
  TT2.Id as TT2_Id,
  TT2.FInt as TT2_FInt,
  TT3.FInt as TT3_FInt
from
  TT1
  join TT2 on (TT2.TT1_Id=TT1.Id)
  join TT3 on (TT3.TT2_Id=TT2.Id)
order by TT1.Id, TT2.Id

select
  TT1.Id as TT1_Id,
  TT2.Id as TT2_Id,
  sum(TT3.FInt) as SUM_TT3_FInt,
  max(TT3.FDate) as MAX_TT3_FInt
from
  TT1
  join TT2 on (TT2.TT1_Id=TT1.Id)
  join TT3 on (TT3.TT2_Id=TT2.Id)
group by
  TT1.Id,
  TT2.Id,
  TT2.FInt /* !!! */
having
  (sum(TT3.FInt)>=TT2.FInt)
order by TT1.Id, TT2.Id