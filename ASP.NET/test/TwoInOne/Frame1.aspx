<%@ Page language="c#" Codebehind="Frame1.aspx.cs" AutoEventWireup="false" Inherits="TwoInOne.Frame1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Frame1</title>
		<meta name="vs_snapToGrid" content="False">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script type="text/javascript" src="misc.js"></script>
		<script type="text/javascript">
<!--
var
  DDL,
  DDLClear;
  
function Change(ddlId)
{
   var
     tmpStr;
     
   if(DDLClear==undefined || DDLClear==false)
   {
      if(DDL==undefined || DDL==null)
        DDL=document.getElementById(ddlId);
        
      if(DDL!=undefined && DDL!=null)
      {
         for(var i=0; i<DDL.options.length; ++i)
         {
            tmpStr=AllTrim(DDL.options[i].value);
            if(tmpStr.length==0)
            {
               DDL.remove(i);
               DDLClear=true;
               break;  
            }
         }
      }
   }
}
// -->
		</script>
	</HEAD>
	<body>
		<form id="Frame1Form" method="post" runat="server">
			<asp:DropDownList id="DropDownListFrame1" runat="server" onchange="Change('DropDownListFrame1')"></asp:DropDownList>
		</form>
	</body>
</HTML>
