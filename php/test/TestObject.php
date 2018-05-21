<!doctype html>
<html>
	<head>
		<meta charset="utf-8" />
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
		<title>Test Object</title>
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
	echo phpinfo();

	echo 'phpversion() ' . phpversion();
	echo "<br/><br/>";

	$o = array("p1" => 1, "p2" => "p2", "p3" => array("1st", "2nd", "3rd"), "p4" => array("p1" => 1, "p2" => "p2"));
	echo serialize($o);
	echo "<br/>";

	print_r($o);
	echo "<br/>";

	foreach($o as $key => $value) {
		echo '$key=' . $key. ' gettype($value) ' . gettype($value) . "<br/>";
		echoObject($value);
	}
	echo "<br/>";

	$o = (object)["p1" => 1, "p2" => "p2", "p3" => array("1st", "2nd", "3rd"), "p4" => (object)["p1" => 1, "p2" => "p2"]];
	echo serialize($o);
	echo "<br/>";

	print_r($o);
	echo "<br/>";

	foreach($o as $key => $value) {
		echo '$key=' . $key. ' gettype($value) ' . gettype($value) . "<br/>";
		echoObject($value);
	}
}
catch(Exception $e) {
	echo 'Message: ' .$e->getMessage();
}
?>
	</body>
</html>

