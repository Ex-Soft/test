Ext.define('TestMVCI.view.BaseController', {
    extend: 'Ext.app.ViewController',

    alias: 'controller.basecontroller',
	
	onSaveClick: function(btn, e, eOpts) {
		if(window.console && console.log)
			console.log("basecontroller.onSaveClick(%o)", arguments);
		
		var
			btn = this.lookupReference("btnSave"),
			win = btn.up("window");
		
		if(window.console && console.log)
			console.log("basecontroller.btn(%o), win.title=\"%s\"", btn, win.title);
	},
	
	onCancelClick: function(btn, e, eOpts) {
		if(window.console && console.log)
			console.log("basecontroller.onCancelClick(%o)", arguments);
	}
});