Ext.BLANK_IMAGE_URL = "../images/default/s.gif";

Ext.onReady(function() {
    Ext.QuickTips.init();

    var 
        store = new Ext.data.JsonStore({
            url: "Data.aspx",
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
			listeners: {
				load: function(s, r, o) {
					var
						rec;

					if(selected.length>0 && r.length>0)
						for(var i=selected.length-1; i>=0; --i)
							if(rec=s.getById(selected[i]))
								grid.selModel.selectRow(s.indexOf(rec),true);
				},
				save: function(s, b, d) {
					grid.getBottomToolbar().doLoad(0);
				}
			}
        }),
        tbar = new Ext.Toolbar({
			items: [
				" ",
			{
				xtype: "button",
				text: "Send",
				handler: function() {
					Ext.Ajax.request({
						url: "Selected.aspx",
						params: { xaction: "update", selected: selected },
						method: "POST",
						success: function(result, request) {
							var
								r=Ext.decode(result.responseText);

							if(r.success)
								;
						},
						failure: function(result, request) {
							if(Ext.isGecko && ("console" in window))
								;
						}
					});
				}
			},
				" ",
			{
				xtype: "button",
				text: "Save",
				handler: function() {
					store.save();
				}
			},
				" ",
			{
				xtype: "button",
				text: "getSelections()",
				handler: function() {
					var
						s=checkboxSel.getSelections();

					alert(s.length);
				}
			},
				" ",
			{
				xtype: "button",
				text: "selectRecords()",
				handler: function(){
					var
						rs=[];

					store.each(function(r){
						rs.push(r);
					});

					grid.getSelectionModel().selectRecords(rs, true);
				}
			},
				"->"
			]
        }),
        combo = new Ext.form.ComboBox({
            width: 40,
            store: new Ext.data.ArrayStore({
                fields: ["id"],
                data: [ ["2"], ["4"], ["6"] ]
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
        checkboxSel = new Ext.grid.CheckboxSelectionModel({
			//id: "MyHeader", // http://www.sencha.com/forum/showthread.php?114118-How-to-do-invisible-checkbox-in-header-CheckboxSelectionModel
			//header: "My header",
			header: "<div class=\"x-grid3-hd-checker\">&nbsp;</div><div>Искл</div>",
			width: 30,
			//checkOnly: true,
			//align: "right",
			listeners: {
				rowselect: function(sm, rowIndex, r) {
					if(selected.indexOf(r.id)==-1)
						selected.push(r.id);
				},
				rowdeselect: function(sm, rowIndex, r) {
					var
						idx;

					if((idx=selected.indexOf(r.id))!=-1)
						selected.splice(idx,1);
				}
			}
        }),
        NameEdit = new Ext.form.TextField(),
		SalaryEdit = new Ext.form.NumberField(),
		BirthDateEdit = new Ext.form.DateField({ format: "d/m/Y" }),
        colModel = new Ext.grid.ColumnModel({
            columns: [
			    checkboxSel,
				{ dataIndex: "Id", header: "ID", width: 30, sortable: true, hidden: true },
				{ id: "ColName", dataIndex: "Name", header: "Name", editor: NameEdit, width: 180, sortable: true },
				{ dataIndex: "Salary", header: "Salary", editor: SalaryEdit, width: 75, sortable: true, align: "center" },
				{ dataIndex: "BirthDate", header: "BirthDate", renderer: Ext.util.Format.dateRenderer("d/m/Y"), editor: BirthDateEdit, width: 100, sortable: true, align: "center" }
			]
        }),
		grid = new Ext.grid.EditorGridPanel({
			region: "center",
			clicksToEdit: 1,
			store: store,
			selModel: checkboxSel,
			colModel: colModel,
			tbar: tbar,
			bbar: bbar
			//,cls: "no_check_header" //http://www.sencha.com/forum/showthread.php?114118-How-to-do-invisible-checkbox-in-header-CheckboxSelectionModel
		}),
		viewport = new Ext.Viewport({
			layout: 'border',
			renderTo: Ext.getBody(),
			items: [ grid ]
		}),
	selected;
        
	Ext.Ajax.request({
		url: "Selected.aspx",
		params: { xaction: "read" },
		method: "POST",
		success: function(result, request) {
			selected=Ext.decode(result.responseText);
			grid.getBottomToolbar().doLoad(0);			
		},
		failure: function(result, request) {
			if(Ext.isGecko && ("console" in window))
			;
		}
	});
});