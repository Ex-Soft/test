insert into TableWithHierarchyII (Id, Val) values (1, N'/1')
insert into TableWithHierarchyII (Id, ParentId, Val) values (2, 1, N'/1/1.1')
insert into TableWithHierarchyII (Id, ParentId, Val) values (3, 2, N'/1/1.1/1.1.1')
insert into TableWithHierarchyII (Id, ParentId, Val) values (4, 3, N'/1/1.1/1.1.1/1.1.1.1')
insert into TableWithHierarchyII (Id, ParentId, Val) values (5, 4, N'/1/1.1/1.1.1/1.1.1.1/1.1.1.1.1')
