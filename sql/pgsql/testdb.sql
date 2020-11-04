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

-- Table: testdb.staff

-- DROP TABLE testdb.staff;

CREATE TABLE testdb.staff
(
    id integer NOT NULL DEFAULT nextval('testdb.staff_id_seq'::regclass),
    name text COLLATE pg_catalog."default",
    salary money,
    dep integer,
    birth_date date,
    null_field numeric(18,0),
    CONSTRAINT staff_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE testdb.staff
    OWNER to postgres;
