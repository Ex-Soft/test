<%@ Language=JavaScript %>
<%
var
	ConnectionString,
	Conn,
	SQL="",
	RS;

//ConnectionString="Driver={SQL Server};Server=WSKIECCO0015\SQLEXPRESS;Database=testdb;Trusted_Connection=Yes;"
ConnectionString="Server=WSKIECCO0015\\SQLEXPRESS;database=testdb;Integrated Security=SSPI";
try
{
	Conn=Server.CreateObject("ADODB.Connection");
	Conn.Open(ConnectionString);
	Conn.Close();
}
catch(err)
{
	SQL="Error name"+err.name+" message "+err.message;
}

//SQL="select count(*) from staff"
//RS=Conn.Execute(SQL)
%>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<title>Test DB (VB)</title>
	</head>
	<body>
	<%=ConnectionString%><br/>
<%
if(Conn)
{
	Response.Write("Conn is not null<br/>");
	Response.Write(Conn.State+"<br/>");
	Response.Write(SQL);
}
else
	Response.Write("Conn is null");
%><br/>
	</body>
</html>
