Ext.onReady(function() {
	Ext.create("Ext.panel.Panel", {
		title: "Ext.panel.Panel# 1",
		items: [{
			layout: "column",
			defaults: {
				columnWidth: .5,
				layout: "anchor"
			},
			items:[{
				items: [{
					xtype: "textfield",
					fieldLabel: "textFieldLabel"
				}, {
					xtype: "combobox",
					fieldLabel: "comboBoxFieldLabel"
				}]
			}, {
				items: [{
					xtype: "textfield",
					fieldLabel: "textFieldLabel"
				}, {
					xtype: "combobox",
					fieldLabel: "comboBoxFieldLabel"
				}]
			}]
		}],
		renderTo: Ext.get("divPanelPanel1")
	});

	Ext.create("Ext.panel.Panel", {
		title: "Ext.panel.Panel# 2",
		items: [{
			layout: "column",
			defaults: {
				layout: "anchor"
			},
			items:[{
				columnWidth: .5,
				items: [{
					xtype: "textfield",
					fieldLabel: "textFieldLabel"
				}, {
					xtype: "combobox",
					fieldLabel: "comboBoxFieldLabel"
				}]
			}, {
				columnWidth: .3,
				items: [{
					xtype: "textfield",
					fieldLabel: "textFieldLabel"
				}, {
					xtype: "combobox",
					fieldLabel: "comboBoxFieldLabel"
				}]
			}, {
				columnWidth: .2,
				items: [{
					xtype: "textfield",
					fieldLabel: "textFieldLabel"
				}, {
					xtype: "combobox",
					fieldLabel: "comboBoxFieldLabel"
				}]
			}]
		}],
		renderTo: Ext.get("divPanelPanel2")
	});

	Ext.create("Ext.panel.Panel", {
		title: "Ext.panel.Panel# 3",
		items: [{
			layout: "fit",
			defaults: {
				layout: "anchor"
			},
			items:[{
				columnWidth: .5,
				items: [{
					xtype: "textfield",
					fieldLabel: "textFieldLabel"
				}, {
					xtype: "combobox",
					fieldLabel: "comboBoxFieldLabel"
				}]
			}, {
				columnWidth: .3,
				items: [{
					xtype: "textfield",
					fieldLabel: "textFieldLabel"
				}, {
					xtype: "combobox",
					fieldLabel: "comboBoxFieldLabel"
				}]
			}, {
				columnWidth: .2,
				items: [{
					xtype: "textfield",
					fieldLabel: "textFieldLabel"
				}, {
					xtype: "combobox",
					fieldLabel: "comboBoxFieldLabel"
				}]
			}]
		}],
		renderTo: Ext.get("divPanelPanel3")
	});
});