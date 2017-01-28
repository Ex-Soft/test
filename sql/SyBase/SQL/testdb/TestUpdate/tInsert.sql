create table tInsert
(
   Id numeric(18,0) identity,
   StatusId int not null
) lock datarows with identity_gap=10
go
