<%@ Assembly Src="MyQuotes.cs" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Drawing" %>

<asp:DataGrid ID="MyGrid" RunAt="server"
  BorderWidth="1" BorderColor="lightgray" CellPadding="2"
  Font-Name="Verdana" Font-Size="8pt" GridLines="vertical">
  <HeaderStyle BackColor="maroon" ForeColor="white"
    HorizontalAlign="center" />
  <ItemStyle BackColor="white" ForeColor="black" />
  <AlternatingItemStyle BackColor="beige" ForeColor="black" />
</asp:DataGrid>
<span style="font-family: verdana; font-size: 8pt">
  Quotes are delayed by 20 minutes
</span>

<script language="C#" runat="server">
  Unit MyWidth;

  public Unit Width
  {
      get { return MyWidth; }
      set { MyWidth = value; }
  }

  void Page_Load (Object sender, EventArgs e)
  {
      if (MyWidth != Unit.Empty)
          MyGrid.Width = MyWidth;

      // Get quotes for AMZN, INTC, and MSFT
      netxmethodsservicesstockquoteStockQuoteService qs =
          new netxmethodsservicesstockquoteStockQuoteService ();

      decimal amzn;
      decimal intc;
      decimal msft;

      try {
          amzn = (decimal) qs.getQuote ("AMZN");
      }
      catch {
          amzn = -1.0m;
      }

      try {
          intc = (decimal) qs.getQuote ("INTC");
      }
      catch {
          intc = -1.0m;
      }

      try {
          msft = (decimal) qs.getQuote ("MSFT");
      }
      catch {
          msft = -1.0m;
      }

      // Add the quotes to a DataSet
      DataSet ds = new DataSet ();
      DataTable dt = new DataTable ("Quotes");
      ds.Tables.Add (dt);

      DataColumn col1 = new DataColumn ("Symbol", typeof (string));
      DataColumn col2 = new DataColumn ("Price", typeof (string));
      dt.Columns.Add (col1);
      dt.Columns.Add (col2);

      DataRow row = dt.NewRow ();
      row["Symbol"] = "AMZN";
      row["Price"] = (amzn == -1.0m) ? "Unavailable" :
          String.Format ("{0:c}", amzn);
      dt.Rows.Add (row);

      row = dt.NewRow ();
      row["Symbol"] = "INTC";
      row["Price"] = (intc == -1.0m) ? "Unavailable" :
          String.Format ("{0:c}", intc);
      dt.Rows.Add (row);

      row = dt.NewRow ();
      row["Symbol"] = "MSFT";
      row["Price"] = (msft == -1.0m) ? "Unavailable" :
          String.Format ("{0:c}", msft);
      dt.Rows.Add (row);

      // Bind the DataGrid to the DataSet
      MyGrid.DataSource = ds;
      MyGrid.DataBind ();
  }
</script>