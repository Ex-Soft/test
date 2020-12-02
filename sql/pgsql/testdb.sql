-- Database: testdb

-- DROP DATABASE testdb;

CREATE DATABASE testdb
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'English_United States.1251'
    LC_CTYPE = 'English_United States.1251'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

-- SCHEMA: testdb

-- DROP SCHEMA testdb ;

CREATE SCHEMA testdb
    AUTHORIZATION postgres;
