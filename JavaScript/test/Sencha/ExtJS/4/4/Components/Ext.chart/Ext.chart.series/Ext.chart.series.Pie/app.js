Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		store = Ext.create('Ext.data.JsonStore', {
			fields: ['name', 'data']
		}),
		data = [
			{ 'name': 'metric one',   'data': 10 },
			{ 'name': 'metric two',   'data':  7 },
			{ 'name': 'metric three', 'data':  5 },
			{ 'name': 'metric four',  'data':  2 },
			{ 'name': 'metric five',  'data': 27 }
		],
		vp = Ext.create("Ext.container.Viewport", {
			layout: "border",
			items: [{
				region: "west",
				layout: {
					type: "vbox",
					align: "stretch"
				},
				width: 100,
				items: [{
					xtype: "button",
					text: "Load Data",
					handler: function(btn, e) {
						store.loadData(data);
					}
				}, {
					xtype: "button",
					text: "Panel1",
					handler: function(btn, e) {
						replaceRegionCenter(btn.text);
					}
				}, {
					xtype: "button",
					text: "Panel2",
					handler: function(btn, e) {
						replaceRegionCenter(btn.text);
					}
				}, {
					xtype: "button",
					text: "Panel3",
					handler: function(btn, e) {
						replaceRegionCenter(btn.text);
					}
				}]
			},{
				region: "center",
				id: "regionCenter"
			}]
		}),
		replaceRegionCenter = function(text)
		{
			var
				regionCenter = vp.getLayout().centerRegion;

			regionCenter.removeAll();
			regionCenter.add(Ext.create("Ext.panel.Panel", {
				region: "center",
				id: text,
				items: Ext.create('Ext.chart.Chart', {
					width: 500,
					height: 350,
					animate: true,
					store: store,
					theme: 'Base:gradients',
					series: [{
						type: 'pie',
						angleField: 'data',
						showInLegend: true,
						tips: {
							trackMouse: true,
							width: 140,
							height: 28,
							renderer: function(storeItem, item) {
								var total = 0;
								store.each(function(rec) {
									total += rec.get('data');
								});
								this.setTitle(storeItem.get('name') + ': ' + Math.round(storeItem.get('data') / total * 100) + '%');
							}
						},
						highlight: {
							segment: {
								margin: 20
							}
						},
						label: {
							field: 'name',
							display: 'rotate',
							contrast: true,
							font: '18px Arial'
						}
					}]
				})
			}));
		};
});
