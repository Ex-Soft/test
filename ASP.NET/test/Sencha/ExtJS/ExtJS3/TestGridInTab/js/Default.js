Ext.BLANK_IMAGE_URL = "../images/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		store = new Ext.data.JsonStore({
			url: "DataSourceHandler.aspx",
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
			listeners: {
				load: { scope: this, fn: function(store, records, options) { OnLoad(store, records, options) } }
			}
		}),
		grid = new Ext.grid.GridPanel({
			id: "MainGrid",
			layout: "border",
			store: store,
			columns: [
				{ dataIndex: "Id", header: "ID", width: 30, sortable: true, hidden: true },
				{ id: "ColName", dataIndex: "Name", header: "Name", width: 180, sortable: true },
				{ dataIndex: "Salary", header: "Salary", width: 75, sortable: true, align: "center" },
				{ dataIndex: "BirthDate", header: "BirthDate", renderer: Ext.util.Format.dateRenderer("d/m/Y"), width: 100, sortable: true, align: "center" }
			],
			height: 500,
			loadMask: true
		}),
		
		/*
		Panel1 = new Ext.Panel({
			layout: "border",
			id: "Panel1",
			items: [{
				region: "center",
				xtype: "grid",
				items: grid
			}]
		}),
		*/
		viewport = new Ext.Viewport({
			id: "MainForm",
			layout: "border",
			renderTo: Ext.getBody(),
			items: [{
				region: "north",
				html: "north"
			}, {
				region: "center",
				xtype: "tabpanel",
				id: "TabPanel",
				activeTab: 0,
				tabPosition: "bottom",
				items: [{
					title: "Tab #1",
					layout: "border",
					items: [{
						region: "north",
						html: "north"
					}, {
						region: "center",
						xtype: "grid",
						items: grid
					}]
				}, {
					title: "Tab #2",
					html: "Tab #2"
				}, {
					title: "Tab #3",
					html: "Tab #3"
				}]
			}]
		});
		
	store.load();
});

function OnLoad(store, records, options) {
	var
		Ctrl;

	if (Ctrl = Ext.getCmp("MainGrid")) {
		Ctrl.doLayout();
		//Ctrl.ownerCt.doLayout();
	}

	if (Ctrl = Ext.getCmp("Panel1")) {
		Ctrl.doLayout();
		//Ctrl.ownerCt.doLayout();
	}
	
	if (Ctrl = Ext.getCmp("TabGrid")) {
		Ctrl.doLayout();
		//Ctrl.ownerCt.doLayout();
	}

	if (Ctrl = Ext.getCmp("TabPanel")) {
		Ctrl.doLayout();
		//Ctrl.ownerCt.doLayout();
	}
}
/*
			items: [{
				region: "north",
				xtype: "toolbar",
				items: [{
					xtype: "button",
					text: "doLayout()",
					handler: OnLoad
				}]
			}, {
				region: "center",
				xtype: "tabpanel",
				items: [{
					title: "Grid",
					//items: Panel1,
					id: "TabGrid",
					// items: grid,
					html: "TabGrid"
				}, {
					title: "Tab# 1",
					html: "Tab# 1"
				}, {
					title: "Tab# 2",
					html: "Tab# 2"
				}]
			}]
*/