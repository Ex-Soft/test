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
