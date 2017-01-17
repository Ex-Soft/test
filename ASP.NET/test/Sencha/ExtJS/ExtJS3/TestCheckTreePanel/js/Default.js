Ext.BLANK_IMAGE_URL = "../images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		l = new Ext.tree.TreeLoader({
			url: "Data.aspx",
			baseParams: {
				cmd: "load"
			},
			listeners: {
				load: function(l, n, r) {
					t.setValue("4");
				},
				loadexception: function(l, n, r) {
					alert("loadexception");
				}
			}
		}),
		t = new Ext.ux.tree.CheckTreePanel({
			region: "center",
			border: true,
			autoScroll: true,
			rootVisible: false,
			root: {
				nodeType: "async",
				id: "root",
				text: "root",
				expanded: true,
				uiProvider:false
			},
			loader: l,
			buttons: [{
				text: "get",
				handler: function() {
					Ext.Msg.alert("tree.getValue()",t.getValue());
				}
			}, {
				text: "set",
				handler: function() {
					t.setValue("13,14,26");
				}
			}, {
				text: "reset",
				handler: function() {
					t.setValue("");
				}
			}]
		}),
		viewport = new Ext.Viewport({
			layout: 'border',
			renderTo: Ext.getBody(),
			items: [ t ]
		});
});