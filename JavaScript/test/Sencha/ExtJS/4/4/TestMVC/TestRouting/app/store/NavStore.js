Ext.define("TestRouting.store.NavStore", {
	extend: "Ext.data.TreeStore",
	alias: "store.navstore",

	model: "TestRouting.model.NavModel",

	root: {
		text: "Root",
		id: 0,
		expanded: true,
		children: [{
        	id: 1,
			text: "Folder# 1",
			leaf: false,
			cls: "folder",
        	children: [
            	{ id: 2, text: "Leaf# 1.1", leaf: true, cls:"file" },
            	{ id: 3, text: "Leaf# 1.2", leaf: true, cls:"file" }
        	]
		}, {
        	id: 4,
			text: "Folder# 2",
			leaf: false,
			cls: "folder",
        	children: [
            	{ id: 5, text: "Leaf# 2.1", leaf: true, cls:"file" },
            	{ id: 6, text: "Leaf# 2.2", leaf: true, cls:"file" }
        	]
		}]
	}
});