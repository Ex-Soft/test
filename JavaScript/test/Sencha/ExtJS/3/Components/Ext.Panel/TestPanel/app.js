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
				[ 1, "Panel# 1" ],
				[ 2, "Panel# 2" ],
				[ 3, "Panel# 3" ],
				[ 4, "Panel# 4" ],
				[ 5, "aaaaaaa" ],
				[ 6, "abbbbbb" ],
				[ 7, "abccccc" ],
				[ 8, "abcdddd" ],
				[ 9, "abcdeee" ],
				[ 10, "abcdeff" ],
				[ 11, "abcdefg" ]
			]
		}),
		panel = new Ext.Panel({
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
		div1 = document.createElement("div"),
		div2 = document.createElement("div"),
		div3 = document.createElement("div"),
		div4 = document.createElement("div"),
		panel1,
		panel2,
		panel3,
		panel4,
		btnShowPanel = new Ext.Button({
			text: "Show Panel",
			renderTo: Ext.getBody(),
			handler: function(btn, e) {
				panel1.show();

				//div2.style.display = "block";
				//panel2.show();
				// ||
				panel2.show();
				div2.style.display = "block";
				panel2.doLayout();

				div3.style.display = "block";
				panel3.show();
				// ||
				//panel3.show();
				//div3.style.display = "block";
				//panel3.doLayout();

				div4.style.display = "block";
				panel4.doLayout();
			}
		});

	document.body.appendChild(div1);
	panel1 = new Ext.Panel({
		items: [{
			xtype: "combo",
			store: store,
			valueField: "id",
			displayField: "value",
			mode: "local",
			value: 1
		}],
		frame: true,
		layout: "fit",
		hidden: true,
		applyTo: div1
	});

	div2.style.display = "none";
	document.body.appendChild(div2);
	panel2 = new Ext.Panel({
		items: [{
			xtype: "combo",
			store: store,
			valueField: "id",
			displayField: "value",
			mode: "local",
			value: 2
		}],
		frame: true,
		layout: "fit",
		applyTo: div2
	});

	div3.style.display = "none";
	document.body.appendChild(div3);
	panel3 = new Ext.Panel({
		items: [{
			xtype: "combo",
			store: store,
			valueField: "id",
			displayField: "value",
			mode: "local",
			value: 3
		}],
		frame: true,
		layout: "fit",
		hidden: true,
		applyTo: div3
	});

	div4.style.display = "none";
	document.body.appendChild(div4);
	panel4 = new Ext.Panel({
		items: [{
			xtype: "combo",
			store: store,
			valueField: "id",
			displayField: "value",
			mode: "local",
			value: 4
		}],
		frame: true,
		layout: "fit",
		renderTo: div4
	});
});
