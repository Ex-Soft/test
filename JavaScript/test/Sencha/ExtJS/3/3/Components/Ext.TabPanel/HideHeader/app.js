Ext.BLANK_IMAGE_URL="../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3.3.1/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		p = new Ext.TabPanel({
			activeItem: 0,
			bbar: [{
				text: 'Hide',
				handler: function (btn, e) {
					if (window.console && console.log)
						console.log("Hide(%o)", arguments);

					var
						panel = btn.ownerCt.ownerCt;

					panel.setActiveTab(1);
					//panel.header.dom.style.display = "none";
					Ext.fly(panel.header).toggleClass("x-hide-display");
				}
			}, {
				text: 'Show',
				handler: function (btn, e) {
					if (window.console && console.log)
						console.log("Hide(%o)", arguments);

					var
						panel = btn.ownerCt.ownerCt;

					panel.setActiveTab(0);
					//panel.header.dom.style.display = "none";
					Ext.fly(panel.header).toggleClass("x-hide-display");
				}
			}],
			items: [{
				id: "card-1-tab-0",
				title: "card-1-tab-0",
				html: "card-1-tab-0"
			}, {
				id: "card-1-tab-1",
				title: "card-1-tab-1",
				html: "card-1-tab-1"
			}],
			renderTo: Ext.getBody()
		});
});
