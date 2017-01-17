<%@ Language=VBScript %>
<%
dim varInt
dim varStr
dim varDecimal
%>
<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
		<title>AnyTest (VB)</title>
	</head>
	<body>
VarType: <% =VarType(varInt) %><br />
<% if VarType(varInt)=vbNull then Response.Write "varInt is vbNull" else Response.Write "varInt is not vbNull" end if %><br />
<% if not isnull(varInt) then Response.Write "varInt is not null" else Response.Write "varInt is null" end if %><br />
<% if not isempty(varInt) then Response.Write "varInt is not empty" else Response.Write "varInt is empty" end if %><br />
<br />
<% varInt=1 %>
<% if not isnull(varInt) then Response.Write "varInt is not null" else Response.Write "varInt is null" end if %><br />
<% if not isempty(varInt) then Response.Write "varInt is not empty" else Response.Write "varInt is empty" end if %><br />
VarType: <% =VarType(varInt) %><br />
TypeName: <% =TypeName(varInt) %><br />
<% if VarType(varInt)=vbInteger then Response.Write "varInt is vbInteger" else Response.Write "varInt is not vbInteger" end if %><br />
<hr />

VarType: <% =VarType(varStr) %><br />
<% if VarType(varStr)=vbNull then Response.Write "varStr is vbNull" else Response.Write "varStr is not vbNull" end if %><br />
<% if not isnull(varStr) then Response.Write "varStr is not null" else Response.Write "varStr is null" end if %><br />
<% if not isempty(varStr) then Response.Write "varStr is not empty" else Response.Write "varStr is empty" end if %><br />
<br/>
<% varStr="blah-blah-blah" %>
<% if not isnull(varStr) then Response.Write "varStr is not null" else Response.Write "varStr is null" end if %><br />
<% if not isempty(varStr) then Response.Write "varStr is not empty" else Response.Write "varStr is empty" end if %><br />
VarType: <% =VarType(varStr) %><br />
TypeName: <% =TypeName(varStr) %><br />
<% if VarType(varStr)=vbString then Response.Write "varStr is vbString" else Response.Write "varStr is not vbString" end if %><br />
<hr />

VarType: <% =VarType(varDecimal) %><br />
<% if VarType(varDecimal)=vbNull then Response.Write "varDecimal is vbNull" else Response.Write "varDecimal is not vbNull" end if %><br />
<% if not isnull(varDecimal) then Response.Write "varDecimal is not null" else Response.Write "varDecimal is null" end if %><br />
<% if not isempty(varDecimal) then Response.Write "varDecimal is not empty" else Response.Write "varDecimal is empty" end if %><br />
<br/>
<% varDecimal=CDec(1) %>
<% if not isnull(varDecimal) then Response.Write "varDecimal is not null" else Response.Write "varDecimal is null" end if %><br />
<% if not isempty(varDecimal) then Response.Write "varDecimal is not empty" else Response.Write "varDecimal is empty" end if %><br />
VarType: <% =VarType(varDecimal) %><br />
TypeName: <% =TypeName(varDecimal) %><br />
<% if VarType(varDecimal)=vbDecimal then Response.Write "varDecimal is vbDecimal" else Response.Write "varDecimal is not vbDecimal" end if %><br />
<hr />

If VarType(myVar) = vbNull Then
MsgBox "Null (no valid data) "
ElseIf VarType(myVar) = vbInteger Then
MsgBox "Integer "
ElseIf VarType(myVar) = vbLong Then
MsgBox "Long integer "
ElseIf VarType(myVar) = vbSingle Then
MsgBox "Single-precision floating-point number "
ElseIf VarType(myVar) = vbDouble Then
MsgBox "Double-precision floating-point number "
ElseIf VarType(myVar) = vbCurrency Then
MsgBox "Currency value "
ElseIf VarType(myVar) = vbDate Then
MsgBox "Date value "
ElseIf VarType(myVar) = vbString Then
MsgBox "String "
ElseIf VarType(myVar) = vbObject Then
MsgBox "Object "
ElseIf VarType(myVar) = vbError Then
MsgBox "Error value "
ElseIf VarType(myVar) = vbBoolean Then
MsgBox "Boolean value "
ElseIf VarType(myVar) = vbVariant Then
MsgBox "Variant (used only with arrays of variants) "
ElseIf VarType(myVar) = vbDataObject Then
MsgBox "A data access object "
ElseIf VarType(myVar) = vbDecimal Then
MsgBox "Decimal value "
ElseIf VarType(myVar) = vbByte Then
MsgBox "Byte value "
ElseIf VarType(myVar) = vbUserDefinedType Then
MsgBox "Variants that contain user-defined types "
ElseIf VarType(myVar) = vbArray Then
MsgBox "Array "
Else
MsgBox VarType(myVar)
End If

http://support.technetex.ca/devguide/vbscript_functions.aspx

VarType Codes for Data Types
Value	Constant	Data Type
0	vbEmpty	Empty (The type for a variable that has not yet been used)
1	vbNull	Null (No valid data)
2

