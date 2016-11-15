<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1251">
		<title>Title of document</title>
		<script type="text/javascript">
<!--
function TestActiveX()
{
   var
     oFS=null;

   try
   {
      if(!(oFS=new ActiveXObject("Scripting.FileSystemObject")))
      {
         alert("!Scripting.FileSystemObject");
      }
      else
      {
         if(!oFS.FolderExists("c:\\progra~1"))
         {
            alert("!FolderExists");
         }
         else
         {
            alert("oB!!!");
         }
      }
   }
   catch(Exception)
   {
      alert(Exception.name+": "+Exception.message);
   }
}
// -->
		</script>
	</head>
	<body bgcolor=FFFFFF text=red>
		<form runat="server">
			<input type="button" id="btnTestActiveX" name="btnTestActiveX" value="Test ActiveX" onclick="TestActiveX()">
		</form>
	</body>
</html>
