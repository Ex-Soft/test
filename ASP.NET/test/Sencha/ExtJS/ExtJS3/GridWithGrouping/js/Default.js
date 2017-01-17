Ext.BLANK_IMAGE_URL = "../images/default/s.gif";

Ext.onReady(function() {
    Ext.QuickTips.init();

    var
		reader = new Ext.data.JsonReader({
            root: "rows",
            idProperty: "Id",
            successProperty: "success",
            totalProperty: "count",
            fields: [
				{ name: "Id", type: "int" },
				"Name",
				{ name: "Salary", type: "float" },
				{ name: "Dep", type: "int" },
				{ name: "BirthDate", type: "date", dateFormat: "c" }
			]
		}),
        store = new Ext.data.GroupingStore({
            url: "Data.aspx",
            reader: reader,
            groupField: "Dep"
        }),
        combo = new Ext.form.ComboBox({
            width: 40,
            store: new Ext.data.ArrayStore({
                fields: ["id"],
                data: [ ["2"], ["4"], ["8"], ["64"] ]
            }),
            mode: "local",
            value: "2",
            listWidth: 40,
            triggerAction: "all",
            displayField: "id",
            valueField: "id",
            editable: false,
            forceSelection: true,
			listeners: {
				select: function(combo, record, index){
					var
						bbar=grid.getBottomToolbar();

					bbar.pageSize=parseInt(record.get("id"),10);
					bbar.doLoad(0);
				}
			}
        }),
		bbar = new Ext.PagingToolbar({
		    pageSize: parseInt(combo.value, 10),
		    store: store,
		    displayInfo: true,
		    items: [
				"-",
				"Per page: ",
				combo
			],
		    displayMsg: 'Displaying items {0} - {1} of {2}',
		    emptyMsg: "No items found"
		}),
        colModel = new Ext.grid.ColumnModel({
            columns: [
				{ dataIndex: "Id", header: "ID", width: 30, sortable: true, hidden: true },
				{ id: "ColName", dataIndex: "Name", header: "Name", width: 180, sortable: true },
				{ dataIndex: "Salary", header: "Salary", width: 75, sortable: true, align: "center" },
				{ dataIndex: "Dep", header: "Dep", groupName: "Dep", width: 75, sortable: true, align: "center" },
				{ dataIndex: "BirthDate", header: "BirthDate", renderer: Ext.util.Format.dateRenderer("d/m/Y"), width: 100, sortable: true, align: "center" }
			]
        }),
		grid = new Ext.grid.GridPanel({
			region: "center",
			store: store,
			colModel: colModel,
			bbar: bbar,
			loadMask: true,
			view: new Ext.grid.GroupingView({
				forceFit: true,
				showGroupName: true,
				enableNoGroups: false, // Required
				hideGroupedColumn: true
			})
		}),
		viewport = new Ext.Viewport({
			layout: "border",
			renderTo: Ext.getBody(),
			items: [ grid ]
		});

	grid.getBottomToolbar().doLoad(0);
});