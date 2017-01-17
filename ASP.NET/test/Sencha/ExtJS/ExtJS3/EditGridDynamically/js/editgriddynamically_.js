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
				metachange: function(store, meta) { OnMetachange(store, meta/*, EditorGridPanelColumnModel*/) }
			}
		}),
		grid = new Ext.grid.EditorGridPanel({
			id: "TestGrid",
			title: "TestGrid",
			clickstoEdit: 1,
			store: store,
			columns: [],
			width: 600,
			height: 500,
			tbar: {
				items: [
					{ text: 'Save Changes', handler: function() { store.save(); } }
				]
			}
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
		})/*,
		EditorGridPanelColumnModel = new Ext.util.MixedCollection()*/;

	store.load();
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
					view=grid.getView(),
					cmA=Ext.decode(response.responseText),
					autoExpandColumn=null,
					cm,
					plugins=[];

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
							plugins.push(cmA[i]);
							break;                        
						}
					}
				};

				cm=new Ext.grid.ColumnModel(cmA);
				if(autoExpandColumn)
					grid.autoExpandColumn = autoExpandColumn;
				if (plugins.length > 0)
				{
					if(plugins.length==1)
					{
						grid.plugins=grid.initPlugin(plugins[0]);
						view.mainBody.on("mousedown", plugins[0].onMouseDown, plugins[0]);
					}
					else
					{
						grid.plugins=[];
						
						for (var i = plugins.length - 1; i >= 0; --i)
						{
							grid.plugins.push(grid.initPlugin(plugins[i]));
							view.mainBody.on("mousedown", plugins[i].onMouseDown, plugins[i]);
						}
					}
				}
				else if(grid.plugins)
					delete grid.plugins;

				grid.reconfigure(store,cm);
			}
		},
		failure: function(response, opts){
			alert("error!!!");
		}
	});
}

function CheckEdit(item, editor)
{
	if(item.id && item.id.indexOf("Edit")!=-1)
		item.editor=editor;
}