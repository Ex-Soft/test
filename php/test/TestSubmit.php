<!doctype html>
<html>
<?php
    setcookie("cookie1", "cookie1value");
    setcookie("cookie2", "cookie2value");
?>
	<head>
		<meta charset="utf-8" />
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
		<title>Test Submit</title>
	</head>
	<body>
<?php
$victimText = "";
$victimNumber = "";

if (isset($_POST["victimText"])) {
	$victimText = $_POST["victimText"];

	echo 'gettype($victimText) = "'. gettype($victimText) ."\"<br/>";
	echo 'is_numeric($victimText) = "'. is_numeric($victimText) ."\"<br/>";
	if (is_string($victimText)) {
		echo 'ctype_digit($victimText) = "'. ctype_digit($victimText) ."\"<br/>";
	}
	echo (0 + $victimText) ."<br/>";
	echo '($victimText '. ($victimText < 5 ? "<" : ">=") ." 5)<br/>";
}

if (isset($_POST["victimNumber"])) {
	$victimNumber = $_POST["victimNumber"];

	echo 'gettype($victimNumber) = "'. gettype($victimNumber) ."\"<br/>";
	echo 'is_numeric($victimNumber) = "'. is_numeric($victimNumber) ."\"<br/>";
}

echo "&quot;&gt;&lt;img src=&quot;x&quot; onerror=&quot;alert(document.cookie)&quot;&gt;";
echo "<br/>";
echo "&quot;&gt;&lt;script src=&quot;app.js&quot; onerror=&quot;alert(document.cookie)&quot;&gt;&lt;/script&gt;";

echo "<form action=\"TestSubmit.php\" method=\"post\" enctype=\"multipart/form-data\">
<label>Text: <input type=\"text\" name=\"victimText\" value=\"". $victimText ."\"></label><br/>
<label>Number: <input type=\"number\" name=\"victimNumber\" value=\"". $victimNumber ."\"></label><br/>
<input type=\"submit\" value=\"submit\" name=\"submit\">
</form>";

?>
	</body>
</html>
