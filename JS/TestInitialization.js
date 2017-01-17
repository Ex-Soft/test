var
	o = {},
	fieldName1,
	fieldName2,
	str="";

//o[fieldName1="fieldName1"] = foo(fieldName1); // o.fieldName1="fieldName1"
o[fooL(fieldName1="fieldName1")] = fooR(fieldName1);
//o[fieldName2] = foo(fieldName2="fieldName2"); // o.undefined="fieldName2"
o[fooL(fieldName2)] = fooR(fieldName2="fieldName2");
//o[o.propertyName1="property1"] = foo(o.propertyName1); //o.property1="property1"
//o[o.propertyName2] = foo(o.propertyName2="property2"); //o.undefined="property2"

//o.property3 = foo();

for(var p in o)
{
	if(str.length>0)
		str += ",\r\n";

	str += "\t" + p + "=\"" + o[p] + "\"";
}

WScript.Echo("{\r\n" + str + "\r\n}");

function foo(param)
{
	return param || "oops";
}

function fooL(param)
{
	WScript.Echo("fooL(" + param + ")");
	return param || "oops";
}

function fooR(param)
{
	WScript.Echo("fooR(" + param + ")");
	return param || "oops";
}