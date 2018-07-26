<!doctype html>
<html>
	<head>
		<title>Test UploadFile</title>
		<script>
function DoIt() {
	var inpt;

	if (!(inpt = document.getElementById("fileToUpload")))
		return;

	for (var i = 0, l = inpt.files.length; i < l; ++i) {
		if (window.console && console.log)
			console.log("%o", inpt.files[i].name);

		inpt.files[i].name = "blah-blah-blah";
	}
}
		</script>
	</head>
	<body>
		<form action="TestUploadFileAction.php" method="post" enctype="multipart/form-data">
			<input type="file" name="fileToUpload" id="fileToUpload"><br/>
			<input type="button" value="click" onclick="DoIt()"><br/>
			<input type="submit" value="submit" name="submit">
		</form>
	</body>
</html>
