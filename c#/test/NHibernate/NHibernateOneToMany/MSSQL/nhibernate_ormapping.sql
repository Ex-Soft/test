CREATE DATABASE ormapping
go

USE ormapping
go

CREATE TABLE customer (
  Id numeric(18,0) identity,
  Name varchar(45) NOT NULL default '',
  PRIMARY KEY  (Id)
)
go

CREATE TABLE [order] (
  Id numeric(18,0) identity,
  Number numeric(18,0) NOT NULL default 0,
  CustomerId numeric(18,0) NOT NULL default 0,
  PRIMARY KEY  (Id)
) 
go

CREATE TABLE dog (
  Id numeric(18,0) identity,
  Name varchar(45) NOT NULL default '',
  PRIMARY KEY  (Id)
)
go

CREATE TABLE leg (
  Id numeric(18,0) identity,
  Position numeric(18,0) NOT NULL default 0,
  DogId numeric(18,0) NOT NULL default 0,
  PRIMARY KEY  (Id)
)
go

CREATE TABLE conversation (
  Id numeric(18,0) identity,
  Subject varchar(45) NOT NULL default '',
  PRIMARY KEY  (Id)
)
go


CREATE TABLE message (
  Id numeric(18,0) identity,
  [Order] numeric(18,0) NOT NULL default 0,
  Text varchar(45) NOT NULL default '',
  ConversationId numeric(18,0) NOT NULL default 0,
  PRIMARY KEY  (Id)
)
go


CREATE TABLE department (
  Id numeric(18,0) identity,
  Name varchar(45) NOT NULL default '',
  PRIMARY KEY  (Id)
)
go


CREATE TABLE employee (
  Id numeric(18,0) identity,
  Name varchar(45) NOT NULL default '',
  Address varchar(45) NOT NULL default '',
  DepartmentId numeric(18,0) NOT NULL default 0,
  PRIMARY KEY  (Id)
)
go


CREATE TABLE street (
  Id numeric(18,0) identity,
  Name varchar(45) NOT NULL default '',
  PRIMARY KEY  (Id)
)
go


CREATE TABLE habitant (
  Id numeric(18,0) identity,
  NameId numeric(18,0) NOT NULL default 0,
  StreetId numeric(18,0) NOT NULL default 0,
  HouseNumber numeric(18,0) NOT NULL default 0,
  PRIMARY KEY  (Id)
)
go


CREATE TABLE personname (
  Id numeric(18,0) identity,
  Name varchar(45) NOT NULL default '',
  PRIMARY KEY  (Id)
)
go
