BaseGrid = Ext.extend(Ext.grid.EditorGridPanel, {

	constructor: function(config) {
		config = config || {};
		config.listeners = config.listeners || {};
		Ext.applyIf(config.listeners, {
			render: function(grid) {
				if(Ext.isGecko && ("console" in window))
					console.info("BaseGrid.render (constructor)");

				//grid.getBottomToolbar().doLoad(0);
				this.getBottomToolbar().doLoad(0);
			},
			rowcontextmenu: function(grid, rowIndex, e) {
				e.stopEvent();
				grid.getSelectionModel().selectRow(rowIndex);
				this.menu.showAt(e.getXY());
			}
		});

		BaseGrid.superclass.constructor.call(this, config);
	},
	
	initComponent: function() {
		var
			PagingComboBox = new Ext.form.ComboBox({
				width: 40,
				store: new Ext.data.ArrayStore({
					fields: ["id"],
					data: [ ["2"], ["4"], ["8"], ["64"] ]
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
					select: {
						scope: this,
						fn: function(combo, record, index) {
							var
								bbar=this.getBottomToolbar();

							bbar.pageSize=parseInt(record.get("id"),10);
							bbar.doLoad(0);
						}
					}
				}
			}),
			bbar = new Ext.PagingToolbar({
				pageSize: parseInt(PagingComboBox.value, 10),
				store: this.store,
				displayInfo: true,
				items: [
					"-",
					"Per page: ",
					PagingComboBox
				],
				displayMsg: "Displaying items {0} - {1} of {2}",
				emptyMsg: "No items found"
			}),
			selModel = new Ext.grid.RowSelectionModel({
				singleSelect: true
			}),
			menu = new Ext.menu.Menu({
				items: [{
					text: "Ext.menu.Item# 1",
					scope: this,
					handler: function(b, e) {
						var
							row=this.getSelectionModel().getSelected();

						alert(row.id);
					}
				}]
			});

		Ext.apply(this, Ext.apply(this.initialConfig, {
			selModel: selModel,
			menu: menu,
			clickstoEdit: 1,
			bbar: bbar,
			tbar: {
				items: [
					"->",
				{
					xtype: "button",
					text: "Save",
					scope: this,
					handler: function(b, e) {
						this.getStore().save();
					}
				},
					" "
				]
			}
			/*
			, listeners: {
				render: function(grid) {
					if(Ext.isGecko && ("console" in window))
						console.info("BaseGrid.render (initComponent)");

					//bbar.doLoad(0);
					//grid.getBottomToolbar().doLoad(0);
					this.getBottomToolbar().doLoad(0);
				}
			}
			*/
		}));

		BaseGrid.superclass.initComponent.apply(this, arguments);
	}
});