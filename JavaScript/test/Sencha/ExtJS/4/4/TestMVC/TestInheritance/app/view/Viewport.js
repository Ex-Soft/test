Ext.define("AM.view.Viewport", {
	extend: "Ext.container.Viewport",
	layout: "border",
	items: [{
		xtype: "toolbar",
		region: "north",
		height: 26,
		items: [{
			text: "Base",
			handler: function(btn, e) {
				Ext.create("Ext.window.Window", {
					title: "Base",
					autoShow: true,
					height: 300,
					width: 300,
					layout: "fit",
					items: [{
						xtype: "baseview"
					}]
				})
			}
		}, {
			text: "Derived",
			handler: function(btn, e) {
				Ext.create("Ext.window.Window", {
					title: "Derived",
					autoShow: true,
					height: 300,
					width: 300,
					layout: "fit",
					items: [{
						xtype: "derivedview"
					}]
				})
			}
		}, {
			text: "Query",
			handler: function(btn, e) {
				var tmp = Ext.ComponentQuery.query("baseview[strong=Derived]");

				if(tmp)
					;
			}
		}]
	}, {
		region: "center"
	}]
});