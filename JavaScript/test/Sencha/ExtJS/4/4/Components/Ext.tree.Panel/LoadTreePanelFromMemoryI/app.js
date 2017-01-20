Ext.onReady(function() {
	Ext.define("TestTreeStoreModel", {
		extend: "Ext.data.Model",
		idProperty: "id",
		fields: [
			{ name: "id", type: "int" },
			{ name: "parentId", type: "int"  },
			"caption"
		]
	});

	var
		data = [
			{
				id: 1,
				parentId: 0,
				caption: "Folder# 1",
				children: [
					{ id: 2, parentId: 1, caption: "Leaf# 1.1" },
					{ id: 3, parentId: 1, caption: "Leaf# 1.2" }
				]
			},
			{
				id: 4,
				parentId: 0,
				caption: "Folder# 2",
				children: [
					{ id: 5, parentId: 4, caption: "Leaf# 2.1" },
					{ id: 6, parentId: 4, caption: "Leaf# 2.2" }
				]
			}
		],
		store = Ext.create("Ext.data.TreeStore", {
			model: "TestTreeStoreModel",
			folderSort: true,
			proxy: {
				type: "memory"
			},
			listeners: {
				append: function(thisNode, newChildNode, index, eOpts) {
					if(!newChildNode.isRoot())
					{
						newChildNode.set("text", newChildNode.get("caption"));
						newChildNode.set("leaf", Boolean(newChildNode.get("parentId")));
					}
				}
			}
		}),
		t = Ext.create("Ext.tree.Panel", {
			height: 500,
			width: 500,
			store: store,
			rootVisible: false,
			useArrows: true,
			cls: "no-leaf-icons no-parent-icons", // http://www.sencha.com/forum/showthread.php?152359-Remove-Tree-Node-leaf-icon&highlight=tree+icon
			renderTo: Ext.getBody(),
			listeners: {
				itemclick: function(view, record, item, index, e, eOpts) {
					if(window.console && console.log)
						console.log("Ext.tree.Panel.itemclick(%o)", arguments);
				}
			}
		});

	store.setRootNode({
		text: "RootNode",
		leaf: false,
		expanded: true,
		id: 0
	});

	t.getRootNode().appendChild(data);
});