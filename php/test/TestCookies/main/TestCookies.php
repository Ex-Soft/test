<!doctype html>
<html>
<?php
    setcookie("cookie1", "cookie1main", 0, "", "", false, true);
    setcookie("cookie2", "cookie2main");
?>
	<head>
		<meta charset="utf-8" />
		<title>Test Cookies (main)</title>
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
		<h1>main</h1>
		<hr/>
		<p><?php echo "cookie1=\"".$_COOKIE["cookie1"]."\""; ?></p>
		<p><?php echo "cookie2=\"".$_COOKIE["cookie2"]."\""; ?></p>
		<a href="../TestCookies.php">up</a>&nbsp;<a href="down/TestCookies.php">down</a>
		<form action="TestCookiesAction.php">
			<input id="inputTypeText" type="text" name="inputTypeText" style="width: 100%; "/><br/>
			<input type="submit" value="submit"/>
		</form>
	</body>
</html>
