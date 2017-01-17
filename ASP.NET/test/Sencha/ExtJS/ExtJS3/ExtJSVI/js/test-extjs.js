Ext.namespace('myNameSpace');
myNameSpace.LogLogId="LogLog";

Ext.onReady(function() {
	Ext.QuickTips.init();

	var 
	    store = new Ext.data.JsonStore({
	    	url: "DataSource.aspx",
	    	root: "rows",
	    	idProperty: "Id",
	    	successProperty: "success",
	    	totalProperty: "count",
	    	fields: [
	    		{ name: "Id", type: "int" },
	    		"Name",
	    		{ name: "Salary", type: "float" },
	    		{ name: "BirthDate", type: "date", dateFormat: "c" },
	    		{ name: "IsChecked", type: "boolean" } 
	    	],
	    	writer: new Ext.data.JsonWriter(),
	    	autoSave: false,
	    	batch: true,
	    	listeners: {
	    		beforeload: function(store, options) { OnBeforeLoad(store, options) },
	    		beforesave: function(store, data) { OnBeforeSave(store, data) },
	    		beforewrite: function(store, action, rs, options, arg) { OnBeforeWrite(store, action, rs, options, arg) },
	    		load: { scope: this, fn: function(store, records, options) { OnLoad(store, records, options) } },
	    		save: { fn: function(store, batch, data) { OnSave(store, batch, data) } },
	    		update: function(store, record, operation) { OnUpdate(store, record, operation) },
	    		write: function(store, action, result, res, rs) { OnWrite(store, action, result, res, rs) }
	    	}
	    }),
	    checkColumn = new Ext.grid.CheckColumn({
			header: "IsChecked",
			dataIndex: "IsChecked",
			width: 50
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
        NameEdit = new Ext.form.TextField(),
        SalaryEdit = new Ext.form.NumberField(),
        BirthDateEdit = new Ext.form.DateField({
				format: "d/m/Y"
				//format: "d/m/Y H:i:s"
				//,renderer: Ext.util.Format.dateRenderer("d/m/Y") // ??? http://www.extjs.com/forum/showthread.php?p=422363#post422363
			}),
        grid = new Ext.grid.EditorGridPanel({
        	id: "TestGrid",
        	title: "TestGrid",
        	clickstoEdit: 1,
        	store: store,
        	plugins: checkColumn,
        	columns: [
			{ dataIndex: "Id", header: "ID", width: 30, sortable: true, hidden: true },
			{ id: "NameCol", dataIndex: "Name", header: "Name", editor: NameEdit, width: 180, sortable: true },
			{ dataIndex: "Salary", header: "Salary", editor: SalaryEdit, width: 75, sortable: true, align: "center" },
			{ dataIndex: "BirthDate", header: "BirthDate", renderer: Ext.util.Format.dateRenderer("d/m/Y"), editor: BirthDateEdit, width: 100, sortable: true, align: "center" },
			checkColumn
		],
        	autoExpandColumn: "NameCol",
        	width: 600,
        	height: 200,
        	tbar: {
        		items: [
					{ text: 'Save Changes',
						iconCls: 'btn-save',
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
			}, {
				region: "south",
				xtype: "panel",
				height: 100,
				items: [{
					xtype: 'textarea',
					id: myNameSpace.LogLogId,
					width: 500
}]
}]
				});

	combo.on('select', function(combo, record) {
		bbar.pageSize = parseInt(record.get('id'), 10);
		bbar.doLoad(bbar.cursor);
	}, this);

	store.load({ params: { start: 0, limit: parseInt(Ext.getCmp("perpage").getValue(), 10)} });
});

function OnBeforeLoad(store, options) {
	Ext.getCmp(myNameSpace.LogLogId).setValue(Ext.getCmp(myNameSpace.LogLogId).getValue() + " OnBeforeLoad");
	if (store)
		;
}

function OnBeforeSave(store, data) {
	Ext.getCmp(myNameSpace.LogLogId).setValue(Ext.getCmp(myNameSpace.LogLogId).getValue() + " OnBeforeSave");
	if (store)
		;
}

function OnBeforeWrite(store, action, rs, options, arg) {
	Ext.getCmp(myNameSpace.LogLogId).setValue(Ext.getCmp(myNameSpace.LogLogId).getValue() + " OnBeforeWrite");
	if (store)
		;
}

function OnLoad(store, records, options) {
	Ext.getCmp(myNameSpace.LogLogId).setValue(Ext.getCmp(myNameSpace.LogLogId).getValue() + " OnLoad");
	if (store)
		;
}

function OnSave(store, batch, data) {
	Ext.getCmp(myNameSpace.LogLogId).setValue(Ext.getCmp(myNameSpace.LogLogId).getValue() + " OnSave");
	if (store)
		;
}

function OnUpdate(store, record, operation) {
	Ext.getCmp(myNameSpace.LogLogId).setValue(Ext.getCmp(myNameSpace.LogLogId).getValue() + " OnUpdate");
	if (store)
		;
}

function OnWrite(store, action, result, res, rs) {
	Ext.getCmp(myNameSpace.LogLogId).setValue(Ext.getCmp(myNameSpace.LogLogId).getValue() + " OnWrite");
	if (store)
		;
}