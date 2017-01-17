<html>
	<head>
		<meta charset="utf-8"/>
		<title>Test ASP</title>
	</head>
	<body>

<script runat="server" language="JScript">
var a = new Date(2009,1,31);
response.Write(a);
response.Write("<br/>");
</script>

<%
Function GetExpires(A, B)
Dim Y, M, D
Dim C

  If A >= B Then
    GetExpires = "Истек"
	Exit Function
  End If
  
  C = A
  Y = 0
  Do While Year(C) < Year(B)
    C = DateAdd("yyyy", 1, C)
    Y = Y + 1
  Loop 
  
  C = A
  M = 0
  Do While Month(C) < Month(B)
    C = DateAdd("m", 1, C)
    M = M + 1
  Loop 
  
  C = A
  D = 0
  Do While Day(C) < Day(B)
    C = DateAdd("d", 1, C)
    D = D + 1
  Loop

  
  GetExpires = Y & " г. " & M & " м. " & D & " д. " 
End Function

Function Age(Date1, Date2)
    Dim Y
    Dim M
    Dim D
    Dim Temp1
    Temp1 = DateSerial(Year(Date2), Month(Date1), Day(Date1))
    Y = Year(Date2) - Year(Date1) + (Temp1 > Date2)
    M = Month(Date2) - Month(Date1) - (12 * (Temp1 > Date2))
    D = Day(Date2) - Day(Date1)
    If D < 0 Then
        M = M - 1
        D = Day(DateSerial(Year(Date2), Month(Date2) + 1, 0)) + D rem + 1
    End If
    Age = Y & " years " & M & " months " & D & " days"
End Function

Dim b
Dim e

b=DateSerial(2012, 4, 30)
e=DateSerial(2012, 5, 1)

response.write(b)
response.write("<br/>")
response.write(e)
response.write("<br/>")
response.write(GetExpires(b, e))
response.write("<br/>")
response.write(Age(b, e))
%>
	</body>
</html>