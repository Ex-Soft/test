Grid2 = Ext.extend(BaseGrid, {
	initComponent: function() {

		Ext.apply(this, Ext.apply(this.initialConfig, {
			title: "Grid# 2",
			columns: [],
			store: new Ext.data.JsonStore({
				url: "DataSource2.aspx",
				root: "metadata",
				baseParams: { first: true },
				successProperty: "success",
				totalProperty: "count",
				writer: new Ext.data.JsonWriter(),
				autoSave: false,
				batch: true,
				listeners: {
					metachange: {
						scope: this,
						fn: function(store, meta) {
							delete store.baseParams.first;

							var
								grid=this,
								CheckEdit=function(item, editor)
								{
									if(item.id && item.id.indexOf("Edit")!=-1)
										item.editor=editor;
								};

							Ext.Ajax.request({
								url: "GridColumnModelHandler.aspx",
								success: function(response, opts){
									var
										view=grid.getView(),
										cmA=Ext.decode(response.responseText),
										autoExpandColumn=null,
										cm;

									for(var i=cmA.length-1; i>=0; --i)                    
									{
										if (cmA[i].id && cmA[i].id.indexOf("AutoExpand") != -1)
											autoExpandColumn = cmA[i].id;

										switch (cmA[i].type)
										{
											case "date" :
											{
												cmA[i].renderer = Ext.util.Format.dateRenderer(ApplicationSettings.DateFormat);
												CheckEdit(cmA[i], new Ext.form.DateField({ format: ApplicationSettings.DateFormat }));
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
												cmA[i].xtype="checkcolumn";
												break;                        
											}
										}
									};

									cm=new Ext.grid.ColumnModel(cmA);
									if(autoExpandColumn)
										grid.autoExpandColumn = autoExpandColumn;

									grid.reconfigure(store,cm);
									
								},
								failure: function(response, opts){
									alert("error!!!");
								}
							});

						}
					}
				}
			}),
			listeners: {
				render: function(grid) {
					if(Ext.isGecko && ("console" in window))
						console.info("Grid2.render");
				}
			}
		}));

		Grid2.superclass.initComponent.apply(this, arguments);
	}
});