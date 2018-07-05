<!doctype html>
<html>
<?php
    setcookie("cookie1", "cookie1up", 0, "", "", false, true);
    setcookie("cookie2", "cookie2up");
?>
	<head>
		<meta charset="utf-8" />
		<title>Test Cookies (up)</title>
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
		<h1>up</h1>
		<hr/>
		<p><?php echo "cookie1=\"".$_COOKIE["cookie1"]."\""; ?></p>
		<p><?php echo "cookie2=\"".$_COOKIE["cookie2"]."\""; ?></p>
		<a href="main/TestCookies.php">main</a>&nbsp;<a href="main/down/TestCookies.php">down</a>
		<form action="TestCookiesAction.php">
			<input id="inputTypeText" type="text" name="inputTypeText" style="width: 100%; "/></br>
			<input type="submit" value="submit"/>
		</form>
	</body>
</html>
