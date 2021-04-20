-- Type: detail_item

-- DROP TYPE testdb.detail_item;

CREATE TYPE testdb.detail_item AS
(
	id integer,
	val text
);

ALTER TYPE testdb.detail_item
    OWNER TO postgres;
