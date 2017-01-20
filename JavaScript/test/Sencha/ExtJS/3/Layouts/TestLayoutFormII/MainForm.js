Ext.BLANK_IMAGE_URL="../../../../../ExtJS/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		f=new Ext.FormPanel({
			frame: true,
			items: [{
				xtype: "textfield",
				fieldLabel: "TextField1"
			}, {
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
						xtype: "textfield",
						fieldLabel: "TextFieldL1",
						labelStyle: "width: 70px; text-align: right;"
					}, {
						xtype: "textfield",
						fieldLabel: "TextFieldL2"
					}, {
						xtype: "radio",
						name: "RadioName",
						boxLabel: "Radio# 1",
						checked: true
					}, {
						xtype: "radio",
						name: "RadioName",
						boxLabel: "Radio# 2"
					}] 
				}, {
					defaults: {
						anchor: "100%"
					},
					items: [{
						xtype: "textfield",
						fieldLabel: "TextFieldR1"
					}, {
						xtype: "textfield",
						fieldLabel: "TextFieldR2"
					}, {
						xtype: "textfield",
						fieldLabel: "TextFieldRadio1"
					}, {
						xtype: "textfield",
						fieldLabel: "TextFieldRadio2"
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
