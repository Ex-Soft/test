declare @t table (N_15_6 numeric(15,6))
insert into @t (N_15_6) values (123456789.012345)
insert into @t (N_15_6) values (123456789.0123456)
insert into @t (N_15_6) values (123456789.01234567)
--insert into @t (N_15_6) values (1234567890.123456) -- Arithmetic overflow error converting numeric to data type numeric.
select * from @t