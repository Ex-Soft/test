<html>
<head><meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
<title>Title of document</title>
</head>
 <body bgcolor=FFFFFF text=red>
  <form runat="server">
   <asp:TextBox Text="2" Id="op1" runat="server" />
   +
   <asp:TextBox Text="2" Id="op2" runat="server" />
   <asp:Button Text=" = " Id="ButtonEquals" runat="server" />
   <asp:Label ID="Sum" runat="server" />
  </form>
 </body>
</html>

<script language="C#" runat="server">
 void Page_Init(Object sender, EventArgs e)
 {
    ButtonEquals.Click+=new EventHandler(OnAdd);
 }

 void OnAdd(Object sender, EventArgs e)
 {
   try
     { 
        int
          a=Convert.ToInt32(op1.Text),
          b=Convert.ToInt32(op2.Text);
        
        Sum.Text=(a+b).ToString();
     }
    catch(FormatException)
     {
        Sum.Text="Error";
     }
 }
</script>