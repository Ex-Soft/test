-- Table: testdb.test_types

-- DROP TABLE testdb.test_types;

CREATE TABLE testdb.test_types
(
    id integer NOT NULL DEFAULT nextval('testdb.test_types_id_seq'::regclass),
    f_text text COLLATE pg_catalog."default" null,
    f_money money null,
    f_integer integer null,
    f_date date null,
    f_time_wo_tz time without time zone null,
    f_time_w_tz time with time zone null,
    f_timestamp_wo_tz timestamp without time zone null,
    f_timestamp_w_tz timestamp with time zone null,
    f_interval interval null,
    CONSTRAINT test_types_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE testdb.test_types
    OWNER to postgres;
