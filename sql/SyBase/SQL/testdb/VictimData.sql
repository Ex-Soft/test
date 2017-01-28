declare
  @Id int,
  @Val int

set @Id=1
set @Val=@Id
if not exists (select Id from Victim where Id=@Id)
  insert into Victim (Id, Val) values (@Id,@Val)

set @Id=2
set @Val=@Id
if not exists (select Id from Victim where Id=@Id)
  insert into Victim (Id, Val) values (@Id,@Val)

set @Id=3
set @Val=@Id
if not exists (select Id from Victim where Id=@Id)
  insert into Victim (Id, Val) values (@Id,@Val)

set @Id=4
set @Val=@Id
if not exists (select Id from Victim where Id=@Id)
  insert into Victim (Id, Val) values (@Id,@Val)

set @Id=5
set @Val=@Id
if not exists (select Id from Victim where Id=@Id)
  insert into Victim (Id, Val) values (@Id,@Val)
go
