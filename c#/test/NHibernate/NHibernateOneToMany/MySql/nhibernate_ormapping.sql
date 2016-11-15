CREATE DATABASE ormapping;
USE ormapping;

CREATE TABLE `customer` (
  `Id` int(10) unsigned NOT NULL auto_increment,
  `Name` varchar(45) NOT NULL default '',
  PRIMARY KEY  (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


CREATE TABLE `order` (
  `Id` int(10) unsigned NOT NULL auto_increment,
  `Number` int(10) unsigned NOT NULL default '0',
  `CustomerId` int(10) unsigned NOT NULL default '0',
  PRIMARY KEY  (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;



CREATE TABLE `dog` (
  `Id` int(10) unsigned NOT NULL auto_increment,
  `Name` varchar(45) NOT NULL default '',
  PRIMARY KEY  (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


CREATE TABLE `leg` (
  `Id` int(10) unsigned NOT NULL auto_increment,
  `Position` int(10) unsigned NOT NULL default '0',
  `DogId` int(10) unsigned NOT NULL default '0',
  PRIMARY KEY  (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


CREATE TABLE `conversation` (
  `Id` int(10) unsigned NOT NULL auto_increment,
  `Subject` varchar(45) NOT NULL default '',
  PRIMARY KEY  (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


CREATE TABLE `message` (
  `Id` int(10) unsigned NOT NULL auto_increment,
  `Order` int(10) unsigned NOT NULL default '0',
  `Text` varchar(45) NOT NULL default '',
  `ConversationId` int(10) unsigned NOT NULL default '0',
  PRIMARY KEY  (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


CREATE TABLE `department` (
  `Id` int(10) unsigned NOT NULL auto_increment,
  `Name` varchar(45) NOT NULL default '',
  PRIMARY KEY  (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


CREATE TABLE `employee` (
  `Id` int(10) unsigned NOT NULL auto_increment,
  `Name` varchar(45) NOT NULL default '',
  `Address` varchar(45) NOT NULL default '',
  `DepartmentId` int(10) unsigned NOT NULL default '0',
  PRIMARY KEY  (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


CREATE TABLE `street` (
  `Id` int(10) unsigned NOT NULL auto_increment,
  `Name` varchar(45) NOT NULL default '',
  PRIMARY KEY  (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


CREATE TABLE `habitant` (
  `Id` int(10) unsigned NOT NULL auto_increment,
  `NameId` int(10) unsigned NOT NULL default '0',
  `StreetId` int(10) unsigned NOT NULL default '0',
  `HouseNumber` int(10) unsigned NOT NULL default '0',
  PRIMARY KEY  (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


CREATE TABLE `personname` (
  `Id` int(10) unsigned NOT NULL auto_increment,
  `Name` varchar(45) NOT NULL default '',
  PRIMARY KEY  (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
