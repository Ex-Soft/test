Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		label = Ext.create("Ext.form.Label", {
			text: "text",
			style: {
				textAlign: "center",
				width: "auto"
			}
		}),
		img = Ext.create("Ext.Img", {
			src: "../../../../../../../ExtJS/ExtJS4/ExtJS4.1.1/resources/themes/images/default/grid/loading.gif",
			margin: 10,
			//style: "vertical-align: middle; "
			style: {
				verticalAlign: "middle"
			}
		});

	Ext.create("Ext.window.Window", {
		title: "title",
		height: 100,
		width: 300,
		autoShow: true,
		items: [img, label],
		renderTo: Ext.getBody()
	});
});