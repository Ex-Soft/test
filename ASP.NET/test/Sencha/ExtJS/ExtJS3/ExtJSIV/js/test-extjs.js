Ext.onReady(function() {
	Ext.QuickTips.init();

	var
	    store=new Ext.data.JsonStore({
			url: "TestGridDataJson.aspx",
			root: 'movies',
			idProperty: 'id',
			totalProperty: 'count',
			fields: ['id', 'title', 'release_year', 'rating']
		}),
        combo = new Ext.form.ComboBox({
            id: "perpage",
            name : 'perpage',
            width: 40,
            store: new Ext.data.ArrayStore({
                fields: ['id'],
                data  : [
                    ['5'],
                    ['10'],
                    ['15']
                ]
            }),
            mode : 'local',
            value: '5',
            listWidth     : 40,
            triggerAction : 'all',
            displayField  : 'id',
            valueField    : 'id',
            editable      : false,
            forceSelection: true
        }),
        bbar = new Ext.PagingToolbar({
            pageSize: 5,
			store: store,
			displayInfo: true,
			items: [
			    "-",
			    "Per page: ",
			    combo
			],
			displayMsg: 'Displaying movies {0} - {1} of {2}',
			emptyMsg: "No movies found"
		}),
        grid = new Ext.grid.GridPanel({
            id: "TestGrid",
			title: 'Movies',
			store: store,
			columns: [
                { header: "ID", width: 30, dataIndex: 'id', sortable: true, hidden: true },
                { id: 'title-col', header: "Title", width: 180, dataIndex: 'title', sortable: true },
                { header: "Year", width: 75, dataIndex: 'release_year', sortable: true, align: 'center' },
                { header: "Rating", width: 75, dataIndex: 'rating', sortable: true }
            ],
			autoExpandColumn: 'title-col',
			width: 600,
			height: 200,
			loadMask: true,
			columnLines: true,
			bbar: bbar
		}),
		viewport = new Ext.Viewport({
			layout: 'border',
			renderTo: Ext.getBody(),
			items: [{
				region: 'north',
				xtype: 'panel',
				height: 50,
				items: [{
				    xtype: "textfield",
				    id: "tbParam1",
				    fieldLabel: "param# 1"
				}, {
				    xtype: "textfield",
				    id: "tbParam2",
				    fieldLabel: "param# 2"
				}, {
				    xtype: "textfield",
				    id: "tbParam3",
				    fieldLabel: "param# 3"
				}, {
				    xtype: "button",
				    text: "Apply",
				    handler: Apply
				}]
				}, {
				region: 'center',
				xtype: 'panel',
				items: grid
			}]
		});

	store.on('beforeload', function() {
		store.baseParams = {
			param1: Ext.getCmp("tbParam1").getValue(),
			param2: Ext.getCmp("tbParam2").getValue(),
			param3: Ext.getCmp("tbParam3").getValue()
		};
	});

    combo.on('select', function(combo, record) {
        bbar.pageSize = parseInt(record.get('id'), 10);
        bbar.doLoad(bbar.cursor);
    }, this);
});

function Apply()
{
    Ext.getCmp("TestGrid").store.load({params: {start: 0, limit: parseInt(Ext.getCmp("perpage").getValue(),10)}});
}