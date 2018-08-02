Ext.BLANK_IMAGE_URL="../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3.3.1/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		p = new Ext.Panel({
			layout: "card",
			activeItem: 0,
			bbar: [{
				id: 'move-prev',
				text: 'Back',
				handler: function (btn, e) {
					if (window.console && console.log)
						console.log("Prev(%o)", arguments);

					var
						panel = btn.ownerCt.ownerCt,
						layout = panel.layout
						ai = layout.activeItem,
						n = parseInt(ai.id.substring(ai.id.length - 1), 10) - 1;

					if (n >= 0)
						layout.setActiveItem(n);
				}
			},
			'->',
			{
				id: 'move-next',
				text: 'Next',
				handler: function (btn, e) {
					if (window.console && console.log)
						console.log("Next(%o)", arguments);

					var
						panel = btn.ownerCt.ownerCt,
						layout = panel.layout
						ai = layout.activeItem,
						n = parseInt(ai.id.substring(ai.id.length - 1), 10) + 1;

					if (n < panel.items.length)
						layout.setActiveItem(n);
				}
			}],
			items: [{
				id: "card-0",
				html: "card-0"
			}, {
				id: "card-1",
				xtype: "tabpanel",
				activeItem: 0,
				items: [{
					id: "card-1-tab-0",
					title: "card-1-tab-0",
					html: "card-1-tab-0"
				}, {
					id: "card-1-tab-1",
					title: "card-1-tab-1",
					html: "card-1-tab-1"
				}]
			}, {
				id: "card-2",
				xtype: "tabpanel",
				activeItem: 0,
				items: [{
					id: "card-2-tab-0",
					title: "card-2-tab-0",
					html: "card-2-tab-0"
				}, {
					id: "card-2-tab-1",
					title: "card-2-tab-1",
					html: "card-2-tab-1"
				}]
			}],
			renderTo: Ext.getBody()
		});
});
