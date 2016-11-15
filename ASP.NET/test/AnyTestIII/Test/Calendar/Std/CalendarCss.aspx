<%@ Page language="c#" Codebehind="CalendarCss.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.CalendarCss" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Calendar (with CSS)</title>
		<meta name="vs_snapToGrid" content="False">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="grids.css" rel="stylesheet" type="text/css">
		<style>
			.MyMyMy { color: white; background-color: blue; font-weight: bold; font-style: italic; font-size: 30px }
		</style>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" border="0" style="WIDTH: 100%">
				<tr>
					<td>
						<asp:Calendar id="Calendar1"
						PrevMonthText="<"
						NextMonthText=">"
						NextPrevStyle-Font-Underline="False"
						NextPrevStyle-Font-Names="Webdings"
						DayStyle-Font-Names="Verdana"
						DayStyle-Font-Size="8pt"
						OtherMonthDayStyle-ForeColor="lightblue"
						OtherMonthDayStyle-BackColor="white"
						DayHeaderStyle-Font-Names="Verdana"
						DayHeaderStyle-Font-Size="8pt"
						DayHeaderStyle-Font-Bold="True"
						DayHeaderStyle-ForeColor="white"
						DayHeaderStyle-BackColor="red"
						NextPrevStyle-ForeColor="white"
						NextPrevStyle-BackColor="blue"
						SelectedDayStyle-ForeColor="white"
						SelectedDayStyle-BackColor="red"
						TitleStyle-ForeColor="white"
						TitleStyle-BackColor="blue"
						TitleStyle-Font-Bold="True"
						TitleStyle-Font-Size="8pt"
						TitleStyle-Font-Names="Verdana"
						ForeColor="darkblue"
						BackColor="beige"
						DayNameFormat="FirstLetter"
						ShowGridLines="True"
						runat="server" />
					</td>
					<td>
						<asp:Calendar id="Calendar2"
						PrevMonthText="<"
						NextMonthText=">"
						NextPrevStyle-Font-Underline="False"
						NextPrevStyle-Font-Names="Webdings"
						DayStyle-Font-Names="Verdana"
						DayStyle-Font-Size="8pt"
						OtherMonthDayStyle-ForeColor="lightblue"
						OtherMonthDayStyle-BackColor="white"
						DayHeaderStyle-Font-Names="Verdana"
						DayHeaderStyle-Font-Size="8pt"
						DayHeaderStyle-Font-Bold="True"
						DayHeaderStyle-ForeColor="white"
						DayHeaderStyle-BackColor="red"
						NextPrevStyle-ForeColor="white"
						NextPrevStyle-BackColor="teal"
						SelectedDayStyle-ForeColor="white"
						SelectedDayStyle-BackColor="red"
						TitleStyle-ForeColor="white"
						TitleStyle-BackColor="teal"
						TitleStyle-Font-Bold="True"
						TitleStyle-Font-Size="8pt"
						TitleStyle-Font-Names="Verdana"
						ForeColor="darkblue"
						BackColor="beige"
						DayNameFormat="FirstLetter"
						ShowGridLines="True"
						runat="server" />
					</td>
					<td>
						<asp:Calendar id="Calendar3"
						PrevMonthText="<"
						NextMonthText=">"
						NextPrevStyle-Font-Underline="False"
						NextPrevStyle-Font-Names="Webdings"
						DayStyle-Font-Names="Verdana"
						DayStyle-Font-Size="8pt"
						OtherMonthDayStyle-ForeColor="lightblue"
						OtherMonthDayStyle-BackColor="white"
						DayHeaderStyle-Font-Names="Verdana"
						DayHeaderStyle-Font-Size="8pt"
						DayHeaderStyle-Font-Bold="True"
						DayHeaderStyle-ForeColor="white"
						DayHeaderStyle-BackColor="red"
						NextPrevStyle-ForeColor="white"
						NextPrevStyle-BackColor="aqua"
						SelectedDayStyle-ForeColor="white"
						SelectedDayStyle-BackColor="red"
						TitleStyle-ForeColor="white"
						TitleStyle-BackColor="aqua"
						TitleStyle-Font-Bold="True"
						TitleStyle-Font-Size="8pt"
						TitleStyle-Font-Names="Verdana"
						ForeColor="darkblue"
						BackColor="beige"
						DayNameFormat="FirstLetter"
						ShowGridLines="True"
						runat="server" />
					</td>
				</tr>
				<tr>
					<td align="right" valign="middle">Установить</td>
					<td align="center" valign="middle"><asp:TextBox ID="TextBoxSetDate" style="width: 100%; " Runat="server" /></td>
					<td align="center" valign="middle"><asp:Button ID="ButtonSetDate" Text="Set" style="width: 100%; " Runat="server" /></td>
				</tr>
			</table>
			<!-- TitleStyle-CssClass="MyMyMy" -->
		</form>
	</body>
</HTML>
