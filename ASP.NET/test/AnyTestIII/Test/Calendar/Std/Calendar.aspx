<html>
  <head>
  <title>Calendar</title>
  </head>
  <body>
    <h1 style="color: blue">Calendar</h1>
    <hr size=10 color="blue">
    <form runat="server">
      <span style="font-weight: bold; color: blue">Calendar 1</span>
      <asp:Calendar id="Calendar1" runat="server" />
      <hr size="5" color="blue"><br>
      <span style="font-weight: bold; color: blue">Calendar 1a</span>
      <asp:Calendar
        id="Calendar1a"
        runat="server"
        daynameformat="FirstLetter"
        titlestyle-font-size="8pt"
        titlestyle-font-names="Verdana"
        titlestyle-font-bold="True"
        todaydaystyle-backcolor="Gainsboro"
        todaydaystyle-font-bold="True"
        daystyle-font-size="8pt"
        daystyle-font-names="Verdana"
        dayheaderstyle-font-size="8pt"
        dayheaderstyle-font-bold="True"
        dayheaderstyle-font-names="Verdana"
        selectionmode="DayWeekMonth"
        nextprevstyle-font-names="Webdings"
        selectorstyle-font-names="Verdana"
        selectorstyle-font-size="6pt"
        nextmonthtext="4"
        nextprevstyle-font-underline="False"
        prevmonthtext="3">
      </asp:Calendar>
      <hr size="5" color="blue"><br>
      <span style="font-weight: bold; color: blue">Calendar 2</span>
      <asp:Calendar id="Calendar2"
        DayNameFormat="FirstLetter"
        ShowGridLines="True"
        BackColor="beige"
        ForeColor="darkblue"
        SelectedDayStyle-BackColor="red"
        SelectedDayStyle-ForeColor="white"
        SelectedDayStyle-Font-Bold="True"
        TitleStyle-BackColor="darkblue"
        TitleStyle-ForeColor="white"
        TitleStyle-Font-Bold="True"
        NextPrevStyle-BackColor="darkblue"
        NextPrevStyle-ForeColor="white"
        DayHeaderStyle-BackColor="red"
        DayHeaderStyle-ForeColor="white"
        DayHeaderStyle-Font-Bold="True"
        OtherMonthDayStyle-BackColor="white"
        OtherMonthDayStyle-ForeColor="lightblue"
        width="256px" runat="server"
        OnSelectionChanged="Calendar2OnDateSelected"
        nextmonthtext="Next Month"
        prevmonthtext="Previous Month">
      </asp:Calendar>
      <span style="font-weight: normal; color: blue">Selected date: </span><asp:Label id="LabelCalendar2Output" ForeColor="red" runat="server" />
      <hr size=5 color="blue"><br>
      <span style="font-weight: bold; color: blue">Calendar 3</span>
      <asp:Calendar ID="Calendar3"
        SelectionMode="DayWeekMonth"
        ShowGridLines="True"
        OnSelectionChanged="Calendar3SelectionChanged"
        OnDayRender="Calendar3DayRender"
        SelectMonthText="Select Month"
        SelectWeekText="Select Week"
        Runat="server" />
      <span style="font-weight: normal; color: blue">Selected date(s): </span><asp:Label id="LabelCalendar3Output" ForeColor="red" runat="server" />
      <hr size=5 color="blue"><br>
      <span style="font-weight: bold; color: blue">Calendar 4</span><br>
      Pick a show:<br>
      <asp:DropDownList ID="ShowName" RunAt="Server">
        <asp:ListItem Text="Cats" Selected="true" RunAt="server" />
        <asp:ListItem Text="Phantom of the Opera" RunAt="server" />
        <asp:ListItem Text="Les Miserables" RunAt="server" />
        <asp:ListItem Text="Cabaret" RunAt="server" />
      </asp:DropDownList>
      <br><br>
      Pick a date:<br>
      <asp:Calendar
        ID="ShowDate"
        ShowGridLines="true"
        ForeColor="darkblue"
        SelectedDayStyle-BackColor="darkblue"
        SelectedDayStyle-ForeColor="white"
        SelectedDayStyle-Font-Bold="true"
        TitleStyle-BackColor="darkblue"
        TitleStyle-ForeColor="white"
        TitleStyle-Font-Bold="true"
        NextPrevStyle-BackColor="darkblue"
        NextPrevStyle-ForeColor="white"
        DayHeaderStyle-BackColor="beige"
        DayHeaderStyle-ForeColor="darkblue"
        DayHeaderStyle-Font-Bold="true"
        OtherMonthDayStyle-ForeColor="lightgray"
        OnSelectionChanged="OnDateSelected"
        OnDayRender="OnDayRender"
        RunAt="Server" />
      <br>
      <asp:ImageButton ImageUrl="../images/OrderBtn.gif" OnClick="OnOrder" RunAt="server" alt="The image &quot;../images/OrderBtn.gif&quot; cannot be displayed" />
      <br><br><hr>
      <h3><asp:Label ID="LabelCalendar4Output" RunAt="server" /></h3>
    </form>
  </body>
