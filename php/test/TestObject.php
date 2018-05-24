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
	//echo phpinfo();

	echo 'phpversion() ' . phpversion();
	echo "<br/><br/>";

	$a = (object)["p1" => 0, "p2" => "p2 (a)"];
	$b = $a;

	++$a->p1;
	$a->p2 = "p2 (b)";
	echo serialize($a);
	echo "<br/>";
	echo serialize($b);
	echo "<br/>";
	echo 'gettype($a) = ' . gettype($a) . "<br/>";
	echo 'gettype($a) ' . (gettype($a) == "object" ? "=" : "!") . "= \"object\"<br/>";
	echo 'gettype($a) ' . (gettype($a) === "object" ? "=" : "!") . "== \"object\"<br/>";
	echo 'property_exists($a, "p1") = "' . property_exists($a, "p1") . "\"<br/>";
	echo 'property_exists($a, "p10") = "' . property_exists($a, "p10") . "\"<br/>";
	if (property_exists($a, "p1"))
		echo "oB!<br/>";
	if (!property_exists($a, "p10"))
		echo "Tampax<br/>";
	echo "<br/>";

	$o = array("p1" => 1, "p2" => "p2", "p3" => array("1st", "2nd", "3rd"), "p4" => array("p1" => 1, "p2" => "p2"));
	echo serialize($o);
	echo "<br/>";
	echo 'gettype($o) = ' . gettype($o) . "<br/>";
	echo 'gettype($o) ' . (gettype($o) == "array" ? "=" : "!") . "= \"array\"<br/>";
	echo 'gettype($o) ' . (gettype($o) === "array" ? "=" : "!") . "== \"array\"<br/>";
	echo 'array_key_exists("p1", $o) = "' . array_key_exists("p1", $o) . "\"<br/>";
	echo 'array_key_exists("p10", $o) = "' . array_key_exists("p10", $o) . "\"<br/>";
	if (array_key_exists("p1", $o))
		echo "oB!<br/>";
	if (!array_key_exists("p10", $o))
		echo "Tampax<br/>";
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

