<%@ Page Language="VB" AutoEventWireup="false" CompileWith="Default.aspx.vb" ClassName="Default_aspx"  EnableViewState="true"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript">
   function ClientCallback(result, context){
      
      var dropdown2 = document.forms[0].elements['DropDownList2'];
      
      dropdown2.innerHTML= "";
      var rows = result.split('|'); 
      for (var i = 0; i < rows.length - 1; ++i){
         var values = rows[i]
         var option = document.createElement("OPTION");
         
         option.value = values;
         option.innerHTML = values;     
         dropdown2.appendChild(option);
      }
   }

   function ClientCallbackError(result, context){
      alert(result);
   }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="DropDownList1" Runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList2" Runat="server">
        </asp:DropDownList>
    
    </div>
        <asp:TextBox ID="TextBox1" Runat="server"></asp:TextBox>
        <asp:Button ID="Button1" Runat="server" Text="Button" OnClick="Button1_Click" />
    </form>
</body>
</html>
