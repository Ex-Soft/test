-- BACKUP
./pg_dump.exe --file "./orderledger_20210315.bckp" --host "order-ledger.com" --port "5432" --username "LedgerAdmin" --password --verbose --format=t --blobs "order-ledger"

-- RESTORE
"c:\Program Files\PostgreSQL\12\bin\pg_restore.exe" --host "localhost" --port "5432" --username "LedgerAdmin" --password --dbname "order_ledger" --verbose "./orderledger_20210823.bckp"