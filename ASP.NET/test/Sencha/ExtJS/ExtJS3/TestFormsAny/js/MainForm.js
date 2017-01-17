Ext.BLANK_IMAGE_URL = "../images/default/s.gif";

Ext.onReady(function() {
    Ext.QuickTips.init();

	var
		tb=new Ext.Toolbar({
			items: [{
				xtype: "button",
				text: "Form# 1",
				handler: function(btn, e){
					ShowForm1();
				}
			},
				"->"
			]
		}),
		viewport=new Ext.Viewport({
			layout: "fit",
			items: [tb]
		});
});
