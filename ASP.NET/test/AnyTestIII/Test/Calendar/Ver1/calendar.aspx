<HTML>
	<HEAD>
		<title>Calendar ver. 1</title>
		<script language="javascript" src="javascript/calendar.js"></script>
	</HEAD>
	<body>
		<form id="processForm" runat="server">
			Дата начала&nbsp;
			<asp:TextBox id="tbStart" runat="server" />&nbsp;
			<A onclick="show_calendar('processForm.tbStart',null,'','DD/MM/YYYY');return false" href="#"><IMG height="16" src="../images/calendar.gif" width="16" border="0"></A>
		</form>
	</body>
</HTML>
