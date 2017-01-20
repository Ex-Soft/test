Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("TestTreeGridWithTemplateColumn", {
	extend: "Ext.tree.Panel",

	initComponent: function() {
		this.columns = [{
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
		}, {
			xtype: "templatecolumn",
			text: "two+three",
			tpl: "<div>{two}</div><div>{three}</div>"
		}, {
			xtype: "templatecolumn",
			text: "four+five",
			tpl: new Ext.XTemplate(
				"<div>{four:this.frmString(\"four\")}</div><div>{five:this.frmString(\"five\")}</div><div>{[myVarInDefinitions]}</div>",
				{
					definitions: "var myVarInDefinitions=\"" + this.id + "\";\n",
					frmString: function(val, add) {
						return val.toUpperCase()+add;
					}
				}
			),
			flex: 1
		}];

		this.callParent(arguments);
	}
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
			"smthtext",
			"two",
			"three",
			"four",
			"five"
		]
	});

	var
		data = 	[{
			id: 1,
			parentId: 0,
			caption: "Folder# 1",
			smthtext: "SmthText# 1",
			two: "2",
			three: "3",
			four: "four",
			five: "five",
			children: [
				{ id: 2, parentId: 1, caption: "Leaf# 1.1", smthtext: "SmthText# 1.1", two: "2", three: "3", four: "four", five: "five", leaf: true },
				{ id: 3, parentId: 1, caption: "Leaf# 1.2", smthtext: "SmthText# 1.2", two: "2", three: "3", four: "four", five: "five", leaf: true }
			]
		}, {
			id: 4,
			parentId: 0,
			caption: "Folder# 2",
			smthtext: "SmthText# 2",
			two: "2",
			three: "3",
			four: "four",
			five: "five",
			children: [
				{ id: 5, parentId: 4, caption: "Leaf# 2.1", smthtext: "SmthText# 2.1", two: "2", three: "3", four: "four", five: "five", leaf: true },
				{ id: 6, parentId: 4, caption: "Leaf# 2.2", smthtext: "SmthText# 2.2", two: "2", three: "3", four: "four", five: "five", leaf: true }
			]
		}],
		datadata = Ext.clone(data),
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
			//height: 500,
			//width: 900,
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
			}, {
				xtype: "templatecolumn",
				text: "two+three",
				tpl: "<div>{two}</div><div>{three}</div>"
			}, {
				xtype: "templatecolumn",
				text: "four+five",
				tpl: new Ext.XTemplate(
					"<div>{four:this.frmString(\"four\")}</div><div>{five:this.frmString(\"five\")}</div><div>{[myVarInDefinitions]}</div>",
					{
						currentStore: store,
						definitions: "var myVarInDefinitions=\"blah-blah-blah\";\n",
						frmString: function(val, add) {
							return val.toUpperCase()+add;
						}
					}
				),
				flex: 1
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
			renderTo: Ext.get("div1")
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

	var
		tt = Ext.create("TestTreeGridWithTemplateColumn", {
			id: "TestTreeGridWithTemplateColumn",
			title: "TestTreeGridWithTemplateColumn",
			//height: 500,
			//width: 900,
			store: Ext.create("Ext.data.TreeStore", {
				model: "TestTreeStoreModel",
				folderSort: true,
				proxy: {
					type: "memory"
				}
			}),
			rootVisible: false,
			useArrows: true,
			renderTo: Ext.get("div2")
		});

	tt.getStore().setRootNode({
		text: "RootNode",
		leaf: false,
		expanded: true,
		id: 0
	});

	tt.getRootNode().appendChild(datadata);
});
