<%@ Import Namespace="System" %>
<%@ Import Namespace="System.IO" %>
<%@ Assembly Src="Global.asax.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
	<head>
		<meta name="vs_snapToGrid" content="False">
		<title>MainTitle</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</head>
	<body>
		<form id="MainTitleForm" method="post" runat="server">
			<div align="center" nowrap style="color: blue">
				<h6 align="left" style="font-weight: normal; color: navy">
					<asp:Label id="LabelCurrentDateTime" runat="server" text="Now: " />&nbsp;
					<asp:Label id="LabelCurrentCountUsers" runat="server" text="Count User(s): " style="font-weight: normal; color: purple" /><br>
					<asp:Label id="LabelDirectoryGetCurrentDirectory" runat="server" text="Directory.GetCurrentDirectory(): " style="font-weight: normal; color: black" />&nbsp;<asp:Label ID="LabelEnvironmentVersion" Text="Environment.Version: " style="font-weight: normal; color: black" runat="server" /><br />
					<asp:Label id="LabelServerMapPath" runat="server" text="Server.MapPath(null): " style="font-weight: normal; color: black" />
				</h6>
				<h1>AnyTest</h1>
				<hr width="80%" size="5" color=Blue>
			</div>
		</form>
	</body>
</html>

<script language="C#" runat="server">
  void Page_Load(Object sender, EventArgs argv)
  {
     if(!IsPostBack)
       {
          LabelCurrentDateTime.Text+=DateTime.Now.ToLongDateString()+" "+DateTime.Now.ToLongTimeString();
          LabelCurrentCountUsers.Text+=(int)Application["UserOnline"];
          LabelDirectoryGetCurrentDirectory.Text+=Directory.GetCurrentDirectory();
          LabelEnvironmentVersion.Text+=Environment.Version;
          LabelServerMapPath.Text+=Server.MapPath(null);
       }
  }
</script>
