Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		cbRenderToBody = Ext.create("Ext.form.field.Checkbox");

	Ext.create("Ext.toolbar.Toolbar", {
		items: [
			"renderTo: Ext.getBody()",
			cbRenderToBody,
		{
			text: "create",
			handler: function(btn, e) {
				createWindow(200, 200, cbRenderToBody.getValue());
			}
		}],
		renderTo: Ext.getBody()
	});
});

function createWindow(height, width, isRenderToBody) {
	var
		dt = new Date(),
		config = {
			title: Ext.String.format("Window {0}", dt.getSeconds()),
			height: height,
			width: width,
			autoShow: true,
			listeners: {
				activate: function(component, eOpts) {
					if(window.console && console.log)
						console.log("Ext.window.Window.activate(%o)", arguments);
				},
				destroy: function(component, eOpts) {
					if(window.console && console.log)
						console.log("Ext.window.Window.destroy(%o)", arguments);
				},
				focus: function(component, The, eOpts) {
					if(window.console && console.log)
						console.log("Ext.window.Window.focus(%o)", arguments);
				},
				show: function(component, eOpts) {
					if(window.console && console.log)
						console.log("Ext.window.Window.show(%o)", arguments);
				}
			}
		};

	if(isRenderToBody)
		config.renderTo = Ext.getBody();

	return Ext.create("Ext.window.Window", config);
}