function ConfirmSubmit(mes)
		{
			return window.confirm(mes);
		}
//����������� ������������ �� ������� ��������� features
function hasSupport() {

	if (typeof hasSupport.support != "undefined")
		return hasSupport.support;
	
	var ie55 = /msie 5\.[56789]/i.test( navigator.userAgent );
	
	hasSupport.support = ( typeof document.implementation != "undefined" &&
			document.implementation.hasFeature( "html", "1.0" ) || ie55 )
			
	// IE55 has a serious DOM1 bug... Patch it!
	if ( ie55 ) {
		document._getElementsByTagName = document.getElementsByTagName;
		document.getElementsByTagName = function ( sTagName ) {
			if ( sTagName == "*" )
				return document.all;
			else
				return document._getElementsByTagName( sTagName );
		};
	}

	return hasSupport.support;
}

///////////////////////////////////////////////////////////////////////////////////
// The constructor for tab panes
//
// el : HTMLElement	The html element used to represent the tab panel
// bUseCookie : Boolean	Optional. Default is true. Using cookies or not
//
function WebFXTabPane( el, bUseCookie ) {
	if ( !hasSupport() || el == null ) return;
	
	this.element = el;
	this.element.tabPane = this;
	this.pages = [];
	this.selectedIndex = null;
	this.useCookie = bUseCookie != null ? bUseCookie : true;
	
	// add class name tag to class name
	this.element.className = this.classNameTag + " " + this.element.className;
	
	// add tab row
	this.tabRow = document.createElement( "div" );
	this.tabRow.className = "tab-row";
	el.insertBefore( this.tabRow, el.firstChild );

	var tabIndex = 0;
	if ( this.useCookie ) {
		tabIndex = Number( WebFXTabPane.getCookie( "webfxtab_" + this.element.id ) );
		if ( isNaN( tabIndex ) )
			tabIndex = 0;
	}
	this.selectedIndex = tabIndex;
	
	// loop through child nodes and add them
	var cs = el.childNodes;
	var n;
	for (var i = 0; i < cs.length; i++) {
		if (cs[i].nodeType == 1 && cs[i].className == "tab-page") {
			this.addTabPage( cs[i] );
		}
	}
}

WebFXTabPane.prototype = {

	classNameTag:		"dynamic-tab-pane-control",

	setSelectedIndex:	function ( n ) {
		if (this.selectedIndex != n) {
			if (this.selectedIndex != null && this.pages[ this.selectedIndex ] != null )
				this.pages[ this.selectedIndex ].hide();
			this.selectedIndex = n;
			this.pages[ this.selectedIndex ].show();
			
			if ( this.useCookie )
				WebFXTabPane.setCookie( "webfxtab_" + this.element.id, n );	// session cookie
		}
	},
	
	getSelectedIndex:	function () {
		return this.selectedIndex;
	},
	
	addTabPage:	function ( oElement, CallbackFunction ) {
		if ( !hasSupport() ) return;
		
		if ( oElement.tabPage == this )	// already added
			return oElement.tabPage;
	
		var n = this.pages.length;
		var tp = this.pages[n] = new WebFXTabPage( oElement, this, n, CallbackFunction );
		tp.tabPane = this;
		
		// move the tab out of the box
		this.tabRow.appendChild( tp.tab );
				
		if ( n == this.selectedIndex )
			tp.show();
		else
			tp.hide();
			
		return tp;
	}	
};

// Cookie handling
WebFXTabPane.setCookie = function ( sName, sValue, nDays ) {
	var expires = "";
	if ( nDays ) {
		var d = new Date();
		d.setTime( d.getTime() + nDays * 24 * 60 * 60 * 1000 );
		expires = "; expires=" + d.toGMTString();
	}

	document.cookie = sName + "=" + sValue + expires + "; path=/";
};

WebFXTabPane.getCookie = function (sName) {
	var re = new RegExp( "(\;|^)[^;]*(" + sName + ")\=([^;]*)(;|$)" );
	var res = re.exec( document.cookie );
	return res != null ? res[3] : null;
};

