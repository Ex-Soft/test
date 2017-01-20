Ext.onReady(function(){
	var
		jsonData = { buttons: [ {text: "Button# 1"}, {text: "Button# 2"} ]};

	Ext.create("Ext.panel.Panel", {
		//buttons: jsonData.buttons,
		dockedItems: [{
			xtype: "toolbar",
			dock: "bottom",
			ui: "footer",
			items: jsonData.buttons
		}],
		renderTo: Ext.getBody()
	});
});