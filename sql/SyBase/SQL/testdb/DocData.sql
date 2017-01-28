use testdb
go

insert into Doc (Id, DocNo, DocSeries) values (1, '1', 'A')
insert into Doc (Id, DocNo, DocSeries) values (2, '2', 'A')
insert into Doc (Id, DocNo, DocSeries) values (3, '3', 'A')

insert into Doc (Id, DocNo, DocSeries) values (4, '1', null)
insert into Doc (Id, DocNo, DocSeries) values (5, '2', null)
insert into Doc (Id, DocNo, DocSeries) values (6, '3', null)

insert into Doc (Id, DocNo, DocSeries) values (7, null, 'B')
insert into Doc (Id, DocNo, DocSeries) values (8, null, 'B')
insert into Doc (Id, DocNo, DocSeries) values (9, null, 'B')
go
