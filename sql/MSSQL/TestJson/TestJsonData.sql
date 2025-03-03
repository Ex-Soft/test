use testdb;
go

declare @jsonDataObject1 nvarchar(max) = N'{ "email": "teammember1@mailinator.com", "password": "TeamMember1" }';
declare @jsonDataArray1 nvarchar(max) = N'[{ "email": "teammember1@mailinator.com", "password": "TeamMember1" }, { "email": "teammember2@mailinator.com", "password": "TeamMember2" }, { "email": "teammember3@mailinator.com", "password": "TeamMember3" }]';
declare @jsonDataObject2 nvarchar(max) = N'{ "email": "teammember2@mailinator.com", "password": "TeamMember2" }';
declare @jsonDataArray2 nvarchar(max) = N'[{ "email": "teammember4@mailinator.com", "password": "TeamMember4" }, { "email": "teammember5@mailinator.com", "password": "TeamMember5" }, { "email": "teammember6@mailinator.com", "password": "TeamMember6" }]';
declare @jsonDataObject3 nvarchar(max) = N'{ "email": "teammember3@mailinator.com", "password": "TeamMember3" }';
declare @jsonDataArray3 nvarchar(max) = N'[{ "email": "teammember7@mailinator.com", "password": "TeamMember7" }, { "email": "teammember8@mailinator.com", "password": "TeamMember8" }, { "email": "teammember9@mailinator.com", "password": "TeamMember9" }]';

delete from dbo.TestJson;

set identity_insert dbo.TestJson on;

insert into dbo.TestJson (Id, JsonDataObject, JsonDataArray) values (1, @jsonDataObject1, @jsonDataArray1);
insert into dbo.TestJson (Id, JsonDataObject, JsonDataArray) values (2, @jsonDataObject2, @jsonDataArray2);
insert into dbo.TestJson (Id, JsonDataObject, JsonDataArray) values (3, @jsonDataObject3, @jsonDataArray3);

set identity_insert dbo.TestJson off;

