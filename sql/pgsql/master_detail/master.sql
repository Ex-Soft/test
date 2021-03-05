-- Table: testdb.master

-- DROP TABLE testdb.master;

CREATE TABLE testdb.master
(
    id integer NOT NULL DEFAULT nextval('testdb.master_id_seq'::regclass),
    val text COLLATE pg_catalog."default",
    CONSTRAINT master_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE testdb.master
    OWNER to postgres;
