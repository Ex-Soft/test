<%@ Language=VBScript %>
<%
dim ConnectionString
dim Conn
dim SQL
dim RS

ConnectionString="Driver={SQL Server};Server=WSKIECCO0015\SQLEXPRESS;Database=testdb;Trusted_Connection=Yes;"
'"Server=WSKIECCO0015\SQLEXPRESS;database=testdb;Integrated Security=SSPI"
Conn=Server.CreateObject("ADODB.Connection")
'Conn.Open ConnectionString
'SQL="select count(*) from staff"
'RS=Conn.Execute(SQL)
'Conn.Close
%>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<title>Test DB (VB)</title>
	</head>
	<body>
	<%=ConnectionString%><br/>
<%
if not isnull(Conn) then
	Response.Write "Conn is not null"
	Response.Write Conn.State
else
	Response.Write "Conn is null"
end if
%><br/>
<%
if not isempty(Conn) then
	Response.Write "Conn is not empty"
else
	Response.Write "Conn is empty"
end if
%><br/>

	</body>
</html>
