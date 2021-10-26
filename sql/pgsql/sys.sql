select version();

SHOW client_encoding;

SELECT
    *
FROM
    pg_proc p
    JOIN pg_namespace n ON n.oid = p.pronamespace
WHERE
    proname = 'create_line_item_event'
    AND n.nspname = 'ledger';

/* use dbname */
\connect dbname [rolename]
\c dbname [rolename]

