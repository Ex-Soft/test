<%@ Page language="c#" Codebehind="DynamicCheckBox.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.DynamicCheckBox" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Dynamic CheckBox</title>
		<meta content="False" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="common.css" rel="stylesheet">
		<script src="form.js" type="text/javascript"></script>
		<script type="text/javascript">
<!--
function ShowDiv(obj)
{
   var
     div=document.getElementById("divT"),
     DisplayValue,
     SwitchDiv2RadioButton;
     
   switch(obj.value)
   {
      case "on" :
      {
         DisplayValue="block";
         SwitchDiv2RadioButton=document.getElementById("SwitchDIV2_0");
         
         break;
      }
      case "off" :
      {
         DisplayValue="none";
         SwitchDiv2RadioButton=document.getElementById("SwitchDIV2_1");
         
         break;
      }
   }
   
   div.style.display=DisplayValue;
   if(SwitchDiv2RadioButton!=null && SwitchDiv2RadioButton!=undefined)
   {
      SwitchDiv2RadioButton.checked=true;
   }
   else
     alert("SwitchDiv2RadioButton==null || SwitchDiv2RadioButton==undefined");
}

function Test()
{
   var
     div=document.getElementById("divT"),
     r=CheckEmptyDivCheckBox(div),
     l=document.getElementById("Color");

   div.style.backgroundColor = r ? "rgb(255, 191, 191)" : "";
   l.innerHTML=divT.style.backgroundColor;
}

function CategoryChange(objId)
{
}

function DDLChanged(obj)
{
	for(var i=0; i<obj.options.length; ++i)
	{
		if(obj.options[i].text=="")
		{
			obj.remove(i);
			break;
		}
	}
}

function Add()
{
	var
		oTable,
		oTableBody,
		oRow,
		oCell,
		oRadio;
	
	if(!(oTable=document.getElementById("TableRadio")))
		return;

	for(var i=0; i<oTable.childNodes.length; ++i)
		if(oTable.childNodes[i].nodeType==1 && oTable.childNodes[i].nodeName.toLowerCase()=="tbody")
		{
			oTableBody=oTable.childNodes[i];
			break;
		}
		
	if(!oTableBody)
		return;
		
	if(!(oRow=document.createElement("TR")))
		return;
	oTableBody.appendChild(oRow);

	if(!(oCell=document.createElement("TD")))
		return;
	//if(!(oRadio=document.createElement("<INPUT TYPE='RADIO' NAME='<%=SignatureRadio%>' VALUE='<%=SignatureRadio%>1' ID='<%=SignatureRadio%>1' CHECKED>"))) // IE Yes MZ && FF No
	//if(!(oRadio=document.createElement("<INPUT NAME='<%=SignatureRadio%>'>")))  // IE Partly: not set checked MZ && FF No
	//if(!(oRadio=document.createElement("INPUT")))
	//{
	//	alert("!Radio");
	//	return;
	//}
	//oRadio.type="radio";
	//oRadio.name="<%=SignatureRadio%>";
	//oRadio.value="<%=SignatureRadio%>1";
	//oRadio.id="<%=SignatureRadio%>1";
	//oRadio.checked=true;
	oCell.innerHTML="<input type=\"radio\" id=\"<%=SignatureRadio%>1\" name=\"<%=SignatureRadio%>\" value=\"<%=SignatureRadio%>1\" checked>";
	//oCell.appendChild(oRadio);
	oRow.appendChild(oCell);

	if(!(oCell=document.createElement("TD")))
		return;
	//if(!(oRadio=document.createElement("<INPUT TYPE='RADIO' NAME='<%=SignatureRadio%>' VALUE='<%=SignatureRadio%>2' ID='<%=SignatureRadio%>2'>")))
	//if(!(oRadio=document.createElement("<INPUT NAME='<%=SignatureRadio%>'>")))
	//if(!(oRadio=document.createElement("INPUT")))
	//{
	//	alert("!Radio");
	//	return;
	//}
	//oRadio.type="radio";
	//oRadio.name="<%=SignatureRadio%>";
	//oRadio.value="<%=SignatureRadio%>2";
	//oRadio.id="<%=SignatureRadio%>2";
	//oRadio.checked=false;
	oCell.innerHTML="<input type=\"radio\" id=\"<%=SignatureRadio%>2\" name=\"<%=SignatureRadio%>\" value=\"<%=SignatureRadio%>2\">";
	//oCell.appendChild(oRadio);
	oRow.appendChild(oCell);
	
	if(!(oCell=document.createElement("TD")))
		return;
	oCell.innerHTML="<input type=\"text\" id=\"<%=SignatureText%>\" name=\"<%=SignatureText%>\">";
	oRow.appendChild(oCell);

	if(!(oCell=document.createElement("TD")))
		return;
	oCell.innerHTML="<input type=\"checkbox\" id=\"<%=SignatureCheckBox%>\" name=\"<%=SignatureCheckBox%>\">";
	oRow.appendChild(oCell);
}
// -->
		</script>
	</HEAD>
	<body>
		<form id="DynamicCheckBoxForm" method="post" runat="server">
			<fieldset><legend>&nbsp;DIV&nbsp;</legend>
				<input type="radio" name="SwitchDIV" id="SwitchDIVOn" value="on" onclick="ShowDiv(this)" runat="server">On
				<input type="radio" name="SwitchDIV" id="SwitchDIVOff" value="off" onclick="ShowDiv(this)" checked runat="server">Off
				<asp:radiobuttonlist id="SwitchDIV2" runat="server" RepeatDirection="Horizontal">
					<asp:ListItem runat="server" Value="on">On</asp:ListItem>
					<asp:ListItem runat="server" Value="off" Selected="true">Off</asp:ListItem>
				</asp:radiobuttonlist>
				<asp:DropDownList ID="DDLSwitch" onchange="DDLChanged(this)" Runat="server" />
			</fieldset>
			<table class="GroupBox" style="WIDTH: 100%" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td>
						<fieldset><legend>&nbsp;Legend&nbsp;</legend>
							<div id="divT" style="DISPLAY: none" runat="server">
								<table class="GroupBox" style="WIDTH: 100%" cellSpacing="0" cellPadding="0" border="0">
									<tr>
										<asp:literal id="VehicleTypes" runat="server"></asp:literal>
									</tr>
									<tr>
										<asp:literal id="VehicleTypesS" runat="server"></asp:literal>
									</tr>
								</table>
							</div>
						</fieldset>
					</td>
				</tr>
			</table>
			<table id="TableRadio" border="1" runat="server">
				<tr>
					<td colspan="4"><input type="button" id="btnAdd" name="btnAdd" value="Add" onclick="Add()"></td>
				</tr>
			</table>
			<asp:PlaceHolder ID="PlaceHolder4CheckBoxDynamicServer" Runat="server" />
			<hr>
			<input type="checkbox" id="ChekBox__1" name="ChekBox__1" checked disabled>&nbsp;<input onclick="Test()" type="button" value="Test">&nbsp;<label id="Color"></label><br>
			<input type="submit" value="Submit"><br>
			<hr>
			<p><asp:Label id="ParagraphRequest" runat="server"></asp:Label></p>
		</form>
	</body>
</HTML>
