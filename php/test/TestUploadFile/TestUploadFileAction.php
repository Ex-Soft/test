<!doctype html>
<html>
	<head>
		<title>Test UploadFile (action)</title>
	</head>
	<body>
<?php
echo "<h1>Test UploadFile (action)</h1>";

if (isset($_POST["submit"])) {
	echo 'isset($_POST["submit"])<br/>';
	if (isset($_FILES["fileToUpload"])) {
		echo 'isset($_FILES["fileToUpload"])<br/>';
		$userfile = $_FILES["fileToUpload"]["tmp_name"];
		echo $_FILES["fileToUpload"]["tmp_name"]."<br/>";
		$userfile_name = $_FILES["fileToUpload"]["name"];
		echo $_FILES["fileToUpload"]["name"]."<br/>";
		$userfile_size = $_FILES["fileToUpload"]["size"];
		echo $_FILES["fileToUpload"]["size"]."<br/>";
		$userfile_type = $_FILES["fileToUpload"]["type"];
		echo $_FILES["fileToUpload"]["type"]."<br/>";
		$userfile_error = $_FILES["fileToUpload"]["error"];
		echo $_FILES["fileToUpload"]["error"]."<br/>";

		if ($userfile_error == UPLOAD_ERROR_OK) {
			$upfile = $userfile_name;
			if (is_uploaded_file($userfile)) {
				if (file_exists($upfile)) {
					if (!unlink($upfile)) {
						echo '!unlink($upfile)';
					}
				}
				if (!move_uploaded_file($userfile, $upfile)) {
					echo '!move_uploaded_file($userfile, $upfile)';
				}
			}
		}
	} else {
		echo '!isset($_FILES["fileToUpload"])<br/>';
	}
} else {
	echo '!isset($_POST["submit"])<br/>';
}
?>
	</body>
</html>
