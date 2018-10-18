Ext.BLANK_IMAGE_URL="../../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.ns("Test");

Test.CustomTriggerField = Ext.extend(Ext.form.TriggerField, {
	onTriggerClick: function(e, target, eOpts) {
		Test.CustomTriggerField.superclass.onTriggerClick.apply(this, arguments);

		if(window.console && console.log)
			console.log("CustomTriggerField.onTriggerClick(%o)", arguments);
	}
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		triggerField = new Test.CustomTriggerField({
			//hideTrigger: true,
			renderTo: Ext.getBody()
		});
});
