Ext.BLANK_IMAGE_URL="../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3.3.1/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		treeGrid = new Ext.ux.tree.TreeGrid({
			title: 'Ext.ux.tree.TreeGrid',
			width: 500,
			height: 300,
			renderTo: Ext.getBody(),
			columns: [{
				dataIndex: "task",
				header: "task",
				width: 230
			}, {
				dataIndex: "duration",
				header: "Duration",
				width: 100
			}, {
				dataIndex: "user",
				header: "Assigned To",
				width: 150
			}],
			dataUrl: "treegrid-data.json",
			listeners: {
				dblclick: function (node, e) {
					if (window.console && console.log)
						console.log("dblclick(%o)", arguments);

					treeEditor.editNode = node;
					treeEditor.startEdit(node.ui.textNode);
				}
			}
		}),
		treeEditor = new Ext.tree.TreeEditor(treeGrid, {
				allowBlank: false
				/*, validator: function (value) {
					if (window.console && console.log)
						console.log("validator(%o)", arguments);
					return "blah-blah-blah";
				}*/
				, listeners: {
					afterrender: function (editor) {
						if (window.console && console.log)
							console.log("afterrender(%o)", arguments);

						var
							root,
							ui,
							el;

						if (!(root = treeGrid.getRootNode())
							|| !(ui = root.getUI())
							|| !(el = ui.getEl())
							|| !el.parentNode)
							return;

						//treeGrid.el.appendChild(editor.el);
						//Ext.fly(el.parentNode).appendChild(editor.el);
					}
				}
			}, {
			cancelOnEsc: true,
			completeOnEnter: true,
			selectOnFocus: true,
			//allowBlank: false,
			validator: function () {
				if (window.console && console.log)
					console.log("validator(%o)", arguments);
			},
			listeners: {
				complete: function(treeEditor, oldValue, newValue) {
					if (window.console && console.log)
						console.log("complete(%o)", arguments);

				}
			}
		});
});

