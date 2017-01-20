Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		fnCreate = function(config, inWindow) {
			var
				baseConfig = {
					items: [{
						title: "Tab# 1",
						html: "Tab# 1"
					}, {
						title: "Tab# 2",
						html: "Tab# 2<br/>Line# 1<br/>Line# 2<br/>Line# 3<br/>Line# 4<br/>"
					}],
				},
				tp;

			if(!inWindow)
				config.renderTo = Ext.getBody();

			tp = Ext.create("Ext.tab.Panel", Ext.apply(baseConfig, config));

			if(inWindow)
				Ext.create("Ext.window.Window", {
					title: "Ext.tab.Panel",
					autoShow: true,
					layout: "fit",
					border: false,
					items: [tp]
				});
		},
		cbFrame = Ext.create("Ext.form.field.Checkbox", {
			fieldLabel: "frame",
			renderTo: Ext.getBody()
		}),
		cbFrameHeader = Ext.create("Ext.form.field.Checkbox", {
			fieldLabel: "frameHeader",
			renderTo: Ext.getBody()
		}),
		cbBodyBorder = Ext.create("Ext.form.field.Checkbox", {
			fieldLabel: "bodyBorder",
			renderTo: Ext.getBody()
		}),
		cbBorder = Ext.create("Ext.form.field.Checkbox", {
			fieldLabel: "border",
			renderTo: Ext.getBody()
		}),
		cbPlain = Ext.create("Ext.form.field.Checkbox", {
			fieldLabel: "plain",
			renderTo: Ext.getBody()
		}),
		btnCreate = Ext.create("Ext.button.Button", {
			text: "create",
			handler: function(btn, e) {
				var
					config = {
						frame: cbFrame.getValue(),
						frameHeader: cbFrameHeader.getValue(),
						bodyBorder: cbBodyBorder.getValue(),
						border: cbBorder.getValue(),
						plain: cbPlain.getValue(),
						defaults: {
							frame: cbFrame.getValue(),
						}
					};

				fnCreate(config, false);
				fnCreate(config, true);
			},
			renderTo: Ext.getBody()
		});
});