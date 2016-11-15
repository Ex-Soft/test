<!-- на страницу в ифрейме -->
<script>
function isLoaded() { 
   var iBlockWin = window.parent.document.getElementById('iBlockWin');
   if(iBlockWin == null) { iBlockWin = window.parent.parent.document.getElementById('iBlockWin'); }
   if(iBlockWin != null) { iBlockWin.value = (parseInt(iBlockWin.value)+1).toString(); } }
window.setTimeout("isLoaded()",100);
</script>
