Ext.BLANK_IMAGE_URL="../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3.3.1/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		treeGrid = new Ext.ux.tree.TreeGrid({
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
			dataUrl: "treegrid-data.json"
		});
});

