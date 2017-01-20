Ext.define("TestTreePanel", {
	extend: "Ext.tree.Panel",
	alias: "widget.testtreepanel",
	requires: [
		"Ext.data.TreeStore"
	],

	initComponent: function() {
		Ext.apply(this, {
			store: Ext.create("Ext.data.TreeStore", {
				folderSort: true
			}),
			rootVisible: false,
			useArrows: true,
			height: 500,
			width: 500,
			tbar: [{
				xtype: "button",
				text: "Load by Store",
				scope: this,
				handler: function() {
					this.loadByStore();
				}
			}, {
				xtype: "button",
				text: "Load by Tree",
				scope: this,
				handler: function() {
					this.loadByTree();
				}
			}],
			renderTo: Ext.getBody(),
		});

		this.callParent(arguments);
	},

	loadByStore: function() {
		var
			root = {
				id: 0,
				text: "RootNode",
				leaf: false,
				expanded: true,
				children: [
					{ id: 1, parentId: 0, text: "Child# 1 (Store)", leaf: true },
					{ id: 2, parentId: 0, text: "Child# 2 (Store)", leaf: true },
					{ id: 3, parentId: 0, text: "Child# 3 (Store)", leaf: true }
				]
			},
			store = this.getStore();

		store.setRootNode(root);
	},

	loadByTree: function() {
		var
			root = {
				id: 0,
				text: "RootNode",
				leaf: false,
				expanded: true,
				children: [
					{ id: 1, parentId: 0, text: "Child# 1 (Tree)", leaf: true },
					{ id: 2, parentId: 0, text: "Child# 2 (Tree)", leaf: true },
					{ id: 3, parentId: 0, text: "Child# 3 (Tree)", leaf: true }
				]
			};

		this.setRootNode(root);
	}
});

Ext.onReady(function() {
	Ext.create("TestTreePanel");
});
