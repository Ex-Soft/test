use SportsStore
go

if object_id('Products', N'u') is not null
  drop table Products
go

create table Products
(
   ProductID int not null identity constraint pkProducts primary key,
   Name nvarchar(100) not null,
   Description nvarchar(500) not null,
   Category nvarchar(50) not null,
   Price decimal(16, 2) not null
)
go

insert into Products (Name, Description, Category, Price) values ('Kayak', 'A board for one person', 'Watersports', 275)
insert into Products (Name, Description, Category, Price) values ('Lifejacket', 'Protective and fashionable', 'Watersports', 48.95)
insert into Products (Name, Description, Category, Price) values ('Soccer ball', 'FIFA-approved size and weight', 'Soccer', 19.50)
insert into Products (Name, Description, Category, Price) values ('Shin pads', 'Defend your delicate little legs', 'Soccer', 11.99)
insert into Products (Name, Description, Category, Price) values ('Stadium', 'Flat-packed 35,000-seat stadium', 'Soccer', 8950.00)
go