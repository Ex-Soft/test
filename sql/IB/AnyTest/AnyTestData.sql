execute ibeblock
as
begin

delete from AnyTest;

insert into AnyTest (Id, Length_Of_File, File_Name, MD5) values (1, 100, 'file_100_1', 'abcdef');
insert into AnyTest (Id, Length_Of_File, File_Name, MD5) values (2, 100, 'file_100_2', 'abcdef');
insert into AnyTest (Id, Length_Of_File, File_Name, MD5) values (3, 100, 'file_100_3', 'abcdef');

insert into AnyTest (Id, Length_Of_File, File_Name, MD5) values (4, 200, 'file_200_1', 'zxcvbn');
insert into AnyTest (Id, Length_Of_File, File_Name, MD5) values (5, 200, 'file_200_2', 'zxcvbn');
insert into AnyTest (Id, Length_Of_File, File_Name, MD5) values (6, 200, 'file_200_3', 'zxcvbn');
insert into AnyTest (Id, Length_Of_File, File_Name, MD5) values (7, 200, 'file_200_4', 'asdfgh');
insert into AnyTest (Id, Length_Of_File, File_Name, MD5) values (8, 200, 'file_200_5', 'asdfgh');

insert into AnyTest (Id, Length_Of_File, File_Name, MD5) values (9, 300, 'file_300_1', 'qwerty');

end
