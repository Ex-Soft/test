Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		form = Ext.create("Ext.form.Panel", {
			frame: true,
			items: [{
				xtype: "combobox",
				name: "TestComboBox",
				fieldLabel: "TestComboBox",
				valueField: "Id",
				displayField: "Name",
				editable: false,
				store: {
					autoDestroy: true,
					autoLoad: false,
					fields: [
						{ name: "Id", type: "int" },
						{ name: "Name", type: "string" }
					],
					proxy: {
						type: "ajax",
						url: "ComboBox.json",
						reader: {
							type: "json",
							idProperty: "Id",
							root: "data"
						}
					},
					listeners: {
						beforeload: function(store, operation) {
							if(window.console && console.log)
								console.log("store.onBeforeLoad(%o)", arguments);
						},
						load: function(store, records, successful, eOpts) {
							if(window.console && console.log)
								console.log("store.onLoad(%o)", arguments);
						}
					}
				}
			}],
			buttons: [{
				text: "setValue()",
				handler: function(btn, e) {
					var
						form = btn.up("form").getForm(),
						cb = form.findField("TestComboBox");

					cb.getStore().load(function() {
						cb.lastQuery = cb.allQuery;

						if(window.console && console.log)
						{
							console.log("store.load(%o)", arguments);
							console.log("store.loading = %s", this.loading);
						}
						
						form.setValues({
							TestComboBox: 3
						});
					});
				}
			}, {
				text: "getValue()",
				handler: function(btn, e) {
					var
						form = btn.up("form").getForm(),
						cb = form.findField("TestComboBox"),
						value = cb.getValue(),
						values = form.getValues();

					if(window.console && console.log)
						console.log("value = %o values = %o", value, values);
				}
			}]
		});

	Ext.create("Ext.toolbar.Toolbar", {
		items: [{
			text: "show",
			handler: function(btn, e) {
				Ext.create("Ext.window.Window", {
					autoShow: true,
					border: false,
					layout: "fit",
					height: 300,
					width: 300,
					tools: [{
						type: "help"
					}, {
						type: "gear"
					}],
					items: [form]
				});
			}
		}],
		renderTo: Ext.getBody()
	});
});