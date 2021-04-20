-- Table: testdb.detail

-- DROP TABLE testdb.detail;

CREATE TABLE testdb.detail
(
    id integer NOT NULL DEFAULT nextval('testdb.detail_id_seq'::regclass),
	id_master integer NOT NULL,
    val text COLLATE pg_catalog."default",
	f_int integer null,
    CONSTRAINT detail_pkey PRIMARY KEY (id),
	CONSTRAINT detail_id_master foreign key (id_master) references testdb.master(id)
)

TABLESPACE pg_default;

ALTER TABLE testdb.detail
    OWNER to postgres;

select
	*
from
	pg_attribute
where
	attrelid = 'testdb.detail'::regclass;
