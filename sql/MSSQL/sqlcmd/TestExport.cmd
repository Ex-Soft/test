sqlcmd -S "(localdb)\MSSQLLocalDB" -E -d testdb -i TestExport.sql -s "|" -u -W -o TestExport.txt
