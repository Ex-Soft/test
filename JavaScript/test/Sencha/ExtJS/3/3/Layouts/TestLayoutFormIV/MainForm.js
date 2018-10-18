Ext.BLANK_IMAGE_URL="../../../../../ExtJS/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		/*p=new Ext.Panel({
			html: "<div id=\"DivSummary\"></div>",
			style: {
				padding: "10px"
			}
		}),*/
		p=new Ext.Container({
			html: "<div id=\"DivSummary\"></div>",
			style: {
				padding: "10px"
			}
		}),
		f=new Ext.FormPanel({
			frame: true,
			items: [{
				layout: "column",
				defaults: {
					columnWidth: 0.5,
					layout: "form"
				},
				items: [{
					defaults: {
						anchor: "100%"
					},
					items: [{
						xtype: "textarea",
						fieldLabel: "TextArea"
					}] 
				}, {
					defaults: {
						anchor: "100%"
					},
					items: [p] 
				}]
			}],
			buttons: [{
				text: "DoIt!",
				handler: function() {
					tpl.overwrite("DivSummary",summary);
				}
			}]
		}),
		win = new Ext.Window({
			layout: "fit",
			title: "Test Forms Layouts",
			height: 400,
			width: 800,
			border: false,
			closable: false,
			collapsible: true,
			minWidth: 280,
			minHeight: 140,
			items: [f] 
		}),
		summary={
			OrderVolume: "OrderVolume",
			OrderCount: "OrderCount",
			OrderWeight: "OrderWeight"
		},
		tpl=new Ext.XTemplate(
			"OrderVolume: {OrderVolume}"
		);

	win.show();
});
