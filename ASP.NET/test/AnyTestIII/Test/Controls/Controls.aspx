<%@ Import Namespace=System.Data %>
<%@ Page CodeBehind="Controls.aspx.cs" Language="c#" AutoEventWireup="false" Inherits="AnyTest.Controls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<head>
		<title>Test ASP.NET Controls</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="Controls.css" rel="stylesheet" type="text/css">
		<script src="Controls.js" type="text/javascript"></script>
		<script type="text/javascript">
<!--
function ShowLocation()
{
	alert("document.location=\""+document.location+"\"");
	alert("document.location.href=\""+document.location.href+"\"");
	alert("document.location.host=\""+document.location.host+"\"");
	alert("document.location.hostname=\""+document.location.hostname+"\"");
	alert("document.location.pathname=\""+document.location.pathname+"\"");
	alert("document.location.protocol=\""+document.location.protocol+"\"");
	alert("document.URL=\""+document.URL+"\"");
	alert("document.baseURI=\""+document.baseURI+"\"");
	alert("document.domain=\""+document.domain+"\"");
	alert("document.documentURI=\""+document.documentURI+"\"");
}

function DoCheckBoxListShow(oTable)
{
   var
     Ctrls=oTable.getElementsByTagName("input");
     
   for(var i=0; i<Ctrls.length; ++i)
      alert(Ctrls[i].id);
}