WebFXTabPane.removeCookie = function ( name ) {
	setCookie( name, "", -1 );
};

///////////////////////////////////////////////////////////////////////////////////
// The constructor for tab pages. ��� �� ������������
// ������������ WebFXTabPage.addTabPage 
//
// el : HTMLElement		The html element used to represent the tab pane
// tabPane : WebFXTabPane	The parent tab pane
// nindex :	Number		The index of the page in the parent pane page array
//
function WebFXTabPage( el, tabPane, nIndex, CallbackFunction ) {
	if ( !hasSupport() || el == null ) return;
	
	this.element = el;
	this.element.tabPage = this;
	this.index = nIndex;
	this.CallbackFunction = CallbackFunction;
	
	var cs = el.childNodes;
	for (var i = 0; i < cs.length; i++) {
		if (cs[i].nodeType == 1 && cs[i].className == "tab") {
			this.tab = cs[i];
			break;
		}
	}
	
	// insert a tag around content to support keyboard navigation
	var a = document.createElement( "A" );
	a.href = "javascript:void 0;";
	while ( this.tab.hasChildNodes() )
		a.appendChild( this.tab.firstChild );
	this.tab.appendChild( a );
	
	// hook up events, using DOM0
	var oThis = this;
	this.tab.onclick = function () { oThis.select(); };
	this.tab.onmouseover = function () { WebFXTabPage.tabOver( oThis ); };
	this.tab.onmouseout = function () { WebFXTabPage.tabOut( oThis ); };
}

WebFXTabPage.prototype = {
	show:	function () {
		var el = this.tab;
		var s = el.className + " selected";
		s = s.replace(/ +/g, " ");
		el.className = s;
		
		if(this.CallbackFunction)
			this.CallbackFunction(this.index);

		this.element.style.display = "block";
	},

	hide:	function () {
		var el = this.tab;
		var s = el.className;
		s = s.replace(/ selected/g, "");
		el.className = s;

		this.element.style.display = "none";
	},
	
	select:	function () {
		this.tabPane.setSelectedIndex( this.index );
	}
};

WebFXTabPage.tabOver = function ( tabpage ) {
	var el = tabpage.tab;
	var s = el.className + " hover";
	s = s.replace(/ +/g, " ");
	el.className = s;
};

WebFXTabPage.tabOut = function ( tabpage ) {
	var el = tabpage.tab;
	var s = el.className;
	s = s.replace(/ hover/g, "");
	el.className = s;
};


// This function initializes all uninitialized tab panes and tab pages
function setupAllTabs() {
	if ( !hasSupport() ) return;

	var all = document.getElementsByTagName( "*" );
	var l = all.length;
	var tabPaneRe = /tab\-pane/;
	var tabPageRe = /tab\-page/;
	var cn, el;
	var parentTabPane;
	
	for ( var i = 0; i < l; i++ ) {
		el = all[i]
		cn = el.className;

		// no className
		if ( cn == "" ) continue;
		
		// uninitiated tab pane
		if ( tabPaneRe.test( cn ) && !el.tabPane )
			new WebFXTabPane( el );
	
		// unitiated tab page wit a valid tab pane parent
		else if ( tabPageRe.test( cn ) && !el.tabPage &&
					tabPaneRe.test( el.parentNode.className ) ) {
			el.parentNode.tabPane.addTabPage( el );			
		}
	}
}


// initialization hook up

// DOM2
if ( typeof window.addEventListener != "undefined" )
	window.addEventListener( "load", setupAllTabs, false );

// IE 
else if ( typeof window.attachEvent != "undefined" )
	window.attachEvent( "onload", setupAllTabs );

else {
	if ( window.onload != null ) {
		var oldOnload = window.onload;
		window.onload = function ( e ) {
			oldOnload( e );
			setupAllTabs();
		};
	}
	else 
		window.onload = setupAllTabs;
}