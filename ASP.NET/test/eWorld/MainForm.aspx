<%@ Page language="c#" Codebehind="MainForm.aspx.cs" AutoEventWireup="false" Inherits="eWorld.MainForm" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI, Version=1.9.0.0, Culture=neutral, PublicKeyToken=24d65337282035f2" Namespace="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MainForm</title>
		<meta name="vs_snapToGrid" content="False">
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="MainForm" method="post" runat="server">
			<ew:CalendarPopup id="Birthday" runat="server" ControlDisplay="TextboxImage" Text="Оберіть дату" ImageUrl="pix/cal.gif"
				NullableLabelText="Оберіть дату" PadSingleDigits="True" MonthYearPopupCancelText="Відмінити" MonthYearPopupApplyText="Прийняти"
				PreviousMonthImageUrl="pix/rew.gif" PreviousYearImageUrl="pix/rew.gif" NextMonthImageUrl="pix/fwd.gif"
				NextYearImageUrl="pix/fwd.gif" CalendarLocation="Bottom">
				<TextboxLabelStyle CssClass="textfield"></TextboxLabelStyle>
				<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
					BackColor="White"></WeekdayStyle>
				<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
					BackColor="Yellow"></MonthHeaderStyle>
				<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Gray"
					BackColor="AntiqueWhite"></OffMonthStyle>
				<ButtonStyle BorderStyle="Solid" BorderWidth="0px"></ButtonStyle>
				<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
					BackColor="White"></GoToTodayStyle>
				<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
					BackColor="LightGoldenrodYellow"></TodayDayStyle>
				<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
					BackColor="Orange"></DayHeaderStyle>
				<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
					BackColor="Salmon"></WeekendStyle>
				<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
					BackColor="Yellow"></SelectedDateStyle>
				<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
					BackColor="White"></ClearDateStyle>
				<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
					BackColor="White"></HolidayStyle>
			</ew:CalendarPopup>
			<fieldset title="Hint on FIELDSET">
				<legend title="Hint on LEGEND">
					Title</legend>
				З&nbsp;<ew:TimePicker id="DateTimeFromTime" runat="server" Culture="Ukrainian (Ukraine)" PopupLocation="Bottom"
					ImageUrl="pix/clock.gif" ControlDisplay="TextBoxImage" MinuteInterval="FifteenMinutes">
					<ClearTimeStyle BackColor="White"></ClearTimeStyle>
					<TimeStyle BackColor="White"></TimeStyle>
					<SelectedTimeStyle BackColor="White"></SelectedTimeStyle>
				</ew:TimePicker>&nbsp;
				<ew:CalendarPopup id="DateTimeFromDate" runat="server" Culture="Ukrainian (Ukraine)" CalendarLocation="Bottom">
					<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
						BackColor="White"></WeekdayStyle>
					<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
						BackColor="Yellow"></MonthHeaderStyle>
					<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Gray"
						BackColor="AntiqueWhite"></OffMonthStyle>
					<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
						BackColor="White"></GoToTodayStyle>
					<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
						BackColor="LightGoldenrodYellow"></TodayDayStyle>
					<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
						BackColor="Orange"></DayHeaderStyle>
					<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
						BackColor="LightGray"></WeekendStyle>
					<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
						BackColor="Yellow"></SelectedDateStyle>
					<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
						BackColor="White"></ClearDateStyle>
					<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
						BackColor="White"></HolidayStyle>
				</ew:CalendarPopup>&nbsp;По&nbsp;<ew:CalendarPopup id="DateTimeTillDate" runat="server" Culture="Russian (Russia)" CalendarLocation="Bottom">
					<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
						BackColor="White"></WeekdayStyle>
					<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
						BackColor="Yellow"></MonthHeaderStyle>
					<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Gray"
						BackColor="AntiqueWhite"></OffMonthStyle>
					<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
						BackColor="White"></GoToTodayStyle>
					<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
						BackColor="LightGoldenrodYellow"></TodayDayStyle>
					<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
						BackColor="Orange"></DayHeaderStyle>
					<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
						BackColor="LightGray"></WeekendStyle>
					<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
						BackColor="Yellow"></SelectedDateStyle>
					<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
						BackColor="White"></ClearDateStyle>
					<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
						BackColor="White"></HolidayStyle>
				</ew:CalendarPopup>
			</fieldset>
		</form>
	</body>
</HTML>
