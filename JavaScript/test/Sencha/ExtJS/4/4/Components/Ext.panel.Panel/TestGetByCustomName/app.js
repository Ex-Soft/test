Ext.define("TestPanel", {
	extend: "Ext.panel.Panel",
	alias: "widget.testpanel"/*,

	initComponent: function() {
		this.callParent();
	}*/
});

Ext.onReady(function() {
	var
		inputCustomName = Ext.create("Ext.form.field.Text", {
			value: "Label1"
		}),
		elementValue = Ext.create("Ext.form.field.Text");

	Ext.create("TestPanel", {
		dockedItems: [{
			xtype: "toolbar",
			dock: "top",
			items: [
				inputCustomName,
			{
				xtype: "button",
				text: "getByCustomName",
				handler: function(btn, e) {
					var
						p,
						el;

					if((p = this.up("testpanel"))
						&& (el = p.getByCustomName(inputCustomName.getValue())))
						elementValue.setValue(el.text);
				}
			},
				elementValue,
			{
				xtype: "button",
				text: "getCustomNames",
				handler: function(btn, e) {
					var
						p,
						customNames;

					if(p = this.up("testpanel"))
						customNames = p.getCustomNames();

					if(window.console && console.log)
						console.log("%o", customNames);
				}
			}]
		}],
		items: [{
			xtype: "label",
			customName: "Label1",
			text: "Label# 1"
		}, {
			xtype: "label",
			customName: "Label2",
			text: "Label# 2"
		}, {
			xtype: "label",
			customName: "Label3",
			text: "Label# 3"
		}, {
			xtype: "label",
			customName: "Label4",
			text: "Label# 4",
		}, {
			xtype: "container",
			items: [{
				xtype: "label",
				customName: "Label5",
				text: "Label# 5"
			}, {
				xtype: "label",
				customName: "Label6",
				text: "Label# 6"
			}, {
				xtype: "panel",
				items: [{
					xtype: "label",
					customName: "Label9",
					text: "Label# 9"
				}, {
					xtype: "label",
					customName: "Label10",
					text: "Label# 10"
				}]
			}]
		}, {
			xtype: "panel",
			items: [{
				xtype: "label",
				customName: "Label7",
				text: "Label# 7"
			}, {
				xtype: "label",
				customName: "Label8",
				text: "Label# 8"
			}, {
				xtype: "container",
				items: [{
					xtype: "label",
					customName: "Label11",
					text: "Label# 11"
				}, {
					xtype: "label",
					customName: "Label12",
					text: "Label# 12"
				}]
			}]
		}],
		renderTo: Ext.getBody(),

		getByCustomName: function(customName, customAttributeName) {
			if(typeof customName !== "string"
				|| !(customName = Ext.String.trim(customName)).length)
			return null;

			customAttributeName = customAttributeName || "customName";

			return this.findByCustomName(this.items.items, customName, customAttributeName);
		},
		
		findByCustomName: function(items, customName, customAttributeName) {
			var
				item,
				foundedItem;

			for(var i=0, len=items.length; i<len; ++i)
			{
				item = items[i];

				if(window.console && console.log)
					console.log("%o", item);

				if(item[customAttributeName] === customName)
					foundedItem = item;
				else if(item.isContainer || item.isPanel)
					foundedItem = this.findByCustomName(item.items.items, customName, customAttributeName);
				
				if(foundedItem)
					break;
			}
			
			return foundedItem;
		},

		getCustomNames: function(items, customAttributeName) {
			var
				item,
				customNames = [];

			items = items || this.items.items;
			customAttributeName = customAttributeName || "customName";

			for(var i=0, len=items.length; i<len; ++i)
			{
				item = items[i];

				if(window.console && console.log)
					console.log("%o", item);

				if(item[customAttributeName])
					customNames.push(item[customAttributeName]);
				else if(item.isContainer || item.isPanel)
					customNames = customNames.concat(this.getCustomNames(item.items.items, customAttributeName));
			}
			
			return customNames;
		}
	});
});