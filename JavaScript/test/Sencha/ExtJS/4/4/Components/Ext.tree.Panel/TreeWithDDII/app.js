Ext.onReady(function() {
	var
		data = {
			text: "root",
			id: "root",
			expanded: true,
			children: [{
				text: "Child 1",
				data: "Child 1 additional data",
				children: [{
					text: "Child 1 Subchild 1",
					data: "Some additional data of Child 1 Subchild 1",
					leaf: true
				},{
					text: "Child 1 Subchild 2",
					data: "Some additional data of Child 1 Subchild 2",
					leaf: true
				}]
			},{
				text: "Child 2",
				leaf:true,
				data: "Last but not least. Data of Child 2"
			}]
		},
		treeW = Ext.create("Ext.tree.Panel", {
			region: "west",
			title: "Tree",
			layout: "fit",
			width: 300,
			store: Ext.create("Ext.data.TreeStore", { root: data }),
			split: true,
			collapsible: true,
			autoScroll: true,
			border: true,
			viewConfig: {
				plugins: {
					ptype: "treeviewdragdrop",
					ddGroup: "tree"
				},
				listeners: {
					beforedrop: function(node, data, overModel, dropPosition, dropFunction, eOpts) {
						if(window.console && console.log)
							console.log("Ext.tree.plugin.TreeViewDragDrop.beforedrop(%o) (W)", arguments);

						return data.records[0].get("text")!="Child 2";
					},
					drop: function(node, data, overModel, dropPosition, eOpts) {
						if(window.console && console.log)
							console.log("Ext.tree.plugin.TreeViewDragDrop.drop(%o) (W)", arguments);
					}
				}
			}
		}),
		treeC = Ext.create("Ext.tree.Panel", {
			region: "center",
			title: "Tree",
			layout: "fit",
			store: Ext.create("Ext.data.TreeStore", { root: data }),
			autoScroll: true,
			border: true,
			viewConfig: {
				plugins: {
					ptype: "treeviewdragdrop",
					ddGroup: "tree",
				},
				listeners: {
					beforedrop: function(node, data, overModel, dropPosition, dropFunction, eOpts) {
						if(window.console && console.log)
							console.log("Ext.tree.plugin.TreeViewDragDrop.beforedrop(%o) (C)", arguments);

						return data.records[0].get("text")!="Child 2";
					},
					drop: function(node, data, overModel, dropPosition, eOpts) {
						if(window.console && console.log)
							console.log("Ext.tree.plugin.TreeViewDragDrop.drop(%o) (C)", arguments);
					}
				}
			}
		});

	Ext.create("Ext.container.Viewport", {
		layout: "border",
		items: [
			treeW,
			treeC
		]
	});
});
