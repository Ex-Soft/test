Ext.onReady(function() {
	var
		btnWithHandler = Ext.create("Ext.button.Button", {
			text: "handler (onClick(e) -> fireHandler(e) -> handler(btn, e))",
			handler: function (btn, e) {
				if (window.console && console.log)
					console.log("Ext.button.Button.handler(%o)", arguments);
			}
		}),
		btnWithListeners = Ext.create("Ext.button.Button", {
			text: "listeners (onClick(e) -> fireHandler(e) -> fireEvent(\"click\", btn, e))",
			listeners: {
				click: function (btn, e, eOpts) {
					if (window.console && console.log)
					console.log("Ext.button.Button.listeners.click(%o)", arguments);
				}
			}
		}),
		btnSimulate = Ext.create("Ext.button.Button", {
			text: "simulate",
			handler: function (btn, e) {
				if (window.console && console.log)
					console.log("simulate(%o)", arguments);

				simulateBtnClick(btnWithHandler);
				simulateBtnClick(btnWithListeners);
			}
		}),
		simulateBtnClick = function (btn) {
			var el;
	
			if (!btn) {
				return;
			}
	
			if (btn.handler) {
				btn.handler(btn);
			} else if (btn.hasListener("click")) {
				btn.fireEvent("click", btn);
			} else if ((el = btn.getEl()) && el.dom && el.dom.click) {
				el.dom.click();
			}
		},
		panel = Ext.create("Ext.panel.Panel", {
			renderTo: Ext.getBody(),
			items: [
				btnWithHandler,
				btnWithListeners,
				btnSimulate
			]
		});


	btnWithHandler.on("click", function (btn, e, eOpts) {
		if (window.console && console.log)
		console.log("Ext.panel.Panel.on.click(%o)", arguments);
	});

	btnWithListeners.on("click", function (btn, e, eOpts) {
		if (window.console && console.log)
		console.log("Ext.panel.Panel.on.click(%o)", arguments);
	});
});
