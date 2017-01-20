Ext.onReady(function() {
	Ext.define("TestTreeStoreModel", {
		extend: "Ext.data.Model",
		idProperty: "id",
		fields: [
			{ name: "id", type: "int" },
			{ name: "parentId", type: "int" },
			{ name: "desktopId", type: "int" },
			{ name: "isFolder", type: "boolean" },
			"caption",
			"treepath"
		]
	});

	var
		data = [
			{ id: 1, parentId: 7, desktopId: 1, isFolder: 0, caption: "Navigation shortcut# 1.1.1", treepath: "7/1" },
			{ id: 2, parentId: 8, desktopId: 1, isFolder: 0, caption: "Navigation shortcut# 1.2.1", treepath: "8/2" },
			{ id: 3, parentId: null, desktopId: 1, isFolder: 0, caption: "Navigation shortcut# 1.3", treepath: "3" },
			{ id: 4, parentId: 9, desktopId: 2, isFolder: 0, caption: "Navigation shortcut# 2.1.1", treepath: "9/4" },
			{ id: 6, parentId: null, desktopId: 2, isFolder: 0, caption: "Navigation shortcut# 2.3", treepath: "6" },
			{ id: 5, parentId: 10, desktopId: 2, isFolder: 0, caption: "Navigation shortcut# 2.2.1", treepath: "10/5" },
			{ id: 7, parentId: null, desktopId: 1, isFolder: 1, caption: "Folder# 1.1", treepath: "7" },
			{ id: 8, parentId: null, desktopId: 1, isFolder: 1, caption: "Folder# 1.2", treepath: "8" },
			{ id: 9, parentId: null, desktopId:2, isFolder: 1, caption: "Folder# 2.1", treepath: "9" },
			{ id: 10, parentId: null, desktopId: 2, isFolder: 1, caption: "Folder# 2.2", treepath: "10" }
		],
		data_filtered_1 = Ext.Array.filter(data, function(item) {
			return item.desktopId==1
		}),
		data_filtered_2 = Ext.Array.filter(data, function(item) {
			return item.desktopId==2
		}),
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
						newChildNode.set("leaf", !newChildNode.get("isFolder"));
					}
				}
			}
		}),
		tree = Ext.create("Ext.tree.Panel", {
			height: 500,
			width: 500,
			store: store,
			rootVisible: false,
			renderTo: Ext.getBody(),
			tbar: [{
				xtype: "button",
				text: "Load# 1",
				handler: function() {
					load(data_filtered_1);
				}
			}, {
				xtype: "button",
				text: "Load# 2",
				handler: function() {
					load(data_filtered_2);
				}
			}],
			listeners: {
				itemclick: function(view, record, item, index, e, eOpts) {
					if(window.console && console.log)
						console.log("Ext.tree.Panel.itemclick(%o)", arguments);
				}
			}
		}),
		load = function(data) {
			tree.getStore().setRootNode(ArrayToTreeRootNode(data));
		};

	//tree.getStore().setRootNode(ArrayToTreeRootNode(data_filtered_1));
});

function ArrayToTreeRootNode(data)
{
	var
		root = {
			text: "RootNode",
			leaf: false,
			expanded: true,
			id: 0
		};

	for(var i=0; i<data.length; ++i)
	{
		var
			pathSeparator = "/",
			row = data[i],
			treepath = row.treepath.split(pathSeparator),
			parent = findParent(root, treepath.slice(0,-1).join(pathSeparator));

		addChild(parent, row);
	}

	return root;
}

function findParent(parentNode, treepath)
{
	if(!treepath
		|| !treepath.length)
		return parentNode;

	var
		pathSeparator = "/",
		nodes = treepath.split(pathSeparator),
		id = parseInt(nodes[0], 10),
		parent=null;

	if(!(parent=findChild(parentNode, id)))
		parentNode.children.push(parent = { id: id });

	return (nodes = nodes.slice(1).join(pathSeparator)).length>0 ? findParent(parent, nodes) : parent;
}

function findChild(parentNode, id)
{
	var
		child = null,
		i,
		len;

	if(!parentNode.children)
		parentNode.children=[];

	for(i=0, len=parentNode.children.length; i<len; ++i)
		if(parentNode.children[i].id==id)
		{
			child=parentNode.children[i];
			break;
		}

	return child;
}

function addChild(parent, childData)
{
	var
		child;

	if(child=findChild(parent, childData.id))
	{
		child.parentId = childData.parentId;
		child.desktopId = childData.desktopId;
		child.isFolder = childData.isFolder;
		child.caption = childData.caption;
		child.treepath = childData.treepath;
	}
	else
		parent.children.push(childData);
}
