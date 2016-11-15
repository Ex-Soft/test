CREATE DATABASE MyComics
GO

USE MyComics
GO

CREATE TABLE Books (
  Id         numeric(5,0)   IDENTITY,
  Title      varchar (64)   NOT NULL,
  Number     smallint       NOT NULL,
  Year       smallint       NOT NULL,
  Rating     decimal (3, 1) NOT NULL,
  CGC        bit            NOT NULL,
  LargeCover varchar (64)   NOT NULL,
  SmallCover varchar (64)   NOT NULL,
  Comment    varchar (512)  NULL 
) with identity_gap=10

INSERT INTO Books (Title, Number, Year, Rating, CGC, LargeCover, SmallCover, Comment)
  VALUES ('Masterminds of the .NET Universe', 1, 2001, 9.0, 0, 'mm_01.jpg', 'mm_01_small.jpg',
  'First title in the Masterminds series.')

INSERT INTO Books (Title, Number, Year, Rating, CGC, LargeCover, SmallCover, Comment)
  VALUES ('Masterminds of the .NET Universe', 2, 2002, 9.2, 1, 'mm_02.jpg', 'mm_02_small.jpg',
  'Minor wear on the cover prevents this one from grading higher. Pages are white to off-white.')

INSERT INTO Books (Title, Number, Year, Rating, CGC, LargeCover, SmallCover, Comment)
  VALUES ('Masterminds of the .NET Universe', 3, 2002, 9.4, 0, 'mm_03.jpg', 'mm_03_small.jpg',
  'First appearance of Dr. Evil.')

INSERT INTO Books (Title, Number, Year, Rating, CGC, LargeCover, SmallCover, Comment)
  VALUES ('Masterminds of the .NET Universe', 4, 2002, 9.0, 1, 'mm_04.jpg', 'mm_04_small.jpg',
  'Hard-to-find issue made rarer by a printing error that limited production.')

INSERT INTO Books (Title, Number, Year, Rating, CGC, LargeCover, SmallCover, Comment)
  VALUES ('Masterminds of the .NET Universe', 5, 2002, 9.2, 0, 'mm_05.jpg', 'mm_05_small.jpg',
  'Double issue featuring epic battle for control of the universe.')

INSERT INTO Books (Title, Number, Year, Rating, CGC, LargeCover, SmallCover, Comment)
  VALUES ('Masterminds of the .NET Universe', 6, 2002, 9.4, 1, 'mm_06.jpg', 'mm_06_small.jpg',
  'My personal favorite.')

INSERT INTO Books (Title, Number, Year, Rating, CGC, LargeCover, SmallCover, Comment)
  VALUES ('Masterminds of the .NET Universe', 7, 2002, 9.0, 0, 'mm_07.jpg', 'mm_07_small.jpg',
  'Landmark issue featuring all the masterminds together for the first time.')

GO