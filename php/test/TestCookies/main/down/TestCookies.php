<!doctype html>
<html>
<?php
    setcookie("cookie1", "cookie1down", 0, "", "", false, true);
    setcookie("cookie2", "cookie2down");
?>
	<head>
		<meta charset="utf-8" />
		<title>Test Cookies (down)</title>
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
		<h1>down</h1>
		<hr/>
		<p><?php echo "cookie1=\"".$_COOKIE["cookie1"]."\""; ?></p>
		<p><?php echo "cookie2=\"".$_COOKIE["cookie2"]."\""; ?></p>
		<a href="../../TestCookies.php">up</a>&nbsp;<a href="../TestCookies.php">main</a>
		<form action="TestCookiesAction.php">
			<input id="inputTypeText" type="text" name="inputTypeText" style="width: 100%; "/><br/>
			<input type="submit" value="submit"/>
		</form>
	</body>
</html>
