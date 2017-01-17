function ShowGrid(cbGenerateStatusCode, tfStatusCode, cbWriteToResponse)
{
	var
		grid=new Ext.grid.EditorGridPanel({
			region: "center",
			loadMask: "Loading...", // equ loadMask: { msg: "Loading..." },
			colModel: new Ext.grid.ColumnModel({
				columns: [
					{ dataIndex: "Id", header: "ID", width: 30, sortable: true, hidden: true },
					{ id: "ColName", dataIndex: "Name", header: "Name", editor: new Ext.form.TextField(), width: 180, sortable: true },
					{ dataIndex: "Salary", header: "Salary", editor: new Ext.form.NumberField(), width: 75, sortable: true, align: "center" },
					{ dataIndex: "BirthDate", header: "BirthDate", renderer: Ext.util.Format.dateRenderer(ApplicationSettings.DateFormat), editor: new Ext.form.DateField({ format: ApplicationSettings.DateFormat }), width: 100, sortable: true, align: "center" }
				]
			}),
			store: new Ext.data.JsonStore({
				proxy: new Ext.data.HttpProxyWithExceptionListener({ url: "DataSource.aspx" }),
				//url: "DataSource.aspx",
				root: "rows",
				idProperty: "Id",
				successProperty: "success",
				totalProperty: "count",
				fields: [
					{ name: "Id", type: "int" },
					"Name",
					{ name: "Salary", type: "float" },
					{ name: "BirthDate", type: "date", dateFormat: "c" }
				],
				writer: new Ext.data.JsonWriter(),
				autoSave: false,
				batch: true,
				baseParams: {
					GenerateStatusCode: cbGenerateStatusCode.getValue(),
					StatusCode: tfStatusCode.getValue(),
					WriteToResponse: cbWriteToResponse.getValue()
				},
				listeners: {
					load: function(store, records, options){
					},
					beforesave: function(store, data){
						lm.show();
					}, 
					save: function(store, batch, data){
						lm.hide();
					},
					exception: function(proxy, type, action, options, response, arg){
						if(window.console)
							console.log("Ext.data.JsonStore.listeners.exception (arguments.length=%i): response.status=%i response.statusText=\"%s\"",arguments.length,response.status,response.statusText);

						lm.hide();
					}
				}
			}),
			autoExpandColumn: "ColName",
			buttons: [{
				text: "load",
				handler: function(btn, e){
					grid.getStore().baseParams.GenerateStatusCode=cbGenerateStatusCode.getValue();
					grid.getStore().baseParams.StatusCode=tfStatusCode.getValue();
					grid.getStore().baseParams.WriteToResponse=cbWriteToResponse.getValue();
					grid.getStore().load();
				}
			}, {
				text: "save",
				handler: function(btn, e){
					grid.getStore().baseParams.GenerateStatusCode=cbGenerateStatusCode.getValue();;
					grid.getStore().baseParams.StatusCode=tfStatusCode.getValue();
					grid.getStore().baseParams.WriteToResponse=cbWriteToResponse.getValue();
					grid.getStore().save();
				}
			}]
		}),
		w = new Ext.Window({
			layout: "border",
			title: "Form",
			height: ApplicationSettings.WindowHeight,
			width: ApplicationSettings.WindowWidth,
			items: [grid]
		}),
		lm;

	w.show();
	lm = new Ext.LoadMask(grid.getEl(), { msg: "Saving..." });
	grid.getStore().load();
}
