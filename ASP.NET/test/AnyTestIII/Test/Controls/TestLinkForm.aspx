<%@ Page language="c#" Codebehind="TestLinkForm.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.TestLinkForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test Link</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="vs_snapToGrid" content="False">
		<script type="text/javascript">
<!--
if(("AutoDownload" in this)
	&& AutoDownload)
	document.write("<META HTTP-EQUIV=\"refresh\" content=\".1; URL=http://download.microsoft.com/download/4/a/a/4aa524c6-239d-47ff-860b-5b397199cbf8/Windows-KB890830-V1.22.exe\">");

function ShowAlt(imgId)
{
   var
     img=document.getElementById(imgId);

   if(img!=null)
   {
      if(img!=undefined)
      {
         if("alt" in img)
           alert("\"alt\" in img");
         else
           alert("\"alt\" not in img");
         if(img.alt)
           alert(img.alt);
         else
           alert("!img.alt");
      }
      else
        alert("img==undefined");
   }
   else
     alert("img==null");
}

function ImgLoad(imgId)
{
   alert("Complete");

   var
     img=document.getElementById(imgId);

   if(img!=null)
   {
      if(img!=undefined)
      {
         if(img.alt)
           img.alt="alt==hint";
         else
           alert("!img.alt");
      }
      else
        alert("img==undefined");
   }
   else
     alert("img==null");
}

function ImgLoadError(imgId)
{
   alert(imgId+' load error!!!');
}	
// -->
		</script>
	</HEAD>
	<body>
		<form id="TestLinkForm" method="post" runat="server">
			<asp:LinkButton ID="LinkButtonMeta" CommandName="Download" CommandArgument="Download" Runat="server">LinkButton &lt;META&gt;</asp:LinkButton><br>
			<asp:LinkButton ID="LinkbuttonIFrame" CommandName="Download" CommandArgument="Download" Runat="server">LinkButton &lt;IFRAME&gt;</asp:LinkButton><br>
			<asp:LinkButton ID="LinkbuttonResponse" CommandName="Download" CommandArgument="Download" Runat="server">LinkButton (Response)</asp:LinkButton><br>
			<a id=AnchorDownload href="#" onclick="return(confirm('Download'));" runat="server">
				<img src="./images/27265.gif" alt="Download" title="Download" border="0">
			</a><br>
			<asp:ImageButton ID="ImageButtonDownload" ImageUrl="./images/27265.gif" AlternateText="Download" title="Download" BorderWidth="0" runat="server" />
			<hr>
			<ol style="1">
				<li><a href="#" onclick="alert('href=\x22#\x22')">href="#"</a><br>
				<li><a href="javascript:alert('href=\x22javascript:\x22')">href="javascript:"</a><br>
				<li><a href="#" onclick="ShowAlt('Img1')"><img id="Img1" name="Img1" src="./images/27265.gif" alt="string if image was not found" onload="ImgLoad('Img1')" onerror="ImgLoadError('Img1')"></a><br>
				<li><a href="#" onclick="ShowAlt('Img2')"><img id="Img2" name="Img2" src="./images/27265.gif" alt="string if image was not found" border=0></a><br>
				<li><input type="image" id="btnImg3" name="btnImg3" src="./images/27265.gif" border="10" onclick="alert('input type=\x22image\x22');return(false)"><br>
				<li><input type="image" id="btnImg4" name="btnImg4" src="./images/27265.gif" border="10" onclick="alert('input type=\x22image\x22')"><br>
				<li><asp:ImageButton ID="btnImg5" ImageUrl="./images/27265.gif" BorderWidth="0" Runat="server" /><br>
				<li><asp:ImageButton ID="btnImg6" ImageUrl="./images/27265.gif" BorderWidth="0" Runat="server" />
			</ol>
			<hr>
		</form>
		<iframe id="IFrameAutoDownload" name="IFrameAutoDownload" width="0%" height="0%" scrolling="no"	frameborder="0" runat="server"></iframe>
	</body>
</HTML>
