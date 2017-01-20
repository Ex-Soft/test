Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.def

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		getData = function() {
			return {
				text: "RootNode",
				captionOfNode: "captionOfNode root",
				children: [
					{ text: "1", captionOfNode: "captionOfNode# 1", fstring1: "fstring1", children: [
						{ text: "1.1.", captionOfNode: "captionOfNode# 1.1.", fstring11: "fstring11", leaf: true },
						{ text: "1.2.", captionOfNode: "captionOfNode# 1.2.", fstring11: "blah-blah-blah", fstring12: "fstring12", children: [
							{ text: "1.2.1.", captionOfNode: "captionOfNode# 1.2.1", fstring121: "fstring121", leaf: true },
							{ text: "1.2.2.", captionOfNode: "captionOfNode# 1.2.2", fstring122: "fstring122", leaf: true }
						] }
					] },
					{ text: "2", captionOfNode: "captionOfNode# 2", fstring2: "fstring2" }
				]
			}
		},
		t = Ext.create("Ext.tree.Panel", {
			title: "TreeGrid",
			height: 500,
			width: 900,
			store: Ext.create("Ext.data.TreeStore", {
				fields: [
					"captionOfNode",
					"fstring1",
					"fstring11",
					"fstring12",
					"fstring121",
					"fstring122"
				]
				//, folderSort: true
			}),
			rootVisible: true,
			useArrows: true,
			renderTo: Ext.getBody(),
			columns: [
				{ xtype: "treecolumn", dataIndex: "captionOfNode", renderer: function(value, metaData, record, rowIndex, colIndex, store, view) {
					return "<b>" + value + "</b><div><b>" + record.get("fstring1") + "</b></div>";
				} },
				{ xtype: "templatecolumn", tpl: "<div><b>{fstring1}</b></div><div>{fstring11}</div><div>{fstring12}</div><div>{fstring121}</div><div>{fstring122}</div>" }
			],
			dockedItems: [{
				xtype: "toolbar",
				dock: "top",
				items: [{
					text: "watch",
					handler: function(btn, e) {
						var
							store = btn.up("treepanel").getStore();

						if(store)
							;
					}
				}]
			}]
		});

	t.getStore().setRootNode(getData());
});