function DropDownListOnChange()
{
	var
		Ctrl;

	if(Ctrl=document.getElementById("<%=DropDownList1.ClientID%>"))
		alert(Ctrl.value);
}
// -->
		</script>
	</head>
	<body onload="Page_Load()">
		<form id="MainForm" runat="server">
			<div id="DivPageLoadInfo" class="div_upper_hidden" onmouseover="this.className='div_upper_visible'" onmouseout="this.className='div_upper_hidden'">
				Started&nbsp;at&nbsp;<span id="SpanStarted" class="PageLoadInfoCSS"></span>&nbsp;Finished&nbsp;at&nbsp;<span id="SpanFinished" class="PageLoadInfoCSS"></span>&nbsp;Has&nbsp;been&nbsp;loaded&nbsp;in&nbsp;<span id="SpanDiffTime" class="PageLoadInfoCSS"></span>&nbsp;second(s)
			</div>
			<asp:Literal ID="LiteralWVS" Runat="server" />
			<asp:Literal ID="LiteralWOVS" EnableViewState="false" Runat="server" />
			<asp:Literal ID="VarDef" runat="server" />
			<asp:Label id="LabelPage" runat="server" /><br>
			<a href="E:\ReadFile_2006_06_29_02.rar">Download</a><br>
			<input id="HtmlButtonSubmit" type="submit" value='HTML INPUT TYPE="SUBMIT"' runat="server">&nbsp;
			<input type="button" id="HTMLButton" value="<%= HTMLButtonValue %>" onclick="ShowLocation()">&nbsp;
			<input type="button" id="HTMLButtonSubmit1" value="HTMLButton Submit" onclick="document.forms[0].submit()">&nbsp;
			<input type="button" id="HTMLButtonSubmit2" value="HTMLButton Submit" onclick="document.getElementById('MainForm').submit()"><br>
			<asp:label id="LabelInfoMsg" runat="server" text="Info: " title="In&#x0A;fo: "></asp:label><br>
			<asp:label id="LabelInfo" runat="server" text="LabelInfo"></asp:label><br>
			<asp:label id="LabelStaticValue" runat="server"></asp:label><br>
			<asp:label id="LabelApplication" runat="server"></asp:label><br>
			<asp:label id="LabelEnvironmentCurrentDirectory" runat="server">Environment.CurrentDirectory:&nbsp;</asp:label>
			<hr>
			NewDynamicTable<br>
			<asp:table id="NewDynamicTable" runat="server" BorderColor="blue" BorderWidth="1"></asp:table>
			<hr>
			<a id="AnchorTestDoPostBack" href="#" onclick="__doPostBack('eventTarget','eventArgument');return(false);">Test __doPostBack()</a>
			<hr />
			<asp:table id="TestTable" runat="server" HorizontalAlign="Center" CellSpacing="10" CellPadding="5"
				BorderStyle="Dotted" BackColor="Yellow" BorderColor="Teal" GridLines="Both" BorderWidth="5">
				<ASP:TABLEROW>
					<ASP:TABLEHEADERCELL Text="Страховий&amp;nbsp;платіж" RowSpan="2"></ASP:TABLEHEADERCELL>
					<ASP:TABLEHEADERCELL Text="Сплачений" ColumnSpan="5"></ASP:TABLEHEADERCELL>
					<ASP:TABLEHEADERCELL Text="#&amp;nbsp;Платіжного&amp;nbsp;документу" RowSpan="2"></ASP:TABLEHEADERCELL>
				</ASP:TABLEROW>
				<ASP:TABLEROW>
					<ASP:TABLEHEADERCELL Text="ГГ"></ASP:TABLEHEADERCELL>
					<ASP:TABLEHEADERCELL Text="ХХ"></ASP:TABLEHEADERCELL>
					<ASP:TABLEHEADERCELL Text="ДД"></ASP:TABLEHEADERCELL>
					<ASP:TABLEHEADERCELL Text="ММ"></ASP:TABLEHEADERCELL>
					<ASP:TABLEHEADERCELL Text="РРРР"></ASP:TABLEHEADERCELL>
				</ASP:TABLEROW>
			</asp:table><br>
			<div id="TestDiv" style="DISPLAY: block" runat="server">DIV STYLE:&nbsp;<asp:label id="DivLabelInfo" runat="server"></asp:label>
			</div>
			<br>
			<asp:label id="LabelInfo1" runat="server" Font-Bold="True" ForeColor="Blue">Label+TextBox</asp:label><br>
			<asp:label id="Label1" runat="server">Label1-&gt;TextBox1 </asp:label><asp:textbox id="TextBox1" runat="server" BackColor="Blue" Font-Bold="true" ForeColor="White"
				AutoPostBack="true">TextBox1</asp:textbox>&nbsp;<%=TextBox1.ID%><br>
			<asp:label id="Label2" runat="server">Label2-&gt;TextBox2 (password) </asp:label><asp:textbox id="TextBox2" runat="server" AutoPostBack="true" textmode="password">TextBox2</asp:textbox><br>
			<asp:label id="Label3" runat="server">Label3-&gt;TextBox3 </asp:label><asp:textbox id="TextBox3" style="FONT-WEIGHT: bold; COLOR: white; BACKGROUND-COLOR: blue" runat="server"
				AutoPostBack="true" textmode="multiline" rows="10">TextBox3</asp:textbox><br>
			<asp:Label ID="LabelTextBoxReadOnly" Runat="server">LabelTextBoxReadOnly-&gt;TextBoxReadOnly</asp:Label>
			<asp:TextBox ID="TextBoxReadOnly" ReadOnly="True" Runat="server" /><br>
			<hr>
			<br>
			<asp:label id="LabelInfo2" runat="server" Font-Bold="True" ForeColor="Blue">HyperLink</asp:label><br>
			<asp:hyperlink id="HyperLink1" runat="server" Target="_new" NavigateUrl="../others/simplecalc/simplecalc.aspx">Simple Calc</asp:hyperlink><br>
			<asp:hyperlink id="HyperLink2" runat="server" Target="_new" NavigateUrl="../others/simplecalc/simplecalc.aspx"
				ImageUrl="images/27265.gif"></asp:hyperlink>
			<hr>
			<br>
			<asp:label id="LabelInfo3" runat="server" Font-Bold="True" ForeColor="Blue">Image</asp:label><br>
			<asp:image id="Image1" runat="server" ImageUrl="images/abuse.gif" AlternateText="Can't find 'abuse.gif'" />
			<img src="images/abuse.gif" alt="Can't find 'abuse.gif'" title="Can't find 'abuse.gif'" onclick="alert('1')" border="0" style="cursor: pointer; ">
			<hr>
			<br>
			<asp:label id="LabelInfo4" runat="server" Font-Bold="True" ForeColor="Blue">CheckBox</asp:label><br>
			<asp:checkbox id="CheckBox1" text="CheckBox1" AutoPostBack="true" runat="server"></asp:checkbox>&nbsp;<asp:checkbox id="CheckBox1Disabled" text="CheckBox1Disabled" enabled="false" runat="server"></asp:checkbox>&nbsp;<asp:CheckBox ID="CheckBox1ReadOnly" Text="CheckBox1ReadOnly" readonly="true" Runat="server"></asp:CheckBox>
			<hr>
			<br>
			<asp:label id="LabelInfo5" runat="server" Font-Bold="True" ForeColor="Blue">RadioButton</asp:label><br>
			<asp:radiobutton id="RadioButton1" runat="server" text="Red" AutoPostBack="true" checked="true" GroupName="Colors"></asp:radiobutton><br>
			<asp:radiobutton id="RadioButton2" runat="server" text="Green" AutoPostBack="true" GroupName="Colors"></asp:radiobutton><br>
			<asp:radiobutton id="RadioButton3" runat="server" text="Blue" AutoPostBack="true" GroupName="Colors"></asp:radiobutton>
			<hr>
			<br>
			<asp:label id="LabelInfo6" runat="server" Font-Bold="True" ForeColor="Blue">Table</asp:label><br>
			<asp:table id="Table1" runat="server" BorderStyle="Double" GridLines="Both" BorderWidth="1px">
				<ASP:TABLEROW>
					<ASP:TABLECELL Text="Row 1, Column 1"></ASP:TABLECELL>
					<ASP:TABLECELL Text="Row 1, Column 2"></ASP:TABLECELL>
				</ASP:TABLEROW>
				<ASP:TABLEROW>
					<ASP:TABLECELL Text="Row 2, Column 1"></ASP:TABLECELL>
					<ASP:TABLECELL Text="Row 2, Column 2"></ASP:TABLECELL>
				</ASP:TABLEROW>
			</asp:table><br>
			<asp:table id="Table2" runat="server" BorderStyle="Double" GridLines="Both" BorderWidth="1px"></asp:table>
			<hr>
			<br>
			<asp:label id="LabelInfo7" runat="server" Font-Bold="True" ForeColor="Blue">Panel</asp:label><br>
			<asp:checkbox id="CheckBox2" runat="server" text="Show Labels on Panel" AutoPostBack="true" Checked="true"></asp:checkbox><br>
			<asp:panel id="Panel1" runat="server">
				<ASP:LABEL id="Label1P" runat="server">Label# 1 (on Panel)</ASP:LABEL><BR>
				<ASP:LABEL id="Label2P" runat="server">Label# 2 (on Panel)</ASP:LABEL><BR>
				<ASP:LABEL id="Label3P" runat="server">Label# 3 (on Panel)</ASP:LABEL><BR>
				<ASP:LABEL id="Label4P" runat="server">Label# 4 (on Panel)</ASP:LABEL>
			</asp:panel>
			<br>
			<fieldset><legend>&nbsp;Show Labels on Panel&nbsp;<asp:CheckBox id="CheckBox2_1" Checked="true" AutoPostBack="true" runat="server" /></legend>
				<asp:Panel ID="Panel1_1" Runat="server">
					<asp:Label ID="Label1P_1" Runat="server">Label# 1 (on Panel)</asp:Label><br>
					<asp:Label ID="Label2P_1" Runat="server">Label# 2 (on Panel)</asp:Label><br>
					<asp:Label ID="Label3P_1" Runat="server">Label# 3 (on Panel)</asp:Label><br>
					<asp:Label ID="Label4P_1" Runat="server">Label# 4 (on Panel)</asp:Label><br>
				</asp:Panel>
			</fieldset>
			<hr>
			<br>
			<asp:label id="LabelInfo8" Font-Bold="True" ForeColor="Blue" runat="server">Button</asp:label><br>
			<asp:button id="Button1" Text="Button" runat="server" />
			<asp:button id="Button2" Text="Button" style="background-color: blue; " onmouseover="this.style.backgroundColor='red'" onmouseout="this.style.backgroundColor='blue'" runat="server" />
			<asp:Button ID="Button3" Text="Button" Runat="server" />
			<asp:Button ID="Button4" Text="Button with Confirm" Runat="server" />
			<hr>
			<br>
			<asp:label id="LabelInfo9" runat="server" Font-Bold="True" ForeColor="Blue">LinkButton</asp:label><br>
			<asp:linkbutton id="LinkButton1" runat="server">LinkButton</asp:linkbutton><br>
			<asp:linkbutton id="LinkButton2" Enabled="False" runat="server">LinkButton (Enabled="False")</asp:linkbutton>
			<hr>
			<br>
			<asp:label id="LabelInfo10" runat="server" Font-Bold="True" ForeColor="Blue">ImageButton</asp:label><br>
			<asp:imagebutton id="ImageButton1" title="title" runat="server" ImageUrl="images/wall.gif" />
			<asp:imagebutton id="ImageButton2" runat="server" ImageUrl="images/27265.gif" title="title" AlternateText="Can't find '27265.gif'" />
			<asp:ImageButton ID="ImageButton3" ImageUrl="images/wall.gif" onmouseover="this.src='images/abuse.gif'" onmouseout="this.src='images/wall.gif'" Runat="server" />
			<asp:ImageButton ID="ImageButton4" ImageUrl="images/rulez.gif" title="Can't find 'rulez.gif'" AlternateText="Can't find 'rulez.gif'" BorderWidth="0" Runat="server" />
			<asp:ImageButton ID="ImageButton5" ImageUrl="images/wall.gif" title="asp:ImageButton without submit" Runat="server" />
			<hr>
			<br>
			<asp:label id="LabelInfo11" runat="server" Font-Bold="True" ForeColor="Blue">ListBox</asp:label><br>
			<asp:listbox id="ListBox1" runat="server">
				<ASP:LISTITEM runat="server" text="ListBox1ListItem1" />
				<ASP:LISTITEM runat="server" text="ListBox1ListItem2" selected="true" />
				<ASP:LISTITEM runat="server" text="ListBox1ListItem3" />
				<ASP:LISTITEM runat="server" text="ListBox1ListItem4" />
				<ASP:LISTITEM runat="server" text="ListBox1ListItem5" />
			</asp:listbox>
			<asp:ListBox ID="ListBox1_2" Runat="server">
				<asp:ListItem Value="1">1st</asp:ListItem>
				<asp:ListItem Value="2">2nd</asp:ListItem>
				<asp:ListItem Value="3">3rd</asp:ListItem>
				<asp:ListItem Value="4">4th</asp:ListItem>
			</asp:ListBox>
			<asp:ListBox ID="ListBox1_3" SelectionMode="Multiple" Runat="server">
				<asp:ListItem Value="1">1st</asp:ListItem>
				<asp:ListItem Value="2">2nd</asp:ListItem>
				<asp:ListItem Value="3">3rd</asp:ListItem>
				<asp:ListItem Value="4">4th</asp:ListItem>
			</asp:ListBox>
			<hr>
			<br>
			<asp:label id="LabelInfo12" runat="server" Font-Bold="True" ForeColor="Blue">DropDownList</asp:label><br>
			<asp:dropdownlist id="DropDownList1" onchange="DropDownListOnChange()" runat="server">
				<asp:listitem runat="server" value="1" text="DropDownList1ListItem1" />
				<asp:listitem runat="server" value="2" text="DropDownList1ListItem2" />
				<asp:listitem runat="server" value="3" text="DropDownList1ListItem3" selected="true" />
				<asp:listitem runat="server" value="4" text="DropDownList1ListItem4" />
				<asp:listitem runat="server" value="5" text="DropDownList1ListItem5" />
				<asp:listitem runat="server" value="6" text="DropDownList1ListItem6" />
			</asp:dropdownlist> (with alert)<br>
			<asp:dropdownlist id="DropDownListDate" runat="server" /> (with dblclick)<br>
			<asp:DropDownList ID="DropDownListTestDataBind" Runat="server" /><br>
			<asp:DropDownList ID="DropDownListTestDataBindII" Runat="server" /><br>
			<asp:DropDownList ID="DropDownListEnabledDisabled" Runat="server">
				<asp:ListItem value="1" text="1st" />
				<asp:ListItem value="2" text="2nd" selected="true" />
				<asp:ListItem value="3" text="3rd" />
				<asp:ListItem value="4" text="4th" />
				<asp:ListItem value="5" text="5th" />
			</asp:DropDownList>
			<input type="button" value="Enabled/Disabled" onclick="document.getElementById('DropDownListEnabledDisabled').disabled=!document.getElementById('DropDownListEnabledDisabled').disabled">
			<asp:Label ID="LabelDropDownListEnabledDisabled" Runat="server" />
			<hr>
			<br>
			<asp:label id="LabelInfo13" runat="server" Font-Bold="True" ForeColor="Blue">CheckBoxList</asp:label><br><hr>
			<asp:checkboxlist id="CheckBoxList1" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
				<ASP:LISTITEM runat="server" text="CheckBoxList1ListItem1" />
				<ASP:LISTITEM runat="server" text="CheckBoxList1ListItem2" />
				<ASP:LISTITEM runat="server" text="CheckBoxList1ListItem3" />
				<ASP:LISTITEM runat="server" text="CheckBoxList1ListItem4" />
				<ASP:LISTITEM runat="server" text="CheckBoxList1ListItem5" />
				<ASP:LISTITEM runat="server" text="CheckBoxList1ListItem6" />
				<ASP:LISTITEM runat="server" text="CheckBoxList1ListItem7" selected="true" />
			</asp:checkboxlist>
			<input type="button" id="ButtonCheckBoxList1Show" name="ButtonCheckBoxList1Show" value="Show" onclick="DoCheckBoxListShow(document.getElementById('CheckBoxList1'))"><br><hr>
			<asp:checkboxlist id="CheckBoxList2" runat="server" RepeatColumns="3" RepeatDirection="Vertical">
				<ASP:LISTITEM runat="server" text="CheckBoxList2ListItem1" />
				<ASP:LISTITEM runat="server" text="CheckBoxList2ListItem2" />
				<ASP:LISTITEM runat="server" text="CheckBoxList2ListItem3" />
				<ASP:LISTITEM runat="server" text="CheckBoxList2ListItem4" />
				<ASP:LISTITEM runat="server" text="CheckBoxList2ListItem5" selected="true" />
				<ASP:LISTITEM runat="server" text="CheckBoxList2ListItem6" />
				<ASP:LISTITEM runat="server" text="CheckBoxList2ListItem7" />
			</asp:checkboxlist>
			<hr>
			<br>
			<asp:label id="LabelInfo14" runat="server" Font-Bold="True" ForeColor="Blue">Properties</asp:label><br>
			RepeatLayout:
			<asp:dropdownlist id="DropDownListRepeatLayout" runat="server" autopostback="true">
				<ASP:LISTITEM runat="server" text="Table" />
				<ASP:LISTITEM runat="server" text="Flow" />
			</asp:dropdownlist><br>
			RepeatDirection:
			<asp:dropdownlist id="DropDownListRepeatDirection" runat="server" autopostback="true">
				<ASP:LISTITEM runat="server" text="Vertical" />
				<ASP:LISTITEM runat="server" text="Horizontal" />
			</asp:dropdownlist><br>
			RepeatColumns:
			<asp:textbox id="TextBoxRepeatColumns" runat="server" text="1" autopostback="true"></asp:textbox><br>
			CellSpacing:
			<asp:textbox id="TextBoxCellSpacing" runat="server" text="1" autopostback="true"></asp:textbox><br>
			CellPadding:
			<asp:textbox id="TextBoxCellPadding" runat="server" text="1" autopostback="true"></asp:textbox><br>
			<asp:radiobuttonlist id="RadioButtonList1" runat="server">
				<ASP:LISTITEM runat="server" text="RadioButtonList1ListItem1" />
				<ASP:LISTITEM runat="server" text="RadioButtonList1ListItem2" />
				<ASP:LISTITEM runat="server" text="RadioButtonList1ListItem3" selected="true" />
				<ASP:LISTITEM runat="server" text="RadioButtonList1ListItem4" />
				<ASP:LISTITEM runat="server" text="RadioButtonList1ListItem5" />
				<ASP:LISTITEM runat="server" text="RadioButtonList1ListItem6" />
			</asp:radiobuttonlist>
			<hr>
			<br>
			<asp:label id="LabelInfo15" runat="server" Font-Bold="True" ForeColor="Blue">ListBox from XML</asp:label><br>
			<asp:listbox id="ListBox2" runat="server"></asp:listbox>
			<hr>
			<br>
			<TABLE id="MainTable" cellSpacing="3" cellPadding="8" width="100%" bgColor="deepskyblue"
				border="2" runat="server">
				<TR id="Row1" runat="server">
					<TD id="Cell11" width="94" runat="server"><asp:label id="LabelSpan" runat="server">Span</asp:label></TD>
					<TD id="Cell12" width="160" runat="server"><asp:textbox id="TextBoxInput" runat="server">input</asp:textbox></TD>
					<TD id="Cell13" width="119" runat="server"><asp:radiobutton id="TableRadioButton1" runat="server" GroupName="MyChoice"></asp:radiobutton><asp:radiobutton id="TableRadioButton2" runat="server" GroupName="MyChoice"></asp:radiobutton></TD>
					<TD id="Cell14" runat="server"><asp:button id="TableButton1" runat="server" Text="Button"></asp:button></TD>
				</TR>
				<TR id="Row2" runat="server">
					<TD id="Cell21" width="94" runat="server"><asp:dropdownlist id="TableDropDownList" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
					<TD id="Cell22" width="160" runat="server"><asp:listbox id="TableListBox" runat="server" AutoPostBack="True"></asp:listbox></TD>
					<TD id="Cell23" width="119" runat="server"><asp:hyperlink id="TableHyperLink1" runat="server" ImageUrl="images/wall.gif">HyperLink</asp:hyperlink></TD>
					<TD id="Cell24" runat="server"><asp:checkbox id="TableCheckBox1" runat="server"></asp:checkbox><asp:checkbox id="TableCheckBox2" runat="server"></asp:checkbox></TD>
				</TR>
			</TABLE>
			<P><asp:label id="LabelHidden" runat="server">Hidden_</asp:label><input id="Hidden1" type="hidden" runat="server">_
				<asp:label id="LabelFile" runat="server">File </asp:label><input id="File1" type="file" runat="server"></P>
			<P><asp:label id="LabelLabelStatus" runat="server">Label Status: </asp:label><asp:label id="LabelStatus" runat="server"></asp:label></P>
			<P><asp:table id="WebTable" runat="server" BorderStyle="Double" GridLines="Both" BorderWidth="1px"></asp:table></P>
			<P><asp:listbox id="ListBoxAdd1" runat="server"></asp:listbox><asp:listbox id="ListBoxAdd2" runat="server"></asp:listbox></P>
			<table border="1">
				<tr>
					<td><asp:TextBox ID="TextBoxWOnKeyUp" onkeyup="document.getElementById('Label4TextBoxWOnKeyUp').innerHTML=this.value" Runat="server" /></td>
					<td><asp:Label id="Label4TextBoxWOnKeyUp" Runat="server" /></td>
				</tr>
			</table>
			<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
				<tr>
					<td>
						<input type="radio" id="HtmlOnlyRadio1" name="HtmlOnlyRadio" value="HtmlOnlyRadio1">HtmlOnlyRadio1<br>
						<input type="radio" id="HtmlOnlyRadio2" name="HtmlOnlyRadio" value="HtmlOnlyRadio2" checked>HtmlOnlyRadio2<br>
						<input type="radio" id="HtmlOnlyRadio3" name="HtmlOnlyRadio" value="HtmlOnlyRadio3">HtmlOnlyRadio3
					</td>
					<td>
						<input type="radio" id="HtmlRunatServerRadio1" name="HtmlRunatServerRadio" value="HtmlRunatServerRadio1" runat="server">HtmlRunatServerRadio1<br>
						<input type="radio" id="HtmlRunatServerRadio2" name="HtmlRunatServerRadio" value="HtmlRunatServerRadio2" checked runat="server">HtmlRunatServerRadio2<br>
						<input type="radio" id="HtmlRunatServerRadio3" name="HtmlRunatServerRadio" value="HtmlRunatServerRadio3" runat="server">HtmlRunatServerRadio3
					</td>
				</tr>
			</table>
			<table style="width: 100%; " cellspacing="0" cellpadding="0" border="0">
				<tr>
					<td>
						<asp:ListBox ID="ListBoxWithDblClick" ondblclick="document.getElementById('TextBoxDest').value=this.options[this.selectedIndex].text+'\r\n2nd'" Runat="server">
							<asp:ListItem Value="1">1st</asp:ListItem>
							<asp:ListItem Value="2">2nd</asp:ListItem>
							<asp:ListItem Value="3">3rd</asp:ListItem>
						</asp:ListBox>
					</td>
					<td><asp:TextBox ID="TextBoxDest" TextMode="MultiLine" Runat="server" /></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>