<!doctype html>
<html>
	<head>
		<meta charset="utf-8" />
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
		<title>Test Date</title>
	</head>
	<body>
<?php
function echoObject($o) {
	foreach($o as $key => $value) {
		if (gettype($value) == "array" || gettype($value) == "object")
			echoObject($value);
		else
			echo '$key=' . $key . ', $value ' . $value;
		echo "<br>";
	}
}

try {
	//echo phpinfo();

	echo 'phpversion() ' . phpversion();
	echo "<br/><br/>";

	$d = date_create("2020-04-26");
	echoObject($d);
	$tz = date_timezone_get($d);
	echo timezone_name_get($tz);
	echo "<br/>";
	$str = json_encode($d);
	echo $str;
	echo "<br/><br/>";

	$d = date_create("2020-04-26T08:00:00");
	echoObject($d);
	$tz = date_timezone_get($d);
	echo timezone_name_get($tz);
	echo "<br/><br/>";

	$d = date_create("2020-04-26T08:00:00Z");
	echoObject($d);
	$tz = date_timezone_get($d);
	echo timezone_name_get($tz);
	echo "<br/><br/>";

	$d = date_create("2020-04-26T08:00:00+03:00");
	echoObject($d);
	$tz = date_timezone_get($d);
	echo timezone_name_get($tz);
	echo "<br/><br/>";

	$d = date_create("2020-04-26T08:00:00+00:03");
	echoObject($d);
	$tz = date_timezone_get($d);
	echo timezone_name_get($tz);
	echo "<br/><br/>";

	$str = "{\"d\":\"2020-04-26T08:00:00+03:00\"}";
	$o = json_decode($str);
	echoObject($o);
	echo gettype($o->d);
	echo "<br/>";
	$d = date_create($o->d);
	echoObject($d);
	echo $d->format("Y-m-d");
}
catch(Exception $e) {
	echo 'Message: ' .$e->getMessage();
}
?>
	</body>
</html>

