Ext.BLANK_IMAGE_URL="../../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		f = function(cb) {
			if (window.console && console.log)
				console.log("f(%o)", arguments);

			cb.onTriggerClick();
		},
		store = new Ext.data.ArrayStore({
			autoDestroy: true,
			fields: [ "id", "value"],
			data : [
				[ 1, "Line# 1" ],
				[ 2, "Line# 1" ],
				[ 3, "aaaaaaa" ],
				[ 4, "abbbbbb" ],
				[ 5, "abccccc" ],
				[ 6, "abcdddd" ],
				[ 7, "abcdeee" ],
				[ 8, "abcdeff" ],
				[ 9, "abcdefg" ]
			]
		}),
		combobox = new Ext.form.ComboBox({
			store: store,
			valueField: "id",
			displayField: "value",
			mode: "local",
			//hideTrigger: true,
			triggerAction: "all",
			listeners: {
				render: function(cb) {
					if (window.console && console.log)
						console.log("render(%o)", arguments);

					var el;

					if (!(el = cb.getEl()))
						return;

					el.on("click", f.createDelegate(cb, arguments));
				}
			},
			renderTo: Ext.getBody()
		});
});
