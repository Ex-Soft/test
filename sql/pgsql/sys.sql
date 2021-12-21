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

select
       *
from
    notifications.pg_catalog.pg_type t
    join notifications.pg_catalog.pg_class c on c.oid = t.typrelid
    join notifications.pg_catalog.pg_attribute a on a.attrelid = c.oid
WHERE
    t.typname = 'notification'
    and a.attname = 'last_updated_by';
