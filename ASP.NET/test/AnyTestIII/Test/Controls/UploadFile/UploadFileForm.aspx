<%@ Page language="c#" Codebehind="UploadFileForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.UploadFileForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Upload File</title>
		<meta name="vs_snapToGrid" content="False">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script type="text/javascript">
<!--
function SetFileName()
{
	var
		CtrlSrc,
		CtrlDest;

	if(!(CtrlSrc=document.getElementById("InputTextFileName"))
		|| !(CtrlDest=document.getElementById("inpFileName")))
		return;

	CtrlDest.value=CtrlSrc.value;
}
// -->
		</script>
	</HEAD>
	<body>
		<form id="UploadFileForm" method="post" runat="server">
			<table width="100%">
				<tr>
					<td colspan="2">
						<table style="width: 100%; " cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td>File Name:</td>
								<td><input type="text" id="InputTextFileName"></td>
								<td><input type="button" id="InputButtonSetFileName" value="Set FileName" onclick="SetFileName()"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>File Name:</td>
					<td>
						<input type="hidden" name="MAX_FILE_SIZE" value="100">
						<input type="file" id="inpFileName" style="WIDTH: 100%" runat="server">
					</td>
				</tr>
				<tr>
					<td>Dest Path:</td>
					<td><asp:TextBox ID="inpDestPath" width="100%" Runat="server" /></td>
				</tr>
				<tr>
					<td colspan="2"><input type="submit" id="btnUpload" value="Upload" style="WIDTH: 100%" runat="server"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
