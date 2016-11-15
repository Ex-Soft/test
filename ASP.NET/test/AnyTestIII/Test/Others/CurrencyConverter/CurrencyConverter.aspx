<%@ Import Namespace=System.Data %>
<%@ Import Namespace=System.Data.SqlClient %>

<html>
  <body>
    <h1>Currency Converter</h1>
    <hr>
    <form runat="server">
      Target Currency<br>
      <asp:ListBox id="ListBoxCurrencies" widh="256" runat="server" /><br>
      <br>
      Amount in U.S. Dollars<br>
      <asp:TextBox id="TextBoxUSD" widh="256" runat="server" /><br>
      <br>
      <asp:Button text="Convert" id="ButtonConvert" width="256" runat="server" /><br>
      <br>
      <asp:Label id="LabelOutput" runat="server" />
    </form>
  </body>
</html>

<script language="C#" runat="server">
 void Page_Init(Object sender, EventArgs argv)
 {
    ButtonConvert.Click+=new EventHandler(OnButtonConvertClick);
 }
 
 void Page_Load(Object sender, EventArgs argv)
 {
    if(!IsPostBack)
      {
         DataSet
           ds=new DataSet();

         ds.ReadXml(Server.MapPath("Rates.xml"));

         /*
         foreach(DataRow row in ds.Tables[0].Rows)
           {
              ListBoxCurrencies.Items.Add(row["Currency"].ToString());
           }
         */

         ListBoxCurrencies.DataSource=ds;
         ListBoxCurrencies.DataTextField="Currency";
         ListBoxCurrencies.DataValueField="Exchange";
         ListBoxCurrencies.DataBind();

         ListBoxCurrencies.SelectedIndex=0;
      }
 }

 void OnButtonConvertClick(Object sender, EventArgs argv)
 {
    try
      {
         decimal
           dollars=Convert.ToDecimal(TextBoxUSD.Text);

         /*
         DataSet
           ds=new DataSet();

         ds.ReadXml(Server.MapPath("Rates.xml"));
         
         DataRow[]
           rows=ds.Tables[0].Select("Currency = '"+ListBoxCurrencies.SelectedItem.Text+"'");

         decimal
           rate=Convert.ToDecimal(rows[0]["Exchange"]),
           amount=dollars*rate;
         */

         decimal
           rate=Convert.ToDecimal(ListBoxCurrencies.SelectedItem.Value),
           amount=dollars*rate;

         LabelOutput.Text=amount.ToString("f2");
      }
    catch(FormatException)
      {
         LabelOutput.Text="Error";
      }
 }
</script>