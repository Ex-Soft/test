Ext.define('TestInheritance.view.DerivedController', {
    extend: 'TestInheritance.view.BaseController',

    alias: 'controller.derivedcontroller',
	
	onSaveClick: function(btn, e, eOpts) {
		if(window.console && console.log)
			console.log("derivedcontroller.onSaveClick(%o)", arguments);
		
		this.callParent(arguments);
	},
	
	onCancelClick: function(btn, e, eOpts) {
		if(window.console && console.log)
			console.log("derivedcontroller.onCancelClick(%o)", arguments);
	}
});