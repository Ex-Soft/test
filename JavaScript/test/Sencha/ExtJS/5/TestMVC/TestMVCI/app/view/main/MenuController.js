Ext.define('TestMVCI.view.main.MenuController', {
    extend: 'Ext.app.ViewController',

    alias: 'controller.mainmenu',
	
    onMenuClick: function(menu, item, e, eOpts) {
        if(window.console && console.log)
            console.log("onMenuClick(%o)", arguments);
    }
});