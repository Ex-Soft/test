Ext.onReady(function() {
	var
		p = new Ext.Panel({
			items: [{
				xtype: "label",
				text: " onClick ",
				listeners: {
					render: function(label, eOpts) {
						this.getEl().on("click", this.onClick);
					}
				},

				onClick: function(e, htmlElement, eOpts) {
					if(window.console && console.log)
						console.log("onClick(%o)", arguments);
				}
			}, {
				xtype: "label",
				text: " onDblClick ",
				listeners: {
					render: function(label, eOpts) {
						Ext.EventManager.addListener(this.getEl().dom, "dblclick", this.onDblClick, this);
					}
				},

				onDblClick: function(e, htmlElement, eOpts) {
					if(window.console && console.log)
						console.log("onDblClick(%o)", arguments);
				}
			}],
			renderTo: Ext.getBody()
		});
});
