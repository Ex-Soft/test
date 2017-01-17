Ext.ns("App.Components");

App.Components.EditorGridPanelWithPaging = Ext.extend(Ext.grid.EditorGridPanel, {

	GetPageSize: function(CookieName)
	{
		var
			defaultPageSize=2;

		if(!CookieName
			|| !(CookieName=CookieName.replace(/\s/ig,"")).length)
			return defaultPageSize;

		var
			c,
			cv = (c=Ext.util.Cookies.get(CookieName)) ? Ext.urlDecode(c) : {};

		return cv.pageSize ? (!isNaN(c=parseInt(cv.pageSize,10)) ? c : defaultPageSize) : defaultPageSize;
	},

	SetPageSize: function(CookieName, pageSize)
	{
		if(!CookieName
			|| !(CookieName=CookieName.replace(/\s/ig,"")).length)
			return;
			
		var
			c,
			cv = (c=Ext.util.Cookies.get(CookieName)) ? Ext.urlDecode(c) : {};

		if(!cv.pageSize
			|| parseInt(cv.pageSize,10)!=pageSize)
		{
			cv.pageSize=pageSize;
			//Ext.util.Cookies.set(CookieName,Ext.urlEncode(cv),new Date().add(Date.YEAR,1));
			document.cookie=CookieName+"="+Ext.urlEncode(cv)+";expires="+new Date().add(Date.YEAR,1).toGMTString();
		}
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
				value: this.GetPageSize(this.cookieName).toString(),
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

							this.SetPageSize(this.cookieName, bbar.pageSize=parseInt(record.get("id"),10));
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
			});

		Ext.apply(this, Ext.apply(this.initialConfig, {
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
		}));

		App.Components.EditorGridPanelWithPaging.superclass.initComponent.apply(this, arguments);
	}
});