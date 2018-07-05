<!doctype html>
<html lang="uk"> <!-- dir="rtl" -->
<?php
	header("Content-Language: uk");
?>
	<head>
		<meta charset="utf-8" />
		<title>Test Localization</title>
		<script>
function DoIt()
{
	var
		num = 123456789.123,
		dt = new Date("2018-12-31T23:59:59+02:00");

	document.write(num.toString(), "<br/>");
	document.write(num.toLocaleString(), "<br/>");
	document.write(dt.toString(), "<br/>");
	document.write(dt.toLocaleString(), "<br/>");
	document.write(dt.toGMTString(), "<br/>");

	if(window.console && console.log) {
		console.log(num.toString());
		console.log(num.toLocaleString());
		console.log(dt.toString());
		console.log(dt.toLocaleString());
		console.log(dt.toGMTString());
	}
}
		</script>
	</head>
	<body onload="DoIt()">
	</body>
</html>