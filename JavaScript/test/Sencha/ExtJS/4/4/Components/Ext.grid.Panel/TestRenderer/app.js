﻿Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.require([
	"Ext.tip.QuickTipManager"
]);

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.tip.QuickTipManager.init();

	var
		store = Ext.create("Ext.data.Store", {
			fields: [
				{ name: "id", type: "int" },
				"fString1",
				"fString2",
				"fString3",
				"fString4",
				"fString5",
				{ name: "fInt1", type: "int" },
				{ name: "fInt2", type: "int" },
				{ name: "fInt3", type: "int" }
			],
			proxy: {
				type: "ajax",
				url: "data.json",
				reader: {
					type: "json",
					root: "rows"
				}
			},
			autoLoad: true
		});

	 Ext.create("Ext.grid.Panel", {
		store: store,
		columns: [
			{ header: "id", dataIndex: "id" },
			{ header: "fString1", dataIndex: "fString1", renderer: function(value, metaData, record, rowIndex, colIndex, store, view) {
				metaData.style = "color: white; background-color: blue;"; // applied style for DIV element
				return value;
			}},
			{ header: "fString2", dataIndex: "fString2", renderer: function(value, metaData, record, rowIndex, colIndex, store, view) {
				metaData.innerCls = "fourth"; // applied class for TD element
				return value;
			}},
			{ header: "fString3", dataIndex: "fString3", renderer: function(value, metaData, record, rowIndex, colIndex, store, view) {
				metaData.tdAttr = "style=\"color: white; background-color: blue;\""; // applied stype for TD element
				return value;
			}},
			{ header: "fString4", dataIndex: "fString4", renderer: function(value, metaData, record, rowIndex, colIndex, store, view) {
				metaData.tdCls = "fourth"; // applied class for TD element
				return value;
			}},
			{ header: "fString5", dataIndex: "fString5", renderer: function(value, metaData, record, rowIndex, colIndex, store, view) {
				metaData.tdAttr = Ext.String.format("data-qtip=\"<div><span class='color-box color1'></span><span class='legend'>{0}</span></div><div><span class='color-box color2'></span><span class='legend'>{1}</span></div>\"", record.getId(), value);
				return value;
			}},
			{ header: "fInt1", dataIndex: "fInt1", renderer: function(value, metaData, record, rowIndex, colIndex, store, view) {
				metaData.tdAttr = Ext.String.format("data-qtip=\"<div><span class='color-box color1'></span><span class='legend'>{0}</span></div><div><span class='color-box color2'></span><span class='legend'>{1}</span></div>\"", "fInt2", "fInt3");
				return Ext.String.format("<div style='text-align: center;'>{0}</div><div class='color1' style='height: 11px; width: {1}%;'></div><div class='color2' style='height: 11px; width: {2}%;'></div>", value, record.get("fInt2"), record.get("fInt3"));
			}}

		],
		renderTo: Ext.getBody()
	});
});