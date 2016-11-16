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

insert into Products (Name, Description, Category, Price) values (N'Kayak', N'A board for one person', N'Watersports', 275)
insert into Products (Name, Description, Category, Price) values (N'Lifejacket', N'Protective and fashionable', N'Watersports', 48.95)
insert into Products (Name, Description, Category, Price) values (N'Soccer ball', N'FIFA-approved size and weight', N'Soccer', 19.50)
insert into Products (Name, Description, Category, Price) values (N'Corner Flags', N'Give your playing field a professional touch', N'Soccer', 34.95)
insert into Products (Name, Description, Category, Price) values (N'Stadium', N'Flat-packed 35,000-seat stadium', N'Soccer', 79500)
insert into Products (Name, Description, Category, Price) values (N'Shin pads', N'Defend your delicate little legs', N'Soccer', 11.99)
insert into Products (Name, Description, Category, Price) values (N'Thinking Cap', N'Improve your brain efficiency by 75%', N'Chess', 16)
insert into Products (Name, Description, Category, Price) values (N'Unsteady Chair', N'Secretly give your oppenent a disadvantage', N'Chess', 29.95)
insert into Products (Name, Description, Category, Price) values (N'Human Chess Board', N'A fun game for the family', N'Chess', 75)
insert into Products (Name, Description, Category, Price) values (N'Bling-Bling King', N'Gold-plated, diamond-studded King', N'Chess', 1200)
go
