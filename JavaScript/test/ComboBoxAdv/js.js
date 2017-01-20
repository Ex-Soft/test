function validateNumbers(obj) {
	if (obj.value) {
		if (parseFloat(obj.value.replace(",","."))) {
			obj.value = parseFloat(obj.value.replace(",","."));
		}
		else {
			obj.value = "0";
		}
	}
}

var lastfoto;
var thisfoto;

function changeFoto(foto,obj) {
	lastfoto = thisfoto;
	thisfoto = obj;
	if (!lastfoto) {
		lastfoto = document.getElementById('firstfoto');
	}
	thisfoto.style.borderColor="red";
	lastfoto.style.borderColor="#78673A";
	document.getElementById('bigfoto').src = foto;
}

function showType(id) {
	for (var i=0;i<typeIDs.length;i++) {
		if (typeIDs[i] == id) {
			document.getElementById(typeIDs[i]).style.display = "block";
		}
		else {
			document.getElementById(typeIDs[i]).style.display = "none";
		}
	}
}

function openWindow(url,name,width,height) {
	var posX = (screen.width - width)/2;
	var posY = (screen.height - height)/2;
	window.open(url,name,'width='+width+',height='+height+',resizable=yes,left='+posX+',top='+posY+',screenX='+posX+',screenY='+posY);
}

function showSubFoto(src) {
	var obj = document.getElementById('subMenuFoto');
	if (src) {
		obj.src = "http://www.dreamhouse.lt/foto/calculator/"+src+".jpg";
		obj.style.display = 'block';
	}
	else {
		obj.style.display = 'none';
	}
}

function changeComment(text) {
	var obj = document.getElementById('bigFotoComment');
	if (!text) text = "&nbsp;";
	obj.innerHTML = text;
}

/*
	TOOL TIP stuff
	Naudojamas: <div id="tooltip" style="position:absolute;display:none;"></div>
*/
var offsetx = 12; // i kaire nuo zymeklio
var offsety =  8; // i apacia nuo zymeklio

var IE = document.all?true:false;
function getmouseposition(e) {
	var obj = document.getElementById('tooltip');
	if (IE) { // jeigu IE
		var scrollx = document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft;
		var scrolly = document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop;
		mousex = event.clientX + scrollx;
		mousey = event.clientY + scrolly;
	}
	else { // jeigu NS
		mousex = e.pageX;
		mousey = e.pageY;
	}
	obj.style.left = (mousex+offsetx) + 'px';
	obj.style.top = (mousey+offsety) + 'px';
}

function showtip(tip,element) {
	if (!IE) document.captureEvents(Event.MOUSEMOVE); // jeigu NS
	document.onmousemove = getmouseposition;

	var obj = document.getElementById('tooltip');
	obj.innerHTML = tip;
	obj.style.display = 'block';
}

function hidetip() {
	document.getElementById('tooltip').style.display = 'none';
	if (!IE) document.releaseEvents(Event.MOUSEMOVE); // jeigu NS
	document.onmousemove = null;
}

var offsetx2 = -212; // i kaire nuo zymeklio
var offsety2 =  8; // i apacia nuo zymeklio

function getmouseposition2(e) {
	var obj = document.getElementById('tooltip2');
	if (IE) { // jeigu IE
		var scrollx = document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft;
		var scrolly = document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop;
		mousex = event.clientX + scrollx;
		mousey = event.clientY + scrolly;
	}
	else { // jeigu NS
		mousex = e.pageX;
		mousey = e.pageY;
	}
	obj.style.left = (mousex+offsetx2) + 'px';
	obj.style.top = (mousey+offsety2) + 'px';
}

function showtip2(tip,element) {
	if (!IE) document.captureEvents(Event.MOUSEMOVE); // jeigu NS
	document.onmousemove = getmouseposition2;

	var obj = document.getElementById('tooltip2');
	obj.innerHTML = tip;
	obj.style.display = 'block';
}

function hidetip2() {
	document.getElementById('tooltip2').style.display = 'none';
	if (!IE) document.releaseEvents(Event.MOUSEMOVE); // jeigu NS
	document.onmousemove = null;
}

/* selectbox styling script by Chionsas (Chionsas@centras.lt) */

