<%@ Page language="c#" Codebehind="SubmitTestFormIII.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.SubmitTestFormIII" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251" />
		<title>Submit TestForm III</title>
		<meta name="vs_snapToGrid" content="False" />
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
		<script type="text/javascript">
<!--
function SubmitForm()
{
	ToLog('SubmitForm (before)');
	//document.forms[0].submit();
	//document.forms["SubmitTestFormIII"].submit();
	document.getElementById("SubmitTestFormIII").submit();
	ToLog('SubmitForm (after)');
	alert('SubmitForm (after)');
	return(document.getElementById("HtmlInputCheckBoxSubmitEnabled").checked);
}

function ToLog(msg)
{
	document.getElementById("Log").value+=msg+"\r\n";
}
// -->
		</script>
	</HEAD>
	<body>
		<form id="SubmitTestFormIII" onsubmit="ToLog('onsubmit (before)');return(SubmitForm());ToLog('onsubmit (after)');alert('onsubmit (after)');" method="post" runat="server">
			<input type="checkbox" id="HtmlInputCheckBoxSubmitEnabled" runat="server" />Submit&nbsp;enabled<br />
			<input type="text" id="HtmlInputText" runat="server" /><br />
			<input type="submit" id="HtmlSubmit" value="HtmlSubmit" runat="server" /><br />
			<input type="button" id="HtmlInputButton" value="HtmlInputButton" onclick="ToLog('HtmlInputButton (before)');SubmitForm();ToLog('HtmlInputButton (after)');alert('HtmlInputButton (after)');" runat="server" /><br />
			<button type="button" id="HtmlButton" value="HtmlButton" onclick="ToLog('HtmlButton (before)');SubmitForm();ToLog('HtmlButton (after)');alert('HtmlButton (after)');">HtmlButton</button><br />
			<a href="#" onclick="ToLog('a (before)');SubmitForm();ToLog('a (after)');alert('a (after)')">Submit</a><br />
			<textarea id="Log" cols="60" rows="17" readonly runat="server"></textarea>
		</form>
	</body>
</HTML>
