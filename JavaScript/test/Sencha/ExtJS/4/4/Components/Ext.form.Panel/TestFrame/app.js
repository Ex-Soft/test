Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		f = Ext.create("Ext.form.Panel", {
			frame: true,
			items: [{
				xtype: "label",
				text: "label"
			}]
		}),
		w = Ext.create("Ext.window.Window", {
			title: "Test Frame",
			height: (window.innerHeight ? window.innerHeight : (document.documentElement && document.documentElement.clientHeight ? document.documentElement.clientHeight : (document.body.clientHeight ? document.body.clientHeight : 400))) - 200,
			width: (window.innerWidth ? window.innerWidth : (document.documentElement && document.documentElement.clientWidth ? document.documentElement.clientWidth : (document.body.clientWidth ? document.body.clientWidth : 800))) - 200,
			autoScrol: true,
			layout: "fit",
			autoDestroy: true,
			buttons: [
				{
					text: "Close",
					handler: function(btn, e) {
						w.close();
					}
				}
			],
			items: [f]
		});

	w.show();
});
