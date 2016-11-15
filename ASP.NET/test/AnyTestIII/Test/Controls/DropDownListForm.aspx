<%@ Page language="c#" Codebehind="DropDownListForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.DropDownListForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DropDownList Form</title>
		<meta name="vs_snapToGrid" content="False">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script type="text/javascript">
<!--
function ModifyDropDownListDynamic()
{
   var
     Ctrl,
     opt,
     i;

   if(!(Ctrl=document.getElementById("DropDownListDynamic")))
     return;

   for(i=Ctrl.options.length; i>0; --i)
      Ctrl.remove(0);

   for(i=0; i<10; ++i)
   {
      opt=new Option(i,i);
      Ctrl.options.add(opt,Ctrl.options.length);
   }
}

function ModifyDropDownListDynamicII()
{
   var
     Ctrl,
     opt,
     i;

   if(!(Ctrl=document.getElementById("DropDownListDynamicII")))
     return;

   Ctrl.options.length=0;

   for(i=10; i<13; ++i)
   {
      opt=new Option(i,i);
      Ctrl.options.add(opt,Ctrl.options.length);
   }
}

function ModifyDropDownListDynamicIII()
{
   var
     Ctrl,
     opt,
     i;

   if(!(Ctrl=document.getElementById("DropDownListDynamicIII")))
     return;

   Ctrl.options.length=0;

   for(i=20; i<30; ++i)
   {
      opt=new Option(i,i);
      Ctrl.options.add(opt,Ctrl.options.length);
   }
}

function FillDDL(value)
{
   var
     Ctrl,
     opt,
     i;

   if(!(Ctrl=document.getElementById("DropDownListChild")))
     return;

   Ctrl.options.length=0;

   for(i=1; i<5; ++i)
   {
      opt=new Option(value*11*i,value*11*i);
      Ctrl.options.add(opt,Ctrl.options.length);
   }
}
// -->
		</script>
	</HEAD>
	<body>
		<form id="DropDownListForm" method="post" runat="server">
			<table cellspacing="0" cellpadding="0" border="1" style="width: 100%; ">
				<tr>
					<td colspan="2"><asp:DropDownList id="DropDownListTest" AutoPostBack="true" runat="server" /></td>
				</tr>
				<tr>
					<td>DropDownList.SelectedIndex=</td>
					<td><asp:Label id="LabelDropDownListTestSelectedIndex" runat="server" /></td>
				</tr>
				<tr>
					<td>DropDownList.SelectedValue=</td>
					<td><asp:Label id="LabelDropDownListTestSelectedValue" runat="server" /></td>
				</tr>
				<tr>
					<td>Request.Form.GetValues(DropDownList.ID)=</td>
					<td><asp:Label id="LabelRequestFormDropDownListTestID" runat="server" /></td>
				</tr>
				<tr>
					<td colspan="2"><asp:Button id="ButtonSubmit" Text="Do It!" runat="server" /></td>
				</tr>
				<tr>
					<td><asp:DropDownList ID="DropDownListDynamic" Runat="server" /></td>
					<td><input type="button" id="btnModify" name="btnModify" value="Modify" onclick="ModifyDropDownListDynamic()"></td>
				</tr>
				<tr>
					<td>DropDownList.SelectedIndex=</td>
					<td><asp:Label id="LabelDropDownListDynamicSelectedIndex" runat="server" /></td>
				</tr>
				<tr>
					<td>DropDownList.SelectedValue=</td>
					<td><asp:Label id="LabelDropDownListDynamicSelectedValue" runat="server" /></td>
				</tr>
				<tr>
					<td>Request.Form.GetValues(DropDownList.ID)=</td>
					<td><asp:Label id="LabelRequestFormDropDownListDynamicID" runat="server" /></td>
				</tr>
				<tr>
					<td><asp:DropDownList ID="DropDownListDynamicII" Runat="server" /></td>
					<td><input type="button" id="btnModifyII" name="btnModifyII" value="Modify" onclick="ModifyDropDownListDynamicII()"></td>
				</tr>
				<tr>
					<td>DropDownList.SelectedIndex=</td>
					<td><asp:Label id="LabelDropDownListDynamicIISelectedIndex" runat="server" /></td>
				</tr>
				<tr>
					<td>DropDownList.SelectedValue=</td>
					<td><asp:Label id="LabelDropDownListDynamicIISelectedValue" runat="server" /></td>
				</tr>
				<tr>
					<td>Request.Form.GetValues(DropDownList.ID)=</td>
					<td><asp:Label id="LabelRequestFormDropDownListDynamicIIID" runat="server" /></td>
				</tr>
				<tr>
					<td><asp:DropDownList ID="DropDownListDynamicIII" Runat="server" /></td>
					<td><input type="button" id="btnModifyIII" name="btnModifyIII" value="Modify" onclick="ModifyDropDownListDynamicIII()"></td>
				</tr>
				<tr>
					<td>DropDownList.SelectedIndex=</td>
					<td><asp:Label id="LabelDropDownListDynamicIIISelectedIndex" runat="server" /></td>
				</tr>
				<tr>
					<td>DropDownList.SelectedValue=</td>
					<td><asp:Label id="LabelDropDownListDynamicIIISelectedValue" runat="server" /></td>
				</tr>
				<tr>
					<td>Request.Form.GetValues(DropDownList.ID)=</td>
					<td><asp:Label id="LabelRequestFormDropDownListDynamicIIIID" runat="server" /></td>
				</tr>
				<tr>
					<td><asp:DropDownList ID="DropDownListParent" onchange="FillDDL(this.value);" Runat="server" /></td>
					<td><asp:DropDownList ID="DropDownListChild" EnableViewState="false" Runat="server" /></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
