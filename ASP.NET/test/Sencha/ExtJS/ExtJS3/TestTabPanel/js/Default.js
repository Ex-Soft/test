Ext.BLANK_IMAGE_URL = "../images/s.gif";

Ext.onReady(function(){
    Ext.QuickTips.init();

	var
		tb=new Ext.Toolbar({
			items: [{
				xtype: "tbspacer"
			}, {
				xtype: "tbtext",
				text: "Toolbar's ToolBar:"
			}, {
				xtype: "tbspacer"
			}, {
				xtype: "tbbutton",
				text: "Button# 1"
			}, {
				xtype: "tbspacer"
			}, {
				xtype: "tbbutton",
				text: "Button# 2"
			}, {
				xtype: "tbfill"
			}]
		}),
		tp=new Ext.TabPanel({
			id: "TabPanel",
			//plain: true,
			border: false,
			tbar: [{
				xtype: "tbspacer"
			}, {
				xtype: "tbtext",
				text: "TabPanel's ToolBar:"
			}, {
				xtype: "tbspacer"
			}, {
				xtype: "tbbutton",
				text: "Button# 1"
			}, {
				xtype: "tbspacer"
			}, {
				xtype: "tbbutton",
				text: "Button# 2"
			}, {
				xtype: "tbfill"
			}],
			tabPosition: "bottom",
			defaults: {
				closable: true
			},
			activeTab: 0,
			items: [{
				title: "Tab# 1",
				html: "Tab# 1"
			}, {
				title: "Tab# 2",
				html: "Tab# 2",
				listeners: {
					activate: function(tab){ Ext.Msg.alert(tab.title,"activate"); }
				}
			}]
		}),
		viewport=new Ext.Viewport({
			id: "MainForm",
			layout: "border",
			renderTo: Ext.getBody(),
			items: [{
				region: "north",
				border: false,
				height: 27,
				items: [tb]
			}, {
				region: "center",
				items: [tp]
			}]
		});
});