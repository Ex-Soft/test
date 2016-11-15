<script>
// на странице, где будет это использоваться должна быть объявлена переменная iFramesCount = XXX;
// где XXX - количество загруженых ифреймов, необходимых для начала работы
var g_a_selects = document.getElementsByTagName ("SELECT");
function HideSelects() {  for (i = 0; i < g_a_selects.length; i++) g_a_selects[i].style.visibility = "hidden";  } 
function ShowSelects() {  for (i = 0; i < g_a_selects.length; i++) g_a_selects[i].style.visibility = "visible"; }
function fBlockWin(){	
	iBw = parseInt(window.document.getElementById("iBlockWin").value);
	var tdPRC = window.document.getElementById("tdPRC");
	if(tdPRC != null) { Prc = (parseInt(100/iFramesCount)*iBw).toString(); tdPRC.innerHTML = "Зачекайте!... "+Prc+"%";	tdPROGRESS.innerHTML += "|||";}
	if(iBw >= iFramesCount && window.document.getElementById("divBlockWin") != null)
	{ window.document.getElementById("divBlockWin").style.display='none'; ShowSelects();	} 
	else
	{HideSelects();}
	}
window.document.write("<input type='hidden' id='iBlockWin' value='0' onpropertychange='fBlockWin()' NAME='iBlockWin'>");
window.document.write("<div id=divBlockWin style='POSITION: absolute; z-index:155; display:block; top:0%; left:0%; width:"+window.document.body.clientWidth.toString()+"; height:"+window.document.body.clientHeight.toString()+";'>");
window.document.write("<table width='100%' height='100%' border=0 cellpadding=0 cellspacing=0>");
window.document.write("<tr height='50%' valign=bottom><td align=center id='tdPRC' width='50%'>Зачекайте!... 0%</td></tr><tr height='50%' valign=top><td align='center' id='tdPROGRESS'>|||</td></tr></table></div>");
HideSelects();
</script>
