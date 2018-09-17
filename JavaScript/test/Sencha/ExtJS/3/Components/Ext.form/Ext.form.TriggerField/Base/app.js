Ext.BLANK_IMAGE_URL="../../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		triggerField = new Ext.form.TriggerField({
			//hideTrigger: true,
			renderTo: Ext.getBody()
		});

	triggerField.onTriggerClick = function(e) {
		if(window.console && console.log)
			console.log("onTriggerClick(%o)", arguments);
	};
});
