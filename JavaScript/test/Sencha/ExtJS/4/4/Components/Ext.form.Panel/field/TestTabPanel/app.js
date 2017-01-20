Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		f = Ext.create("Ext.form.Panel", {
			frame: true,
			trackResetOnLoad: true,
			items: [{
				xtype: "textfield",
				name: "TextFieldOnForm",
				fieldLabel: "TextFieldOnForm"
			}, {
				xtype: "tabpanel",
				border: false,
				items: [{
					title: "Tab1",
					frame: true,
					items: [{
						xtype: "textfield",
						name: "TextFieldOnTab1",
						fieldLabel: "TextFieldOnTab1"
					}]
				}, {
					title: "Tab2",
					frame: true,
					items: [{
						xtype: "textfield",
						name: "TextFieldOnTab2",
						fieldLabel: "TextFieldOnTab2"
					}]
				}, {
					title: "Tab3",
					//frame: true,
					items: [{
						xtype: "textfield",
						name: "TextFieldOnTab3",
						fieldLabel: "TextFieldOnTab3"
					}]
				}]
			}],
			dockedItems: [{
				xtype: "toolbar",
				dock: "top",
				items: [{
					text: "getFields()",
					handler: function(btn, e) {
						var
							f = btn.up("form").getForm(),
							fields = f.getFields();

						if(fields)
							;
					},
				}, {
					text: "setValues()",
					handler: function(btn, e) {
						var
							values = {
								TextFieldOnForm: "TextFieldOnForm",
								TextFieldOnTab1: "TextFieldOnTab1",
								TextFieldOnTab2: "TextFieldOnTab2",
								TextFieldOnTab3: "TextFieldOnTab3"
							},
							f = btn.up("form").getForm();

						f.setValues(values);
					}
				}, {
					text: "getValues()",
					handler: function(btn, e) {
						var
							values,
							f = btn.up("form").getForm();

						values = f.getValues(false, false);

						if(values)
							;
					}
				}]
			}],
		}),
		w = Ext.create("Ext.window.Window", {
			title: "Test Ext.form.Panel with Ext.tab.Panel",
			height: 600,
			width: 600,
			layout: "fit",
			autoDestroy: true,
			border: 0, // !!!
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