(function(win) {
	var
		global = win;

	if (typeof(dll) === "undefined")
    {
        //var addon = require('./build/Release/addon');
	    //global.dll = new addon.BaseObjectWrap();
        global.dll = require('electron').remote.getGlobal('dll');
    }

})(window);

function Init() {
    if (!window.dll)
        return;
    
    window.dll.init();
}

function SayHello() {
    if (!window.dll)
        return;
    
    window.dll.sayHello();
}

function GetNCLButtonDblClk() {
    var
        span;

    if (!window.dll
        || !(span = document.getElementById("spanGetNCLButtonDblClk")))
        return;
    
    span.innerHTML = window.dll.getNCLButtonDblClk();
}

function GetNCRButtonDblClk() {
    var
        span;

    if (!window.dll
        || !(span = document.getElementById("spanGetNCRButtonDblClk")))
        return;
    
    span.innerHTML = window.dll.getNCRButtonDblClk();
}

function GetRButtonDblClk() {
    var
        span;

    if (!window.dll
        || !(span = document.getElementById("spanGetRButtonDblClk")))
        return;
    
    span.innerHTML = window.dll.getRButtonDblClk();
}

function GetLButtonDblClk() {
    var
        span;

    if (!window.dll
        || !(span = document.getElementById("spanGetLButtonDblClk")))
        return;
    
    span.innerHTML = window.dll.getLButtonDblClk();
}
