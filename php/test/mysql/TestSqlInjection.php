<!doctype html>
<!-- http://pentestmonkey.net/cheat-sheet/sql-injection/mysql-sql-injection-cheat-sheet -->
<html>
	<head>
		<meta charset="utf-8" />
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
		<title>Test SQL injection</title>
	</head>
	<body>
<?php
echo "Иванов Иван Иванович' union select 1 as id, @@datadir as name; #";
echo "<form action=\"TestSqlInjection.php\" method=\"post\" enctype=\"multipart/form-data\">
<label>Text: <input type=\"text\" name=\"victimText\" value=\"". $victimText ."\"></label><br/>
<input type=\"submit\" value=\"submit\" name=\"submit\">
</form>";

$dbname = "test";
$dbuser = "root";
$dbpass = "";
$dbhost = "localhost";
$con = mysqli_connect($dbhost, $dbuser, $dbpass, $dbname);

if (!$con) {
	echo "Error: Unable to connect to MySQL." . PHP_EOL;
	echo "Debugging errno: " . mysqli_connect_errno() . PHP_EOL;
	echo "Debugging error: " . mysqli_connect_error() . PHP_EOL;
	exit;
}

if (!$con->set_charset("utf8")) {
	echo "Error loading character set utf8: " . $mysqli->error($con) . "<br/>";
	exit;
} else {
	echo "Current character set: " . $con->character_set_name() . "<br/>";
}

echo "Success: A proper connection to MySQL was made! The my_db database is great." . PHP_EOL;
echo "Host information: " . mysqli_get_host_info($con) . "<br/>";

$sql = "select id, name from staff";

if (isset($_POST["victimText"])) {
	$victimText = $_POST["victimText"];

	if (is_string($victimText) && strlen($victimText = trim($victimText)) > 0) {
		$sql = $sql ." where name = '". $victimText ."'";
	}
}

echo $sql ."<br/>";

$retval = mysqli_query($con, $sql);

if(!$retval ) {
	die("Could not get data: " . mysqli_error($con));
}
 
while($row = mysqli_fetch_array($retval, MYSQLI_ASSOC)) {
	echo "id: {$row['id']}" . " name: \"{$row['name']}\"<br/>";
}

echo "Fetched data successfully\n";

mysqli_close($con);
?>
	</body>
</html>
