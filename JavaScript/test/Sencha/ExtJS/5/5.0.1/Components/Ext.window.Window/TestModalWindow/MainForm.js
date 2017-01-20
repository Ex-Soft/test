Ext.onReady(function() {
	Ext.create("Ext.toolbar.Toolbar", {
		items: [{
			text: "Window",
			handler: function(btn, e) {
				if(window.console && console.log)
					console.log("b4");

				Ext.create("Ext.window.Window", {
					title: "Title",
					html: "Ext.window.Window {modal: true} <a href=\"#\" onclick=\"DoIt(this, &quot;Test&quot;);\">link</a>",
					modal: true,
					autoShow: true,
					buttons: [{
						text: "OK",
						handler: function(btn, e) {
							var
								w;

							if(w=btn.up("window"))
								w.close();
						}
					}]
				});

				if(window.console && console.log)
					console.log("after");
			}
		}, {
			text: "MessageBox",
			handler: function(btn, e) {
				if(window.console && console.log)
					console.log("b4");

				Ext.MessageBox.prompt("Title", "Message", function(btn, text) {
					if(btn=="ok")
					;
				});

				if(window.console && console.log)
					console.log("after");
			}
		}],
		renderTo: Ext.getBody()
	});
});

function DoIt(a) {
	var
		e,
		w;

	if(window.console && console.log)
		console.log("DoIt(%o)", arguments);

	if((e=Ext.fly(a))
		&& (w=e.up("window")))
		w.close();
}