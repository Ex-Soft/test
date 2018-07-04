<!doctype html>
<html>
<?php
    setcookie("cookie1", "cookie1", 0, "", "", false, true);
    setcookie("cookie2", "cookie2");
?>
	<head>
		<meta charset="utf-8" />
		<title>Test Cookies</title>
		<script>
function DoIt()
{
	var
		allcookies = document.cookie,
		ctrl;

	if (ctrl = document.getElementById("inputTypeText"))
		ctrl.value = allcookies;

	if(window.console && console.log) {
		console.log(allcookies);
	}
}
		</script>
	</head>
	<body onload="DoIt()">
		<p><?php echo "cookie1=\"".$_COOKIE["cookie1"]."\""; ?></p>
		<p><?php echo "cookie2=\"".$_COOKIE["cookie2"]."\""; ?></p>
		<form action="TestCookiesAction.php">
			<input id="inputTypeText" type="text" name="inputTypeText"/>
			<input type="submit" value="submit"/>
		</form>
	</body>
</html>
