<!doctype html>
<html>
	<head>
		<meta charset="utf-8" />
		<title>Test Cookies Action (up)</title>
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
		<form>
			<input id="inputTypeText" type="text" name="inputTypeText" style="width: 100%; "/>
		</form>
	</body>
</html>
