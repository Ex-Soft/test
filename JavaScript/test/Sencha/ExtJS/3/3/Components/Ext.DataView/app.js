Ext.BLANK_IMAGE_URL="../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
		console.log(Ext.version);

	var
		store = new Ext.data.ArrayStore({
			autoDestroy: true,
			idIndex: 0,
			fields: [
				{ name: "id", type: "int" },
				"name"
			],
			data: [
				[ 1, "Иванов Иван Иванович" ],
				[ 2, "Петров Петр Петрович" ],
				[ 3, "Сидоров Сидор Сидорович" ],
				[ 4, "Васильев Василий Василиевич" ]
			]
		}),
		XTemplateTitlePage = new Ext.XTemplate(
			"<tpl for=\".\">",
				"<div class=\"DivWithName\">",
					"<div class=\"DivWithImg\"><img src=\"../../../../../pix/sm10_eyes.gif\" /></div>",
					"<span class=\"SpanWithName\">{name}</span>",
				"</div>",
			"</tpl>",
			"<div class=\"x-clear\"></div>"
		),
		DataViewTitlePage = new Ext.DataView({
			singleSelect: true,
			store: store,
			tpl: XTemplateTitlePage,
			autoHeight: true,
			multiSelect: true,
			itemSelector: "div.DivWithName",
			//renderTo: Ext.get("div2")
			applyTo: Ext.get("div2"),
			listeners: {
				click: function(dw, index, node, e){
					if(dw)
					{
						var
							si=dw.getSelectedIndexes(),
							sn=dw.getSelectedNodes(),
							sr=dw.getSelectedRecords(),
							sc=dw.getSelectionCount();
					}

					if(window.console && console.log)
						console.log("DataView.click(...,index=%i,...)", index);

					if(node)
					{
						var
							r=dw.getRecord(node);

						if(r)
						{
							if(window.console && console.log)
								console.log("Id=%i Name=\"%s\"", r.id, r.get("name"));
						}
					}
				},
				containerclick: function(dw, e){
					if(window.console && console.log)
						console.log("DataView.containerclick");
						
					if(dw)
					{
						var
							si=dw.getSelectedIndexes(),
							sn=dw.getSelectedNodes(),
							sr=dw.getSelectedRecords(),
							sc=dw.getSelectionCount();
					}
				},
				dblclick: function(dw, index, node, e){
					if(window.console && console.log)
						console.log("DataView.dblclick(...,index=%i,...)", index);
						
					if(node)
					{
						var
							r=dw.getRecord(node);

						if(r)
						{
							if(window.console && console.log)
								console.log("Id=%i Name=\"%s\"", r.id, r.get("name"));
						}
					}
				},
				selectionchange: function(dw, selections){
					if(window.console && console.log)
						console.log("DataView.selectionchange");
						
					if(selections)
					{
						Ext.each(selections, function(item){
							var
								r=dw.getRecord(item);

							if(r)
							{
								if(window.console && console.log)
									console.log("Id=%i Name=\"%s\"", r.id, r.get("name"));
							}
						});
					}
				},
				render: function(dw){
					dw.select(0);
				}
			}
		});
});
