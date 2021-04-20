-- Type: master_item

-- DROP TYPE testdb.master_item;

CREATE TYPE testdb.master_item AS
(
	id integer,
	val text,
	items testdb.detail_item[]
);

ALTER TYPE testdb.master_item
    OWNER TO postgres;
