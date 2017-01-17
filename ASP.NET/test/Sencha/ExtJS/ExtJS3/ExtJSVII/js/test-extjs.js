Ext.onReady(function() {
	Ext.QuickTips.init();

	var 
        store = new Ext.data.JsonStore({
            url: "DataSource.aspx",
            root: "metadata",
            totalProperty: "count",
            successProperty: "success",
            baseParams: { first: true },
	    	writer: new Ext.data.JsonWriter(),
	    	autoSave: false,
	    	batch: true,
	    	listeners: {
	    		metachange: function(store, meta) { OnMetachange(store, meta, EditorGridPanelColumnModel) }
	    	}
	    }),
        combo = new Ext.form.ComboBox({
        	id: "perpage",
        	name: 'perpage',
        	width: 40,
        	store: new Ext.data.ArrayStore({
        		fields: ['id'],
        		data: [
                    ['2'],
                    ['4'],
                    ['6']
                ]
        	}),
        	mode: 'local',
        	value: '2',
        	listWidth: 40,
        	triggerAction: 'all',
        	displayField: 'id',
        	valueField: 'id',
        	editable: false,
        	forceSelection: true
        }),
        bbar = new Ext.PagingToolbar({
        	pageSize: 2,
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
        /* NameEdit = new Ext.form.TextField(),
        SalaryEdit = new Ext.form.NumberField(),
        BirthDateEdit = new Ext.form.DateField({
        	format: "d/m/Y"
        }), */
        grid = new Ext.grid.EditorGridPanel({
        	id: "TestGrid",
        	title: "TestGrid",
        	plugins: new Ext.grid.CheckColumn({header: "Checked",dataIndex: "Checked", width: 50}),
        	clickstoEdit: 1,
        	store: store,
        	columns: [],
        	width: 600,
        	height: 200,
        	tbar: {
        		items: [
					{ text: 'Save Changes',
						handler: function() {
							store.save();
						}
					}
				]
        	},
        	bbar: bbar
        }),
		viewport = new Ext.Viewport({
			layout: 'border',
			renderTo: Ext.getBody(),
			items: [{
				region: 'north',
				xtype: 'panel'
				}, {
				region: 'center',
				xtype: 'panel',
				items: grid
			}]
		}),
		EditorGridPanelColumnModel = new Ext.util.MixedCollection();

	/*
	EditorGridPanelColumnModel.add("Id", new Ext.grid.Column({ dataIndex: "Id", header: "ID", width: 30, sortable: true, hidden: true }));
	EditorGridPanelColumnModel.add("Name", new Ext.grid.Column({ id: "NameCol", dataIndex: "Name", header: "Name", editor: NameEdit, width: 180, sortable: true }));
	EditorGridPanelColumnModel.add("Salary", new Ext.grid.Column({ dataIndex: "Salary", header: "Salary", editor: SalaryEdit, width: 75, sortable: true, align: "center" }));
	EditorGridPanelColumnModel.add("BirthDate", new Ext.grid.Column({ dataIndex: "BirthDate", header: "BirthDate", renderer: Ext.util.Format.dateRenderer("d/m/Y"), editor: BirthDateEdit, width: 100, sortable: true, align: "center" }));
	*/
	/*
	EditorGridPanelColumnModel.add("Id", { dataIndex: "Id", header: "ID", width: 30, sortable: true, hidden: true });
	EditorGridPanelColumnModel.add("Name", { id: "NameCol", dataIndex: "Name", header: "Name", editor: NameEdit, width: 180, sortable: true });
	EditorGridPanelColumnModel.add("Salary", { dataIndex: "Salary", header: "Salary", editor: SalaryEdit, width: 75, sortable: true, align: "center" });
	EditorGridPanelColumnModel.add("BirthDate", { dataIndex: "BirthDate", header: "BirthDate", renderer: Ext.util.Format.dateRenderer("d/m/Y"), editor: BirthDateEdit, width: 100, sortable: true, align: "center" });
	*/
	combo.on('select', function(combo, record) {
		bbar.pageSize = parseInt(record.get('id'), 10);
		bbar.doLoad(bbar.cursor);
	}, this);

	store.load({ params: { start: 0, limit: parseInt(Ext.getCmp("perpage").getValue(), 10)} });
});

function OnMetachange(store, meta, cmd) {
    delete store.baseParams.first;

    Ext.Ajax.request({
        url: "GridColumnModelHandler.aspx",
        success: function(response, opts){
            var
                grid;

            if(grid=Ext.getCmp("TestGrid"))
            {
                var
                    cmA=Ext.decode(response.responseText),
                    autoExpandColumn=null,
                    cm,
                    plugins=null;
                    //plugins=[];

				for(var i=cmA.length-1; i>=0; --i)                    
                {
                	if (cmA[i].id && cmA[i].id.indexOf("AutoExpand") != -1)
                		autoExpandColumn = cmA[i].id;

                	switch (cmA[i].type)
                    {
                        case "date" :
                        {
                        	cmA[i].renderer = Ext.util.Format.dateRenderer("d/m/Y");
                        	CheckEdit(cmA[i], new Ext.form.DateField({ format: "d/m/Y" }));
                            break;
                        }
                        case "float" :
                        {
                        	CheckEdit(cmA[i], new Ext.form.NumberField());
                            break;
                        }
                        case "string" :
                        {
                        	CheckEdit(cmA[i], new Ext.form.TextField());
                            break;
                        }
                        case "boolean":
                        {
                        	cmA[i]=new Ext.grid.CheckColumn({
                        		header: cmA[i].header,
                        		dataIndex: cmA[i].dataIndex,
                        		width: cmA[i].width
                        	});
                        	//plugins=cmA[i];
                        	//plugins.push(cmA[i]);
							break;                        
                        }
                    }
                };
                
                cm=new Ext.grid.ColumnModel(cmA);
                if(autoExpandColumn)
                	grid.autoExpandColumn = autoExpandColumn;
                if(plugins)
                //if(plugins.length>0)
                	grid.plugins = plugins;
                else if(grid.plugins)
                	delete grid.plugins;
                grid.reconfigure(store,cm);
            }
        },
        failure: function(response, opts){
            alert("Tampax!");
        }
    });
}

function CheckEdit(item, editor)
{
    if(item.id && item.id.indexOf("Edit")!=-1)
        item.editor=editor;
}