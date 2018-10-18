Ext.BLANK_IMAGE_URL="../../../../../ExtJS/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		f=new Ext.FormPanel({
			frame: true,
			layout: "column",
			defaults: {
				columnWidth: 0.5,
				layout: "form"
			},
			items: [{
				defaults: {
					xtype: "fieldset",
					layout: "form",
					anchor: "100%",
					autoHeight: true
				},
				items: [{
					title: "Fieldset 1",
					defaultType: "textfield",
					defaults: {
						anchor: "-20",
						allowBlank: false
					},
					items:[{
						fieldLabel: "Field 1"
					},{
						fieldLabel: "Field 2"
					}] 
				}]
			}, {
				defaults: {
					xtype: "fieldset",
					layout: "form",
					anchor: "100%",
					autoHeight: true
				},
				items:[{
					title: "Fieldset 2",
					defaultType: "textfield",
					defaults: {
						anchor: "-20",
						allowBlank: false
					},
					items:[{
						fieldLabel: "Field 3"
					},{
						fieldLabel: "Field 4"
					}]
				}] 
			}]
		}),
		win = new Ext.Window({
			layout: "fit",
			title: "Test Forms Layouts",
			height: 820,
			width: 800,
			border: false,
			closable: false,
			collapsible: true,
			minWidth: 280,
			minHeight: 140,
			items: [f] 
		});

	win.show();
});
