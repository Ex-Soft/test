// http://www.sencha.com/forum/showthread.php?238395-How-to-change-Dom-struture-of-Ext.button.Button-through-Custom-template-in-ExtJS-4

Ext.onReady(function() {
	var
		b = Ext.create("Ext.button.Button", {
			renderTo: Ext.getBody(),
			text: "Ext.button.Button",
			componentCls: "btnBackground"
		});
});