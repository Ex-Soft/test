if not exists (select * from sys.databases where name = N'TestDBForTest')
begin
	create database [TestDBForTest] on (name = TestDBForTest, filename = N'$(ProjectDir)TestDBForTest.mdf'), (name = TestDBForTest_log, filename = '$(ProjectDir)TestDBForTest_log.ldf') for attach;
	alter database [TestDBForTest] set online;
end
