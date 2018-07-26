<!doctype html>
<html>
	<head>
		<title>Test UploadFile (action)</title>
	</head>
	<body>
<?php
echo "<h1>Test UploadFile (action)</h1>";

/*if (isset($_POST["submit"]))*/ {
	echo "submit<br/>";
	/*if (isset($_FILES["fileToUpload"]))*/ {
		echo $_FILES["fileToUpload"]["name"]."<br/>";
	}
} /*else {
	echo "!submit<br/>";
}*/
?>
	</body>
</html>
