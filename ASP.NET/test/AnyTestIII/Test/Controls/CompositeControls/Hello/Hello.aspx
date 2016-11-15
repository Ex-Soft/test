<%@ Register TagPrefix="win" Namespace="Wintellect" Assembly="HelloControl" %>

<html>
  <body>
    <form runat="server">
      <div nowrap>
      <win:Hello Name="Jeff" runat="server" />
      <span>MyTextBox </span><win:MyTextBox ID="MyTextBox" Text="MyTextBox" runat="server" /> <asp:Label ID="MyTextBoxOutput" RunAt="server" /><br>
      <hr>
      <asp:Button Text="Test" OnClick="OnTest" RunAt="server" /><br>
      <span>MyTextBoxAdvanced </span><win:MyTextBoxAdvanced ID="MyTextBoxAdvanced" Text="MyTextBoxAdvanced" runat="server" OnTextChanged="MyTextBoxAdvancedOnTextChanged" /> <asp:Label ID="MyTextBoxAdvancedOutput" RunAt="server" /><br>
      <span>MyTextBoxFullAdvanced </span><win:MyTextBoxFullAdvanced ID="MyTextBoxFullAdvanced" Text="MyTextBoxFullAdvanced" runat="server" OnTextChanged="MyTextBoxFullAdvancedOnTextChanged" AutoPostBack="True" /> <asp:Label ID="MyTextBoxFullAdvancedOutput" RunAt="server" /><br>
      <hr>
      <span>MyLinkButton </span><win:MyLinkButton Text="Click Me" OnClick="MyLinkButtonOnClick" RunAt="server" /> <asp:Label ID="MyLinkButtonOutput" RunAt="server" /><br>
      <hr>
      <span>AutoCounter </span><win:AutoCounter ID="MyCounter" Count="5" OnDecrement="OnDecrement" OnIncrement="OnIncrement" OnCountChanged="OnCountChanged" RunAt="server" />
      <br><br>
      <asp:Button Text="Submit" RunAt="server" />
      <br>
      <asp:Label ID="AutoCounterOutput" RunAt="server" />
      <hr>
      </div>
    </form>
  </body>
</html>

<script language="c#" runat="server">
  void Page_Load(object sender, EventArgs e)
  {
     MyTextBoxOutput.Text="";
     MyTextBoxAdvancedOutput.Text="";
     MyTextBoxFullAdvancedOutput.Text="";
     MyLinkButtonOutput.Text="";
     AutoCounterOutput.Text="";
  }

  void OnTest(object sender, EventArgs e)
  {
     MyTextBoxOutput.Text=MyTextBox.Text;
  }

  void MyTextBoxAdvancedOnTextChanged(object sender, EventArgs e)
  {
     MyTextBoxAdvancedOutput.Text=sender.ToString()+" Text changed";
  }

  void MyTextBoxFullAdvancedOnTextChanged(object sender, EventArgs e)
  {
     MyTextBoxFullAdvancedOutput.Text=sender.ToString()+" Text changed";
  }

  void MyLinkButtonOnClick (Object sender, EventArgs e)
  {
      MyLinkButtonOutput.Text="Click!";
  }

  void OnDecrement (Object sender, EventArgs e)
  {
      AutoCounterOutput.Text = "Count decremented to " + MyCounter.Count;
  }

  void OnIncrement (Object sender, EventArgs e)
  {
      AutoCounterOutput.Text = "Count incremented to " + MyCounter.Count;
  }

  void OnCountChanged (Object sender, EventArgs e)
  {
      AutoCounterOutput.Text = "Count changed to " + MyCounter.Count;
  }
</script>