Ext.BLANK_IMAGE_URL="../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3.3.1/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
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
		colModel = new Ext.grid.ColumnModel({
			columns: [
				{ dataIndex: "id", width: 16, sortable: true,
				renderer: function (value, metaData, record) {
					metaData.css = value % 2 ? "bullet-green" : "bullet-red";
					return "<span>&nbsp;</span>";
				},
				listeners: {
					widthchange: function () {
						if (window.console && console.log)
							console.log("widthchange(%o)", arguments);
					}
				}},
				{ dataIndex: "id", header: "Id", width: 16, sortable: true },
				{ id: "ColName", dataIndex: "name", header: "Name", width: 180, sortable: true }
			]
		}),
		colModelWithFixed = new Ext.grid.ColumnModel({
			columns: [
				{ dataIndex: "id", width: 16, sortable: true, fixed: true, renderer: function (value, metaData, record) { metaData.css = value % 2 ? "bullet-green" : "bullet-red"; return "<span>&nbsp;</span>"; } },
				{ dataIndex: "id", header: "Id", width: 16, sortable: true, fixed: true },
				{ id: "ColName", dataIndex: "name", header: "Name", width: 180, sortable: true }
			]
		}),
		selModel = new Ext.grid.RowSelectionModel({
			singleSelect: true
		}), 
		grid1 = new Ext.grid.GridPanel({
			renderTo: Ext.getBody(),
			//hideHeaders: true,
			store: store,
			colModel: colModel,
			selModel: selModel,
			autoExpandColumn: "ColName",
			height: 150,
			title: "autoExpandColumn"
		}),
		grid2 = new Ext.grid.GridPanel({
			renderTo: Ext.getBody(),
			//hideHeaders: true,
			store: store,
			colModel: colModelWithFixed,
			selModel: selModel,
			autoExpandColumn: "ColName",
			height: 150,
			title: "autoExpandColumn, fixed"
		}),
		grid3 = new Ext.grid.GridPanel({
			renderTo: Ext.getBody(),
			//hideHeaders: true,
			store: store,
			colModel: colModel,
			selModel: selModel,
			viewConfig: { forceFit: true },
			height: 150,
			title: "{ forceFit: true }"
		}),
		grid4 = new Ext.grid.GridPanel({
			renderTo: Ext.getBody(),
			//hideHeaders: true,
			store: store,
			colModel: colModelWithFixed,
			selModel: selModel,
			viewConfig: { forceFit: true },
			height: 150,
			title: "{ forceFit: true }, fixed"
		});
});

