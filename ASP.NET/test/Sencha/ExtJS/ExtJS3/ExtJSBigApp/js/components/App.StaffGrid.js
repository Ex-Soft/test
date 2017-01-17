/* http://www.bewareofthebear.com/category/ext-js/ */
/* http://www.bewareofthebear.com/ext-js/ext-js-pagingtoolbar-pageresizer/ */

Ext.ns("App.Components");

App.Components.StaffGrid = Ext.extend(Ext.grid.GridPanel, {
    constructor: function(c) {
        var store = new App.Store.StaffList();

        var d = {
            border: false,
            loadMask: true,
            sm: new Ext.grid.RowSelectionModel({
                singleSelect: true
            }),
            cm: new Ext.grid.ColumnModel({
                columns: [
                    { dataIndex: "Id", header: "ID", width: 30, sortable: true, hidden: true },
                    { id: "ColName", dataIndex: "Name", header: "Name", width: 180, sortable: true },
                    { dataIndex: "Salary", header: "Salary", width: 75, sortable: true, align: "center" },
                    { dataIndex: "BirthDate", header: "BirthDate", renderer: Ext.util.Format.dateRenderer(App.Config.DateFormat), width: 100, sortable: true, align: "center" }
                ]
            }),
            autoExpandColumn: "ColName",
            store: store,
            //tbar: new App.Components.MainToolBar(),
            bbar: new Ext.PagingToolbar({
                pageSize: App.Config.GrigPageSize,
                store: store,
                displayInfo: true,
                items: [
					"-",
					"Per page: ",
					new Ext.form.ComboBox({
						id: "perpage",
						name: "perpage",
						width: 40,
						store: new Ext.data.ArrayStore({
							fields: ["id"],
							data: [
								["5"],
								["10"],
								["15"]
							]
						}),
						mode: "local",
						value: "5",
						listWidth: 40,
						triggerAction: "all",
						displayField: "id",
						valueField: "id",
						editable: false,
						forceSelection: true,
						listeners: {
							scope: this,
							select: function(combo, record, index){
								//this.getStore().load({params: {start: 0, limit: this.getBottomToolbar().pageSize=parseInt(record.get("id"),10)}});

								var
									bbar=this.getBottomToolbar();
									
								bbar.pageSize=parseInt(record.get("id"),10);
								bbar.doLoad(0 /*bbar.cursor*/);
							}
						}
					})
                ],
                displayMsg: "Displaying items {0} - {1} of {2}",
                emptyMsg: "No items found"
            })
        }

        App.Components.StaffGrid.superclass.constructor.call(this, Ext.apply(d, c));
    }
});
Ext.reg('staffgrid', App.Components.StaffGrid);