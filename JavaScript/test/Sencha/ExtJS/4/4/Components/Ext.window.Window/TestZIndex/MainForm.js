Ext.onReady(function() {
	var
		w = [],
		cbRenderToBody = Ext.create("Ext.form.field.Checkbox");

	Ext.create("Ext.toolbar.Toolbar", {
		items: [
			"renderTo: Ext.getBody()",
			cbRenderToBody,
		{
			text: "Window# 0 (create)",
			handler: function(btn, e) {
				w[0] = createWindow(0, 200, 200, cbRenderToBody.getValue());
			}
		}, {
			text: "Window# 0 (show)",
			handler: function(btn, e) {
				w[0].show();
			}
		}, {
			text: "Window# 0 (focus)",
			handler: function(btn, e) {
				w[0].focus();
			}
		}, {
			text: "Window# 1 (create)",
			handler: function(btn, e) {
				w[1] = createWindow(1, 400, 400, cbRenderToBody.getValue());
			}
		}, {
			text: "Window# 1 (show)",
			handler: function(btn, e) {
				w[1].show();
			}
		}, {
			text: "Window# 1 (focus)",
			handler: function(btn, e) {
				w[1].focus();
			}
		}],
		renderTo: Ext.getBody()
	});
});

function createWindow(n, height, width, isRenderToBody) {
	var
		config = {
			title: "Window# "+n,
			height: height,
			width: width
		};

	if(isRenderToBody)
		config.renderTo = Ext.getBody();

	return Ext.create("Ext.window.Window", config);
}