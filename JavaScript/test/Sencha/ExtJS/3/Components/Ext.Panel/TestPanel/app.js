Ext.BLANK_IMAGE_URL = "../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
		console.log(Ext.version);

	var
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
		panel1 = new Ext.Panel({
			items: [{
				xtype: "combo",
				store: store,
				valueField: "id",
				displayField: "value",
				mode: "local"
			}],
			frame: true,
			layout: "fit",
			renderTo: Ext.getBody()
		}),
		div = document.createElement("div"),
		panel2,
		btnShowPanel = new Ext.Button({
			text: "Show Panel",
			renderTo: Ext.getBody(),
			handler: function(btn, e) {
				div.style.display = "block";
				panel2.doLayout();
			}
		});

	div.style.display = "none";
	document.body.appendChild(div);

	panel2 = new Ext.Panel({
		items: [{
			xtype: "combo",
			store: store,
			valueField: "id",
			displayField: "value",
			mode: "local"
		}],
		frame: true,
		layout: "fit",
		renderTo: div
	});
});
