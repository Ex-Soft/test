Ext.BLANK_IMAGE_URL="../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		f1 = function(btn, e) { if(window.console && console.log) console.log("f1(%o)", arguments); },
		f2 = function(btn, e) { if(window.console && console.log) console.log("f2(%o)", arguments); },
		btnVictim = new Ext.Button({
			text: "Victim",
			renderTo: Ext.getBody()
		}),
		btnGet = new Ext.Button({
			text: "Get",
			handler: function(btn, e) {
				var listeners;

				if(window.console && console.log) {
					console.log("f1 = \"%s\"", f1.toString());
					console.log("f2 = \"%s\"", f2.toString());

					if ((listeners = btnVictim.events["click"].listeners) && listeners.length)
						console.log("\"%s\"", listeners[0].fn.toString());
				}
			},
			renderTo: Ext.getBody()
		}),
		btnSet = new Ext.Button({
			text: "Set",
			handler: function(btn, e) {
				if(window.console && console.log) {
					console.log("f1 = \"%s\"", f1.toString());
					console.log("f2 = \"%s\"", f2.toString());
				}

				f1 = f2;

				if(window.console && console.log) {
					console.log("f1 = \"%s\"", f1.toString());
					console.log("f2 = \"%s\"", f2.toString());
				}
			},
			renderTo: Ext.getBody()
		});

	btnVictim.on("click", f1);
});
