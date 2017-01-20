Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		menuItem2 = Ext.create("Ext.form.field.Text", {
			value: "blah-blah-blah",
			selectOnFocus: true,
			readOnly: true,
			fieldLabel: "label",
			listeners: {
				activate: function(field, eOpts) {
					if(window.console && console.log)
						console.log("Ext.form.field.Text.activate(%o)", arguments);
				},
				deactivate: function(field, eOpts) {
					if(window.console && console.log)
						console.log("Ext.form.field.Text.deactivate(%o)", arguments);
				},
				render: function(field, eOpts) {
					if(window.console && console.log)
						console.log("Ext.form.field.Text.render(%o)", arguments);
				},
				afterrender: function(field, eOpts) {
					if(window.console && console.log)
						console.log("Ext.form.field.Text.afterrender(%o)", arguments);
				},
				boxready: function(field, width, height, eOpts) {
					if(window.console && console.log)
						console.log("Ext.form.field.Text.boxready(%o)", arguments);
				},
				focus: function(field, eOpts) {
					if(window.console && console.log)
						console.log("Ext.form.field.Text.focus(%o)", arguments);
				},
				blur: function(field, The, eOpts) {
					if(window.console && console.log)
						console.log("Ext.form.field.Text.blur(%o)", arguments);
				},
				show: function(field, eOpts) {
					if(window.console && console.log)
						console.log("Ext.form.field.Text.show(%o)", arguments);
				},
				hide: function(field, eOpts) {
					if(window.console && console.log)
						console.log("Ext.form.field.Text.hide(%o)", arguments);
				},
				beforedestroy: function(field, eOpts) {
					if(window.console && console.log)
						console.log("Ext.form.field.Text.beforedestroy(%o)", arguments);
				},
				destroy: function(field, eOpts) {
					if(window.console && console.log)
						console.log("Ext.form.field.Text.destroy(%o)", arguments);
				}
			}
		}),
		toolbar = Ext.create("Ext.toolbar.Toolbar", {
			items: [
				{
					xtype: "button",
					text: "Menu",
					menu: {
						xtype: "menu",
						showSeparator: false,
						items: [{
							text: "#1",
							handler: function(btn, e) {
							}
						}, {
							text: "input# 1",
							menu: {
								showSeparator: false,
								items: [{
									xtype: "textfield"
								}]
							}
						}, {
							text: "input# 2",
							menu: {
								showSeparator: false,
								items: [{
									xtype: "textfield"
								},
									menuItem2
								]
							}
						}]
					}
				}
			]
		});

	Ext.create("Ext.panel.Panel", {
		renderTo: Ext.getBody(),
		tbar: toolbar,
		html: "blah"
	});

	if(toolbar)
		;
});
