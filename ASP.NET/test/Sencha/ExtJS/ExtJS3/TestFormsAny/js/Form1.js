function ShowForm1()
{
	var
		ComboBox1Store=new Ext.data.Store({
			reader: new Ext.data.JsonReader({
				fields: ["ID", "VAL"],
				root: "rows"
			}),
			proxy: new Ext.data.HttpProxy({
				url: "DataSourceHandler.aspx"
			})
		});
		
	ComboBox1Store.load();

	var	
		f = new Ext.form.FormPanel({
			region: "center",
			url: "FormHandler.aspx",
			frame: true,
			items: [{
				xtype: "combo",
				name: "ComboBox1",
				fieldLabel: "ComboBox1",
				mode: "local",
				store: ComboBox1Store,
				valueField: "ID",
				displayField: "VAL"
			}]
		}),
		w = new Ext.Window({
			layout: "border",
			title: "Form",
			height: 300,
			width: 300,
			items: [f]
		});

	w.show();
}
