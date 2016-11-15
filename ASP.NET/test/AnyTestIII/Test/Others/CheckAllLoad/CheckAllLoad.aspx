<%@ Page language="c#" Codebehind="CheckAllLoad.aspx.cs" AutoEventWireup="false" Inherits="AnyTest.CheckAllLoad" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>CheckAllLoad</title>
		<meta content="False" name="vs_snapToGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script type="text/javascript">
<!--
var
  hTimerPrepare;

function FindFrame(FrameId)
{
   var
     idx=-1;
   
   for(var i=0; i<frames.length; ++i)
      if(frames[i].name==FrameId)
      {
         idx=i;
         break;
      }
   
   return(idx);
}

function Prepare(FrameId)
{
   var
     p=document.getElementById("Info"),
     d=new Date(),
     Str=d.getHours()+":"+d.getMinutes()+":"+d.getSeconds()+"."+d.getMilliseconds()+" : Prepare(\""+FrameId+"\") started...<br>",
     idx;
     
   p.innerHTML+=Str;
   
   d=new Date();
   Str=d.getHours()+":"+d.getMinutes()+":"+d.getSeconds()+"."+d.getMilliseconds()+" : ";
   if(!frames.length)
   {
      Str+="!frames.length<br>";
      p.innerHTML+=Str;
      return;
   }
   else
     Str+="frames.length="+frames.length+"<br>";
   p.innerHTML+=Str;
   
   d=new Date();
   Str=d.getHours()+":"+d.getMinutes()+":"+d.getSeconds()+"."+d.getMilliseconds()+" : ";
   if((idx=FindFrame(FrameId))==-1)
   {
      Str+="!FindFrame()<br>";
      p.innerHTML+=Str;
      return;
   }
   else
     Str+="FindFrame()="+idx+"<br>";
   p.innerHTML+=Str;
      
   d=new Date();
   Str=d.getHours()+":"+d.getMinutes()+":"+d.getSeconds()+"."+d.getMilliseconds()+" : ";
   if(!frames[idx].IsLoad)
   {
      Str+="!frames["+idx+"].IsLoad<br>";
      p.innerHTML+=Str;
      return;
   }
   else
     Str+="frames["+idx+"].IsLoad="+frames[idx].IsLoad+"<br>";
   p.innerHTML+=Str;

   d=new Date();
   Str=d.getHours()+":"+d.getMinutes()+":"+d.getSeconds()+"."+d.getMilliseconds()+" : clearInterval()<br>";
   p.innerHTML+=Str;
   clearInterval(hTimerPrepare);

   d=new Date();
   Str=d.getHours()+":"+d.getMinutes()+":"+d.getSeconds()+"."+d.getMilliseconds()+" : ";
   Str+="All Loaded";
   p.innerHTML+=Str;
}
// -->
		</script>
	</HEAD>
	<body onload="hTimerPrepare=setInterval('Prepare(\u0022Definitions\u0022)',100)">
		<iframe id="Definitions" style="WIDTH: 500px; HEIGHT: 396px" name="Definitions" marginWidth="0"
			marginHeight="0" src="test.html" frameBorder="0" scrolling="no" runat="server"></iframe>
		<form id="CheckAllLoadForm" method="post" runat="server">
			<asp:label id="LabelInfo" runat="server"></asp:label><br>
			<IMG alt="Can't load &quot;monster.gif&quot;" src="monster.gif"><br>
			<br>
			<input id="btnSubmit" type="submit" value="Submit" name="btnSubmit">
			<p id="Info"></p>
		</form>
	</body>
</HTML>
