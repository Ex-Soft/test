Ext.onReady(function() {
	Ext.create("Ext.form.Panel", {
		title: "Ext.form.Panel# 1",
		items: [{
			xtype: "textfield",
			fieldLabel: "textFieldLabel"
		}, {
			xtype: "combobox",
			fieldLabel: "comboBoxFieldLabel"
		}],
		renderTo: Ext.get("divFormPanel1")
	});

	Ext.create("Ext.panel.Panel", {
		title: "Ext.panel.Panel# 1",
		items: [{
			xtype: "textfield",
			fieldLabel: "textFieldLabel"
		}, {
			xtype: "combobox",
			fieldLabel: "comboBoxFieldLabel"
		}],
		renderTo: Ext.get("divPanelPanel1")
	});

	Ext.create("Ext.form.Panel", {
		title: "Ext.form.Panel# 2",
		defaults: {
			labelWidth: 300
		},
		items: [{
			xtype: "textfield",
			fieldLabel: "textFieldLabel"
		}, {
			xtype: "combobox",
			fieldLabel: "comboBoxFieldLabel"
		}],
		renderTo: Ext.get("divFormPanel2")
	});

	Ext.create("Ext.panel.Panel", {
		title: "Ext.form.Panel# 2",
		defaults: {
			labelWidth: 300
		},
		items: [{
			xtype: "textfield",
			fieldLabel: "textFieldLabel"
		}, {
			xtype: "combobox",
			fieldLabel: "comboBoxFieldLabel"
		}],
		renderTo: Ext.get("divPanelPanel2")
	});

	Ext.create("Ext.form.Panel", {
		title: "Ext.form.Panel# 3",
		defaults: {
			labelWidth: 200,
			anchor: "100%"
		},
		items: [{
			xtype: "textfield",
			fieldLabel: "textFieldLabel"
		}, {
			xtype: "combobox",
			fieldLabel: "comboBoxFieldLabel"
		}],
		renderTo: Ext.get("divFormPanel3")
	});

	Ext.create("Ext.panel.Panel", {
		title: "Ext.panel.Panel# 3",
		//layout: "anchor",
		defaults: {
			labelWidth: 200,
			anchor: "100%"
		},
		items: [{
			xtype: "textfield",
			fieldLabel: "textFieldLabel"
		}, {
			xtype: "combobox",
			fieldLabel: "comboBoxFieldLabel"
		}],
		renderTo: Ext.get("divPanelPanel3")
	});
});