Ext.BLANK_IMAGE_URL="../../../../../ExtJS/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		f=new Ext.FormPanel({
			frame: true,
			items: [{
				xtype: "textfield",
				fieldLabel: "TextField1",
				labelStyle: "text-align: right;"
			}, {
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
						defaults: {
							anchor: "-20",
							allowBlank: false
						},
						items: [{
							xtype: "textfield",
							fieldLabel: "TextFieldL1"
						}, {
							xtype: "textfield",
							fieldLabel: "TextFieldL2"
						}]
					}] 
				}, {
					defaults: {
						xtype: "fieldset",
						layout: "form",
						anchor: "100%",
						autoHeight: true
					},
					items: [{
						title: "Fieldset 2",
						defaults: {
							anchor: "-20",
							allowBlank: false
						},
						items: [{
							xtype: "textfield",
							fieldLabel: "TextFieldR1"
						}, {
							xtype: "textfield",
							fieldLabel: "TextFieldR2"
						}]
					}] 
				}]
			}, {
				xtype: "textfield",
				fieldLabel: "TextField2"
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
