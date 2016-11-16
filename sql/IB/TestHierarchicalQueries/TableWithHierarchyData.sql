execute ibeblock
as
begin
insert into TableWithHierarchy (Id, ParentId, Val) values (1, null, '1');
insert into TableWithHierarchy (Id, ParentId, Val) values (2, 1, '1.1');
insert into TableWithHierarchy (Id, ParentId, Val) values (3, 1, '1.2');
insert into TableWithHierarchy (Id, ParentId, Val) values (4, 1, '1.3');

insert into TableWithHierarchy (Id, ParentId, Val) values (5, null, '2');
insert into TableWithHierarchy (Id, ParentId, Val) values (6, 5, '2.1');
insert into TableWithHierarchy (Id, ParentId, Val) values (7, 5, '2.2');
insert into TableWithHierarchy (Id, ParentId, Val) values (8, 5, '2.3');

insert into TableWithHierarchy (Id, ParentId, Val) values (9, 2, '1.1.1');
insert into TableWithHierarchy (Id, ParentId, Val) values (10, 2, '1.1.2');
insert into TableWithHierarchy (Id, ParentId, Val) values (11, 2, '1.1.3');

insert into TableWithHierarchy (Id, ParentId, Val) values (12, 9, '1.1.1.1');
insert into TableWithHierarchy (Id, ParentId, Val) values (13, 9, '1.1.1.2');
insert into TableWithHierarchy (Id, ParentId, Val) values (14, 9, '1.1.1.3');

insert into TableWithHierarchy (Id, ParentId, Val) values (15, 3, '1.2.1');
insert into TableWithHierarchy (Id, ParentId, Val) values (16, 3, '1.2.2');
insert into TableWithHierarchy (Id, ParentId, Val) values (17, 3, '1.2.3');

insert into TableWithHierarchy (Id, ParentId, Val) values (18, 15, '1.2.1.1');
insert into TableWithHierarchy (Id, ParentId, Val) values (19, 15, '1.2.1.2');
insert into TableWithHierarchy (Id, ParentId, Val) values (20, 15, '1.2.1.3');

insert into TableWithHierarchy (Id, ParentId, Val) values (21, 10, '1.1.2.1');
insert into TableWithHierarchy (Id, ParentId, Val) values (22, 10, '1.1.2.2');
insert into TableWithHierarchy (Id, ParentId, Val) values (23, 10, '1.1.2.3');

insert into TableWithHierarchy (Id, ParentId, Val) values (24, 11, '1.1.3.1');
insert into TableWithHierarchy (Id, ParentId, Val) values (25, 11, '1.1.3.2');
insert into TableWithHierarchy (Id, ParentId, Val) values (26, 11, '1.1.3.3');
end

execute ibeblock
as
begin
insert into TableWithHierarchy (Id, ParentId, Val) values (101, null, '3');
insert into TableWithHierarchy (Id, ParentId, Val) values (104, 101, '3.1');
insert into TableWithHierarchy (Id, ParentId, Val) values (105, 101, '3.2');
insert into TableWithHierarchy (Id, ParentId, Val) values (106, 101, '3.3');
insert into TableWithHierarchy (Id, ParentId, Val) values (107, 104, '3.1.1');
insert into TableWithHierarchy (Id, ParentId, Val) values (108, 107, '3.1.1.1');

insert into TableWithHierarchy (Id, ParentId, Val) values (102, null, '4');
insert into TableWithHierarchy (Id, ParentId, Val) values (103, null, '5');
end