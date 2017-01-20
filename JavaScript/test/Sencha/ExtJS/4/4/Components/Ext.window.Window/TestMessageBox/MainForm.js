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

	Ext.create("Ext.toolbar.Toolbar", {
		items: [{
			text: "show",
			handler: function(btn, e) {
				Ext.MessageBox.show({
					title: "Title",
					msg: "Message with <a href=\"#\" onclick=\"DoIt(this, &quot;Test&quot;);\">link</a>",
					fn: function(buttonId, text, opt) {
						if(window.console && console.log)
							console.log("fn(%o)", arguments);
					},
					buttons: Ext.Msg.YESNOCANCEL,
					icon: Ext.Msg.QUESTION,
					buttonText: {
						yes: "oB!",
						no: "Tampax"
					}
				});
			}
		}, {
			text: "confirm",
			handler: function(btn, e) {
				Ext.Msg.confirm({
					title: "title",
					msg: "msg",
					buttons: Ext.Msg.YESNO,
					icon: Ext.Msg.QUESTION,
					fn: function(buttonId, text, opt) {
						if(window.console && console.log)
							console.log("fn(%o)", arguments);
					}
				});
			}
		}, {
			text: "prompt",
			handler: function(btn, e) {
				Ext.Msg.prompt({
					title: "title",
					msg: "msg",
					prompt: true,
					buttons: Ext.Msg.YESNO,
					icon: Ext.Msg.QUESTION,
					fn: function(buttonId, text, opt) {
						if(window.console && console.log)
							console.log("fn(%o)", arguments);
					}
				});
			}
		}],
		renderTo: Ext.getBody()
	});
});

function DoIt(a) {
	var
		e,
		mb;

	if(window.console && console.log)
		console.log("DoIt(%o)", arguments);

	if((e=Ext.fly(a)) // Ext.dom.Element
		&& (mb=e.up("div.x-window"/*"messagebox"*/))) // Ext.dom.Element.findParentNode -> Ext.dom.Element.findParent
		/*mb.hide()*/;

	if((e=Ext.get(a)) // Ext.dom.Element
		&& (mb=Ext.get(Ext.get(e.dom).findParent("div.x-window"))))
		/*mb.hide()*/;

	if((e=Ext.get(a))
		&& (mb=Ext.get(e.findParent("div.x-window"))))
		/*mb.hide()*/;

	if((e=Ext.get(a))
		&& (mb=e.up("messagebox")))
		/*mb.hide()*/;

	Ext.fly(a).up("div.x-window").hide();
}