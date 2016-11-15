<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Drawing" %>

<asp:Table ID="MyTable" RunAt="server" />

<script language="C#" runat="server">
  string MyXmlSrc;
  Color MyBackColor;
  Color MyForeColor;
  Color MyMouseOverColor;
  MyFontInfo MyFont = new MyFontInfo ();

  public string XmlSrc
  {
      get { return MyXmlSrc; }
      set { MyXmlSrc = value; }
  }

  public Color BackColor
  {
      get { return MyBackColor; }
      set { MyBackColor = value; }
  }

  public Color ForeColor
  {
      get { return MyForeColor; }
      set { MyForeColor = value; }
  }

  public Color MouseOverColor
  {
      get { return MyMouseOverColor; }
      set { MyMouseOverColor = value; }
  }

  public MyFontInfo Font
  {
      get { return MyFont; }
      set { MyFont = value; }
  }

  void Page_Load (Object sender, EventArgs e)
  {
      if (MyXmlSrc != null) {
          DataSet ds = new DataSet ();
          ds.ReadXml (Server.MapPath (MyXmlSrc));

          foreach (DataRow item in ds.Tables[0].Rows) {
              TableRow row = new TableRow ();
              TableCell cell = new TableCell ();

              StringBuilder builder = new StringBuilder ();
              builder.Append ("<a href=\"");
              builder.Append (item["Link"]);
              builder.Append ("\" ");

              if (MyMouseOverColor != Color.Empty &&
                  Request.Browser.Type.ToUpper ().IndexOf ("IE") > -1
                  && Request.Browser.MajorVersion >= 4) {
                  builder.Append ("onmouseover=\""  +
                      "defcolor=this.style.color; " +
                      "this.style.color=\'");
                  builder.Append (MyMouseOverColor.Name);
                  builder.Append ("\'\" onmouseout=\"" +
                      "this.style.color=defcolor\" ");
              }

              builder.Append ("style=\"text-decoration: none; ");

              if (MyFont.Name != null) {
                  builder.Append ("font-family: ");
                  builder.Append (MyFont.Name);
                  builder.Append ("; ");
              }

              if (MyFont.Size != FontUnit.Empty) {
                  builder.Append ("font-size: ");
                  builder.Append (MyFont.Size.ToString ());
                  builder.Append ("; ");
              }

              if (MyFont.Bold)
                  builder.Append ("font-weight: bold; ");

              if (MyForeColor != Color.Empty) {
                  builder.Append ("color: ");
                  builder.Append (MyForeColor.Name);
              }

              builder.Append ("\">");
              builder.Append (item["Text"]);
              builder.Append ("</a>");

              cell.Text = builder.ToString ();
              row.Cells.Add (cell);
              MyTable.Rows.Add (row);
          }

          if (MyBackColor != Color.Empty)
              MyTable.BackColor = MyBackColor;
      }
  }

  public class MyFontInfo
  {
      string FontName;
      FontUnit FontSize;
      bool FontBold = false;

      public string Name
      {
          get { return FontName; }
          set { FontName = value; }
      }

      public FontUnit Size
      {
          get { return FontSize; }
          set { FontSize = value; }
      }

      public bool Bold
      {
          get { return FontBold; }
          set { FontBold = value; }
      }
  }
</script>