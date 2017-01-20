Ext.define('TestInheritance.view.main.MenuController', {
    extend: 'Ext.app.ViewController',

    alias: 'controller.mainmenu',
	
	requires: [
		"TestInheritance.view.Base",
		"TestInheritance.view.Derived"
	],
	
	onMenuClick: function(menu, item, e, eOpts) {
		if(window.console && console.log)
			console.log("onMenuClick(%o)", arguments);

		var
			_xtype;
			
		switch(item.text)
		{
			case "Base": _xtype = "baseview"; break;
			case "Derived": _xtype = "derivedview"; break;
		}
		
		Ext.create("Ext.window.Window", {
			title: item.text,
			autoShow: true,
			height: 300,
			width: 300,
			layout: "fit",
			items: [{
				xtype: _xtype
			}]
		})
	}
});