/*
Sample:

 		<div id="kategorijos_select">
		 <select name="kategorija" id="Fkategorija" class="textonly">
			<option value="1" selected="selected">Asmeniniai puslapiai</option>
			<option value="2">Prezentaciniai tinklalapiai</option>
			<option value="3">Pramogos, þaidimai</option>
			<option value="4">Elektroninës paslaugos</option>

			<option value="5">Naujienos, þiniasklaida</option>
			<option value="6">Bendruomeniø portalai</option>
			<option value="7">WWW kûrëjai</option>
			<option value="8">Viena tema</option>
		 </select>

		 <div id="kategorijos_select_box" onmouseover="kategorijos.mouseon()" onmouseout="kategorijos.mouseout()" onclick="kategorijos.click()"></div>

		 <div id="kategorijos_select_dropdown" onmouseout="kategorijos.mouseout()" onmouseover="kategorijos.mouseon()"></div>
		 <script type="text/javascript">
			//<![CDATA[
			var kategorijos = new Dropdown('kategorijos','kategorijos_select_box','kategorijos_select_dropdown','Fkategorija');
			kategorijos.list();
			kategorijos.setActive('Kategorija<span class="printonly"><small>&nbsp;(pasirinkti vienà)</small></span>');
			//]]>
		 </script>
		</div>

*/

function Dropdown(handler,dropdownBoxDiv,dropdownListDiv,selectBoxId) {

	this.arrow = new Image();
	this.arrow.src = 'http://www.dreamhouse.lt/img/downarrow.gif';
	this.arrow_on = new Image();
	this.arrow_on.src = 'http://www.dreamhouse.lt/img/downarrow_on.gif';
	this.arrow_down = new Image();
	this.arrow_down.src = 'http://www.dreamhouse.lt/img/downarrow_down.gif';

	this.handler = handler;
	this.select = 0;
	this.dropdownBox = dropdownBoxDiv;
	this.dropdownList = dropdownListDiv;
	this.selectBox = selectBoxId;
	this.dropdownListTimer = null;

	this.list = function() {

		document.getElementById(this.dropdownBox).style.backgroundImage = "url('" + this.arrow.src + "')";

		var source = document.getElementById(this.selectBox);
		var dropdown = document.getElementById(this.dropdownList);
		dropdown.innerHTML = ""; // this doesn't quite comfort with standards - needs rewriting (using the W3C DOM)

		for (var i=0; i<source.options.length; i++) {
			var style = '';
			if (i==0) { style = " class=\"selOpt_first\""; } //pirmas
			else if (i==source.options.length-1) {  style = " class=\"selOpt_last\""; } //paskutinis
			var ID = this.selectBox.substring(1);
			var changeImage = " showSubFoto('"+ID+"_"+source.options[i].value+"');";
			dropdown.innerHTML += '<a href="javascript:' + this.handler + '.selectItem(' + i + ')" onmouseover="' + changeImage + ' return true" onmouseout = "return window.status=\'\'; return true"'+style+'>' + source.options[i].text + '</a>\n';
		}
	}

	this.selectItem = function(id) {
		var source = document.getElementById(this.selectBox);
		source.selectedIndex = id;
		this.setActive(source.options[id].text);
		this.click();
	}

	this.setActive = function(text) {
		document.getElementById(this.dropdownBox).innerHTML = text;
	}

	this.mouseon = function() {

		if (!this.select)
			document.getElementById(this.dropdownBox).style.backgroundImage = "url('" + this.arrow_on.src + "')";

		if (this.dropdownListTimer) {
			clearTimeout(this.dropdownListTimer);
			this.dropdownListTimer = null;
		}
	}

	this.click = function() {

		if (!this.select) {
			document.getElementById(this.dropdownBox).style.backgroundImage = "url('" + this.arrow_down.src + "')";
			document.getElementById(this.dropdownList).style.visibility = 'visible';
			this.select = 1;
		} else {
			document.getElementById(this.dropdownBox).style.backgroundImage = "url('" + this.arrow_on.src + "')";
			document.getElementById(this.dropdownList).style.visibility = 'hidden';
			this.select = 0;
		}
	}

	this.mouseout = function() {
		if (this.select) {
			this.dropdownListTimer = setTimeout(this.handler + ".click()",500);
		} else {
			document.getElementById(this.dropdownBox).style.backgroundImage = "url('" + this.arrow.src + "')";
		}
	}
}