vbInteger	Integer
3	vbLong	Long
4	vbSingle	Single
5	vbDouble	Double
6	vbCurrency	Currency
7	vbDate	Date
8	vbString	String
9	vbObject	Object
10	vbError	Error
11	vbBoolean	Boolean
12	vbVariant	Variant (used with vbArray)
13	vbDataObject	Data Access Object
14	vbDecimal	Decimal
17	vbByte	Byte
8192	vbArray	Array (VBScript uses 8192 as a base for arrays and adds the code for the data type to indicate an array. 8204 indicates a variant array, the only real kind of array in VBScript.)
 

TypeName(expression) returns a string with the name of the data type rather than a code.

IsNumeric(expression) returns a Boolean value of True if the expression is numeric data, and False otherwise.

IsArray(expression) returns a Boolean value of True if the expression is an array, and False otherwise.

IsDate(expression) returns a Boolean value of True if the expression is date/time data, and False otherwise.

Isempty(expression) returns a Boolean value of True if the expression is an empty value (un-initialized variable), and False otherwise.

IsNull(expression) returns a Boolean value of True if the expression is an object, and False otherwise.

Top
Typecasting Functions

Typecasting allows you to convert between data subtypes.

Cint(expression) casts expression to an integer. If expression is a floating-point value or a currency value, it is rounded. If it is a string that looks like a number, it is turned into that number and then rounded if necessary. If it is a Boolean value of True, it becomes a -1. False becomes 0. It must also be within the range that an integer can store.

Cbyte(expression) casts expression to a byte value provided that expression falls between 0 and 255. expression should be numeric or something that can be cast to a number.

Cdbl(expression) casts expression to a double. expression should be numeric or something that can be cast to a number.

Csng(expression) casts expression to a single. It works like Cdbl(), but must fall within the range represented by a single.

Cbool(expression) casts expression to a Boolean value. If expression is 0, the result is False. Otherwise, the result is True. expression should be numeric or something that can be cast to a number.

Ccur(expression) casts expression to a currency value. expression should be numeric or something that can be cast to a number.

Cdate(expression) casts expression to a date value. expression should be numeric or something that can be cast to a number, or a string of a commonly used date format.
DateValue(expression) or TimeValue(expression) can also be used for this.

Cstr(expression) casts expression to a string. expression can be any kind of data.

Top
Formatting Functions

 
FormatDateTime(expression, format) is used to format the date/time data in expression. format is an optional argument that should be one of the following:

vbGeneralDate -- Display date, if present, as short date. Display time, if present, as long time. Value is 0. This is the default setting if no format is specified.
vbLongDate -- Display date using the server's long date format. Value is 1. [Sunday,July 25, 1999]
vbShortDate -- Display date using server's short date format. Value is 2. [7/25/99]
vbLongTime -- Display time using the server's long time format. Value is 3. [11:22:35 AM]
vbShortTime -- Display time using the server's short time format. Value is 4. [11:22]
FormatCurrency(value, numdigits, leadingzero, negparen, delimiter) is used to format the monetary value specified by value.
numdigits specifies the number of digits after the decimal place to display. -1 indicates to use the system default.

Tristate options have three possible values. If the value is -2, it means use the system default. If it is -1, it means turn on the option. If it is 0, turn off the option.
  leadingzero is a Tristate option indicating whether to include leading zeros on values less than 1.
  negparen is a Tristate option indicating whether to enclose negative values in parentheses.
  delimiter is a Tristate option indicating whether to use the delimeter specified in the computer's settings to group digits.

FormatNumber is used to format numerical values. It is almost exactly like FormatCurrency, only it does not display the dollar sign.

FormatPercent works like the previous two. The options are the same, but it turns the value it is given into a percentage.

Top
Math Functions

 
Abs(number) returns the absolute value of number.

Atn(number) returns the arctangent, in radians, of number.

Cos(number) returns the cosine of number. number should be in radians.

Exp(number) returns e (approx. 2.71828) raised to the power of number.

Fix(number) returns the integer portion of number. If number is negative, Fix returns the first integer greater than or equal to number.

Hex(number) converts number from base 10 to a hexadecimal string.

Int(number) returns the integer portion of number. If number is negative, Int returns the first integer less than or equal to number.

Log(number) returns the natural logarithm of number.

Oct(number) converts number from base 10 to an octal string.

Rnd number returns a random number less than one and greater than or equal to zero.
  If the argument number is less than 0, the same random number is always returned, using number as a seed.
  If number is greater than zero, or not provided, Rnd generates the next random number in the sequence.
  If number is 0, Rnd returns the most recently generated number.

Randomize initializes the random number generator.

Round(number) returns number rounded to an integer.

Round(number, dec) returns number rounded to dec decimal places.

Sgn(number) returns 1 if number is greater than zero, 0 if number equals zero, and -1 if number is less than zero.

Sin(number) returns the sine of number. number should be in radians.

Sqr(number) returns the square root of number. number must be positive.

Tan(number) returns the tangent of number. number should be in radians.

 
	</body>
</html>
