<html>
  <head>
    <style>
      .Input { font: 10pt verdana; color: red; }
      span { font-weight: bold; color: aqua; }
    </style>
    <title>Validators</title>
  </head>
  <body>
    <h1 style="color: blue">Validators</h1>
    <hr size=10 color="blue">
    <form runat="server" style="background-color: teal">
      <span>Password </span><asp:TextBox id="password1" textmode="password" runat="server" />
      <asp:RequiredFieldValidator
        ControlToValidate="password1"
        ErrorMessage="Required field"
        Display="static"
        ForeColor="blue"
        runat="server" />
      <br>
      <span>Password </span><asp:TextBox id="password2" textmode="password" runat="server" />
      <asp:RequiredFieldValidator
        ControlToValidate="password2"
        Display="static"
        ForeColor="blue"
        runat="server">
      Required field
      </asp:RequiredFieldValidator>
      <br>
      <span>Password </span><asp:TextBox id="password3" textmode="password" runat="server" />
      <asp:RequiredFieldValidator
        ControlToValidate="password3"
        ErrorMessage="Required field"
        Display="dynamic"
        ForeColor="blue"
        runat="server" />
      <asp:RequiredFieldValidator
        ControlToValidate="password3"
        ValidationExpression=".{8,}"
        ErrorMessage="You must enter at least 8 characters"
        Display="dynamic"
        ForeColor="blue"
        runat="server" />
      <br>
      <span>e-mail </span><asp:TextBox CssClass="Input" id="EMail1" runat="server" />
      <asp:RequiredFieldValidator
        ControlToValidate="EMail1"
        ErrorMessage="Required field"
        Display="static"
        ForeColor="blue"
        runat="server" />
      <br>
      <asp:TextBox id="Percent" runat="server" /><span>%</span>
      <asp:RangeValidator
        ControlToValidate="Percent"
        MinimumValue=0
        MaximumValue=100
        Type="Integer"
        ErrorMessage="Value out of range"
        Display="static"
        ForeColor="blue"
        runat="server" />
      <br>
      <span>Date </span><asp:TextBox id="MyDate" runat="server" />
      <asp:RangeValidator
        ID="RangeValidatorDate"
        ControlToValidate="MyDate"
        Type="Date"
        ErrorMessage="Date out of range"
        Display="static"
        ForeColor="blue"
        runat="server" />
      <br>
      <span>Min=</span><asp:TextBox id="Minimum" runat="server" />
      <span>Max=</span><asp:TextBox id="Maximum" runat="server" />
      <asp:CompareValidator
        ControlToValidate="Maximum"
        ControlToCompare="Minimum"
        Type="Integer"
        Operator="GreaterThanEqual"
        ErrorMessage="Invalid maximum"
        Display="static"
        ForeColor="blue"
        runat="server" />
      <br>
      <span>Password </span><asp:TextBox id="password11" TextMode="password" runat="server" />
      <span>Re-enter password </span><asp:TextBox id="password22" TextMode="password" runat="server" />
      <asp:CompareValidator
        ControlToValidate="password22"
        ControlToCompare="password11"
        Type="String"
        Operator="Equal"
        ErrorMessage="Mismatch"
        Display="static"
        ForeColor="blue"
        runat="server" />
      <br>
      <span>Digits </span><asp:TextBox id="Quantity" runat="server" />
      <asp:RegularExpressionValidator
        ControlToValidate="Quantity"
        ValidationExpression="^\d+$"
        ErrorMessage="Digits only"
        Display="static"
        ForeColor="blue"
        runat="server" />
      <br>
      <span>e-mail </span><asp:TextBox id="EMail2" runat="server" />
      <asp:RegularExpressionValidator
        ControlToValidate="EMail2"
        ValidationExpression="^[\w\.-]+@[\w-]+\.[\w\.-]+$"
        ErrorMessage="Invalid e-mail address"
        Display="static"
        ForeColor="blue"
        runat="server" />
      <br>
      <span>Input%10 </span><asp:TextBox id="Amount" runat="server" />
      <asp:CustomValidator
        ControlToValidate="Amount"
        ClientValidationFunction="__validateAmount"
        OnServerValidate="ValidateAmount"        
        ErrorMessage="Amount must be a multiple of 10"
        Display="static"
        ForeColor="blue"
        runat="server" />
      <br>
      <span>User name </span><asp:TextBox id="UserName" runat="server" />
      <asp:RequiredFieldValidator
        ControlToValidate="UserName"
        ErrorMessage="The user name can't be blank"
        Display="none"
        runat="server" />
      <br>
      <span>Password </span><asp:TextBox id="password4" textmode="password" runat="server" />
      <asp:RequiredFieldValidator
        ControlToValidate="password4"
        ErrorMessage="The password can't be blank"
        Display="none"
        runat="server" />
      <asp:RequiredFieldValidator
        ControlToValidate="password4"
        ValidationExpression=".{8,}"
        ErrorMessage="The password must contain at least 8 characters"
        Display="none"
        runat="server" />
      <asp:ValidationSummary
        DisplayMode="BulletList"
        HeaderText="This page containts the following errors"
        ShowMessageBox="true"
        ShowSummary="true"
        runat="server" />
      <br>
      <br>
    <asp:button id="ButtonTest" runat="server" Text="Test" onclick="OnClick"></asp:button>
    </form>
  </body>
</html>

<script language="JavaScript">
<!--
  function __validateAmount(source, args)
  {
     args.IsValid=(args.Value%10 == 0);
  }
// -->
</script>

<script language="C#" runat="server">
  void Page_Load(Object sender, EventArgs e)
  {
     if(!IsPostBack)
     {
        RangeValidatorDate.MinimumValue=DateTime.Now.AddYears(-1).ToString("yyyy/MM/dd");
        RangeValidatorDate.MaximumValue=DateTime.Now.AddYears(1).ToString("yyyy/MM/dd");
     }
  }

  void ValidateAmount(Object sender, ServerValidateEventArgs e)
  {
     try
       {
          e.IsValid=(Convert.ToInt32(e.Value)%10 == 0);
       }
     catch(FormatException)
       {
          e.IsValid=false;
       }
  }

  void OnClick(Object sender, EventArgs e)
  {
     if(IsValid)
       {
       }
  }
</script>