Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.define("TestTreeStoreModel", {
		extend: "Ext.data.Model",
		idProperty: "id",
		fields: [
			{ name: "id", type: "int" },
			{ name: "parentId", type: "int"  },
			"caption",
			"smthtext"
		]
	});

	var
		data = 	[{
			id: 1,
			parentId: 0,
			caption: "Folder# 1",
			smthtext: "SmthText# 1",
			children: [
				{ id: 2, parentId: 1, caption: "Leaf# 1.1", smthtext: "SmthText# 1.1", leaf: true },
				{ id: 3, parentId: 1, caption: "Leaf# 1.2", smthtext: "SmthText# 1.2", leaf: true }
			]
		}, {
			id: 4,
			parentId: 0,
			caption: "Folder# 2",
			smthtext: "SmthText# 2",
			children: [
				{ id: 5, parentId: 4, caption: "Leaf# 2.1", smthtext: "SmthText# 2.1", leaf: true },
				{ id: 6, parentId: 4, caption: "Leaf# 2.2", smthtext: "SmthText# 2.2", leaf: true }
			]
		}],
		store = Ext.create("Ext.data.TreeStore", {
			model: "TestTreeStoreModel",
			folderSort: true,
			proxy: {
				type: "memory"
			},
			listeners: {
				add: function(store, records, index, eOpts) {
					if(window.console && console.log)
						console.log("Ext.data.TreeStore.add(%o)", arguments);
				},
				append: function(parent, node, index, eOpts) {
					if(window.console && console.log)
						console.log("Ext.data.TreeStore.append(%o)", arguments);
				},
				load: function(store, node, records, successful, eOpts) {
					if(window.console && console.log)
						console.log("Ext.data.TreeStore.load(%o)", arguments);
				}
			}
		}),
		t = Ext.create("Ext.tree.Panel", {
			title: "TreeGrid",
			height: 500,
			width: 500,
			store: store,
			rootVisible: false,
			useArrows: true,
			columns: [{
				xtype: "treecolumn",
				text: "id",
				dataIndex: "id"
			}, {
				text: "parentId",
				dataIndex: "parentId",
			}, {
				text: "caption",
				dataIndex: "caption"
			}, {
				text: "smthtext",
				dataIndex: "smthtext"
			}],
			dockedItems: [{
				xtype: "toolbar",
				dock: "top",
				items: [{
					text: "ShowStore",
					handler: function(btn, e) {
						showNode(store.getRootNode());
					}
				}]
			}],
			renderTo: Ext.getBody()
		}),
		showNode = function(node) {
			if(window.console && console.log)
				console.log("id: %i, parentId: %i, caption: \"%s\", smthtext: \"%s\", leaf: %s", node.get("id"), node.get("parentId"), node.get("caption"), node.get("smthtext"), node.get("leaf"));

			for(var i=0, len=node.childNodes.length; i<len; ++i)
				showNode(node.childNodes[i]);
		};

	store.setRootNode({
		text: "RootNode",
		leaf: false,
		expanded: true,
		id: 0
	});

	t.getRootNode().appendChild(data);
});