</html>

<script language="C#" runat="server">
  void Page_Load(Object sender, EventArgs e)
  {
     if(!IsPostBack)
     {
        Calendar1.SelectedDate=DateTime.Now;
        Calendar2.SelectedDate=DateTime.Now; 

        DateTime
          start=DateTime.Now.AddDays(-5),
          stop=DateTime.Now.AddDays(5);

        Calendar3.SelectedDates.SelectRange(start,stop);
        Calendar3.VisibleDate=start;
     }
  }

  void OnOrder(Object sender, ImageClickEventArgs e)
  {
     if(ShowDate.SelectedDate.Year>1900)
       LabelCalendar4Output.Text="You selected "+ShowName.SelectedItem.Text+" on "+ShowDate.SelectedDate.ToLongDateString();
     else
       LabelCalendar4Output.Text="Please select a date";
  }

  void OnDateSelected(Object sender, EventArgs e)
  {
     LabelCalendar4Output.Text="";
  }

  void OnDayRender(Object sender, DayRenderEventArgs e)
  {
     e.Day.IsSelectable=(e.Day.Date.DayOfWeek==DayOfWeek.Friday
                         || e.Day.Date.DayOfWeek==DayOfWeek.Saturday)
                        && e.Day.Date >= DateTime.Today
                        && !e.Day.IsOtherMonth;

     if(e.Day.IsSelectable
        && e.Day.Date!=ShowDate.SelectedDate)
     e.Cell.BackColor=System.Drawing.Color.Beige;
  }
  
  void Calendar2OnDateSelected(object sender, EventArgs e)
  {
     LabelCalendar2Output.Text=Calendar2.SelectedDate.ToLongDateString();
  }

  void Calendar3SelectionChanged(object sender, EventArgs e)
  {
     StringBuilder
       builder=new StringBuilder();

     foreach(DateTime date in Calendar3.SelectedDates)
     {
        builder.Append(date.ToLongDateString());
        builder.Append("<br>");
     }
     LabelCalendar3Output.Text=builder.ToString();
  }

  void Calendar3DayRender(object sender, DayRenderEventArgs e)
  {
     e.Cell.Width=80;
     e.Cell.Height=64;

     string
       html="<br><font color=\"red\" face=\"verdana\" size=\"1\">Christmas</font>";

     if(e.Day.Date.Month==12
        && e.Day.Date.Day==25)
     {
        e.Cell.Controls.AddAt(0,new LiteralControl("<br>"));
        e.Cell.Controls.Add(new LiteralControl(html));
     }

     e.Day.IsSelectable=!(e.Day.Date.DayOfWeek==DayOfWeek.Saturday
                          || e.Day.Date.DayOfWeek==DayOfWeek.Sunday
                          || e.Day.Date>=DateTime.Today);
  }
</script>