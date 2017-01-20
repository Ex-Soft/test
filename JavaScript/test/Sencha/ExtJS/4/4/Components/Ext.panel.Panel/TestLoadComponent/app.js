Ext.onReady(function() {
	var
		panel1 = Ext.create("Ext.panel.Panel", {
			renderTo: Ext.get("divPanel1")
		}),
		panel3 = Ext.create("Ext.panel.Panel", {
			loader: {
				autoLoad: false,
				url: "content.html",
				script: true,
				renderer: "component"
			},
			renderTo: Ext.get("divPanel3")
		}),
		config = {
			items: [{
				xtype: "textfield",
				fieldLabel: "Label"
			}]
		},
		configArray = [{
			xtype: "textfield",
			fieldLabel: "Label"
		}];

	Ext.create("Ext.toolbar.Toolbar", {
		items: [{
			xtype: "button",
			text: "add",
			handler: function() {
				addByAdd(panel1, configArray);
			}
		}, {
			xtype: "button",
			text: "render",
			handler: function() {
				addByRender(config)
			}
		}, {
			xtype: "button",
			text: "load",
			handler: function() {
				panel3.getLoader().load();
			}
		}],
		renderTo: Ext.getBody()
	});
});

function addByAdd(panel, config) {
	//panel.removeAll();
	panel.add(config);
}

function addByRender(config) {
	var
		panel = Ext.create("Ext.panel.Panel", config);

	panel.render(Ext.get("divPanel2"));
}