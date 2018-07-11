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

	var
		getPath = function (node) {
			var path = "";

			for (var parentNode = node; parentNode; parentNode = parentNode.parentNode) {
				path = "/" + parentNode.getId().toString() + path;
			}

			return path;
		},
		expandPath = function (node, path, field) {
			var
				nodes = path.split("/"),
				len = nodes.length,
				startIndex;

			field = field || (node.idField ? node.idField.name : (node.idProperty || "id"));

			for (startIndex = 1; startIndex < len; ++startIndex) {
				if (node.get(field) == nodes[startIndex]) {
					break;
				}
			}

			for (var i = ++startIndex; i < len; ++i) {
				if (!(node = node.findChild(field, nodes[i], true)) || node.isLeaf()) {
					continue;
				}

				node.expand(false);
			}
		},
		select = function (treePanel, id) {
			var
				store,
				rootNode,
				newTreeNode,
				selModel;

			if (!treePanel
				|| !(store = treePanel.getStore())
				|| !(rootNode = store.getRootNode())
				|| !(newTreeNode = rootNode.findChild("id", id, true))) {
				return;
			}

			selModel = treePanel.getSelectionModel();

			if (!selModel.isSelected(newTreeNode)) {
				//treePanel.expandPath(getPath(newTreeNode));
				expandPath(rootNode, newTreeNode.getPath("id"));
				selModel.select(newTreeNode);
			}
		};

	var tp = Ext.create("Ext.tree.Panel", {
		title: "Ext.tree.Panel",
		rootVisible: true,
		useArrows: true,
		height: 500,
		width: 900,
		renderTo: Ext.getBody(),
		store: Ext.create("Ext.data.TreeStore", {
			root: {
				expanded: false,
				id: "root",
				text: "/"
			},
			proxy: {
				type: "ajax",
				url: "getData.php"
			},
			listeners: {
				beforeexpand: function () {
					if (window.console && console.log)
						console.log("Ext.data.TreeStore.beforeexpand(%o)", arguments);
				},
				expand: function (parent, records, suppressEvent, listeners) {
					if (window.console && console.log)
						console.log("Ext.data.TreeStore.expand(%o)", arguments);
				},
				load: function () {
					if (window.console && console.log)
						console.log("Ext.data.TreeStore.load(%o)", arguments);
				}
			}
		}),
		listeners: {
			render: function () {
				if (window.console && console.log)
					console.log("Ext.tree.Panel.render(%o)", arguments);
			},
			viewready: function (treePanel) {
				if (window.console && console.log)
					console.log("Ext.tree.Panel.viewready(%o)", arguments);

				var
					rootNode,
					store;

				if (!(store = treePanel.getStore()) || !(rootNode = store.getRootNode())) {
					return;
				}

				rootNode.expand();
			},
			beforeexpand: function () {
				if (window.console && console.log)
					console.log("Ext.tree.Panel.beforeexpand(%o)", arguments);
			},
			expand: function () {
				if (window.console && console.log)
					console.log("Ext.tree.Panel.expand(%o)", arguments);
			},
			itemexpand: function () {
				if (window.console && console.log)
					console.log("Ext.tree.Panel.itemexpand(%o)", arguments);
			},
			load: function (store, node, records, successful) {
				var
					rootNode,
					isRootNode = (rootNode = store.getRootNode()) && rootNode === node;

				if (window.console && console.log)
					console.log("Ext.tree.Panel.load(%o)%s", arguments, isRootNode ? " rootNode" : "");

				if (isRootNode) {
					select(this, 111);
				}
			},
			select: function () {
				if (window.console && console.log)
					console.log("Ext.tree.Panel.select(%o)", arguments);
			},
			selectionchange: function () {
				if (window.console && console.log)
					console.log("Ext.tree.Panel.selectionchange(%o)", arguments);
			}
		},
		dockedItems: [{
			xtype: "toolbar",
			dock: "top",
			items: [{
				xtype: "numberfield",
				value: 311
			}, {
				text: "SelectNode",
				handler: function(btn, e) {
					var
						idField,
						treePanel;

					if (!(idField = btn.up("toolbar").down("numberfield"))
						|| !(treePanel = btn.up("treepanel"))) {
						return;
					}

					select(treePanel, idField.getValue());
				}
			}]
		}]
	});

	Ext.util.Observable.capture(tp, function() { if (window.console && console.log) console.log(arguments); });
	Ext.util.Observable.capture(tp.getStore(), function() { if (window.console && console.log) console.log(arguments); });
});