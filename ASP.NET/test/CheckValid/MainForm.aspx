<%@ Page language="c#" Codebehind="MainForm.aspx.cs" AutoEventWireup="false" Inherits="CheckValid.MainForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MainForm</title>
		<meta content="False" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="tab.winclassic.css" rel="stylesheet">
		<script src="tabpane.js" type="text/javascript"></script>
		<script src="misc.js" type="text/javascript"></script>
		<script type="text/javascript">
<!--
function CheckValid(aWin,aInvalidColor)
{
	CheckEmptyType(aWin,aInvalidColor);
}

function CheckForm(aWin,aInvalidColor,aStr)
{
	alert(aStr);	

	CheckValid(aWin,aInvalidColor);
	if(!FlashControl(aWin,aInvalidColor))
	  return(false);

	alert('oB# 1!!!');

	for(var iFrame=0; iFrame<aWin.frames.length; ++iFrame)
	   for(var iForm=0; iForm<aWin.frames[iFrame].document.forms.length; ++iForm)
			aWin.frames[iFrame].document.forms[iForm].submit();
	
	alert('oB# 2!!!');
	return(true);
}

function TabSet()
{
   var
     TabNoInput=document.getElementById("inpTabIdx"),
     TabNo;
     
   TabNo=parseInt(TabNoInput.value);
   if(!isNaN(TabNo) && TabNo>=0 && TabNo<tp.pages.length)
   {
		tp.pages[TabNo].select();
   }
}

function TestSubmit()
{
   var
     result,
     str="MainForm.onsubmit";

   alert(str);
   result=CheckForm(window,InvalidColor,'MainForm');
   alert(str+"="+result);
   return(result);
}
// -->
		</script>
	</HEAD>
	<body onload="PrepareForm()">
		<form id="MainForm" onsubmit="return TestSubmit()" method="post" runat="server">
			<asp:literal id="VarDef" runat="server"></asp:literal><asp:textbox id="TextBox1" runat="server" />&nbsp;<asp:label id="TextBox1Value" runat="server" /><br>
			<asp:textbox id="TextBox2" runat="server" />&nbsp;<asp:label id="TextBox2Value" runat="server" /><br>
			<asp:textbox id="TextBox3" runat="server" />&nbsp;<asp:label id="TextBox3Value" runat="server" /><br>
			<asp:DropDownList id="DropDownList1" runat="server" onchange="DDLChanged('DropDownList1')" />&nbsp;<asp:label id="DropDownListValue" runat="server" />
			<div id="DivStandalone1" style="WIDTH: 100%; HEIGHT: 15%">
				<iframe id="IFrameStandalone1" name="IFrameStandalone1" src="iframe.aspx" width="100%" height="100%">
				</iframe>
			</div>
			<div class="tab-pane" id="tabPanel">
				<script type="text/javascript">
<!--
tp=new WebFXTabPane(document.getElementById("tabPanel"));
// -->
				</script>
				<!--TAB1-->
				<div class="tab-page" id="tabPage1">
					<h2 class="tab">Tab#1</h2>
					<script type="text/javascript">
<!--
tp.addTabPage(document.getElementById("tabPage1"));
// -->
					</script>
					<iframe id="TAB1" name="TAB1" style="BORDER-RIGHT: 0px solid; BORDER-TOP: 0px solid; BORDER-LEFT: 0px solid; WIDTH: 100%; BORDER-BOTTOM: 0px solid; HEIGHT: 100%"
						src="iframe1.aspx"></iframe>
				</div>
				<!--TAB2-->
				<div class="tab-page" id="tabPage2">
					<h2 class="tab">Tab#2</h2>
					<script type="text/javascript">
<!--
tp.addTabPage(document.getElementById("tabPage2"));
// -->
					</script>
					<iframe id="TAB2" name="TAB2" style="BORDER-RIGHT: 0px solid; BORDER-TOP: 0px solid; BORDER-LEFT: 0px solid; WIDTH: 100%; BORDER-BOTTOM: 0px solid; HEIGHT: 100%"
						src="iframe2.aspx"></iframe>
				</div>
				<!--TAB3-->
				<div class="tab-page" id="tabPage3">
					<h2 class="tab">Tab#3</h2>
					<script type="text/javascript">
<!--
tp.addTabPage(document.getElementById("tabPage3"));
// -->
					</script>
					<asp:textbox id="TabPage3TextBox1" runat="server" />&nbsp;<asp:label id="TabPage3TextBox1Value" runat="server" /><br>
					<asp:textbox id="TabPage3TextBox2" runat="server" />&nbsp;<asp:label id="TabPage3TextBox2Value" runat="server" /><br>
					<asp:textbox id="TabPage3TextBox3" runat="server" />&nbsp;<asp:label id="TabPage3TextBox3Value" runat="server" /><br>
				</div>
				<script type="text/javascript">
<!--
setupAllTabs();
// -->
				</script>
			</div>
			<input id="inpTabIdx" type="text" name="inpTabIdx">&nbsp;<input id="btnTabSet" onclick="TabSet()" type="button" value="Set" name="btnTabSet"><br>
			<asp:Button id="ButtonSubmit" runat="server" Text="Submit"></asp:Button><br>
			<asp:Label id="LabelInfo" runat="server"></asp:Label></form>
	</body>
</HTML>
