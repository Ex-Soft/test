create database testdb on (name = testdb, filename = N'd:\db\testdb.mdf') log on (name = testdb_log, filename = 'd:\db\testdb_log.ldf')
--create database testdb on (filename = N'd:\db\testdb.mdf'), (filename = 'd:\db\testdb_log.ldf') for attach;
go
