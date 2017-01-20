﻿Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("Animal", {
	extend: "Ext.data.Model",
	fields: ["name", "latin", "desc"]
});

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.create("Ext.grid.Panel", {
		width: 400,
		height: 300,
		renderTo: Ext.getBody(),
		store: {
			model: "Animal",
			data: [
				{name: "Tiger", latin: "Panthera tigris", desc: "The largest cat species, weighing up to 306 kg (670 lb)."},
				{name: "Roman snail", latin: "Helix pomatia", desc: "A species of large, edible, air-breathing land snail."},
				{name: "Yellow-winged darter", latin: "Sympetrum flaveolum", desc: "A dragonfly found in Europe and mid and Northern China."},
				{name: "Superb Fairy-wren", latin: "Malurus cyaneus", desc: "Common and familiar across south-eastern Australia."}
			]
		},
		columns: [{
			dataIndex: "name",
			text: "Common name",
			width: 125
		}, {
			dataIndex: "latin",
			text: "Scientific name",
			flex: 1
		}],
		features: [{
			ftype: "rowbody",
			getAdditionalData: function(data, rowIndex, record, orig) {
				var
					headerCt = this.view.headerCt,
					colspan = headerCt.getColumnCount();

				return {
					rowBody: "<div style=\"padding: 1em\">"+record.get("desc")+"</div>",
					rowBodyCls: "my-body-class",
					rowBodyColspan: colspan
				};
			}
		}]
    	});
 });