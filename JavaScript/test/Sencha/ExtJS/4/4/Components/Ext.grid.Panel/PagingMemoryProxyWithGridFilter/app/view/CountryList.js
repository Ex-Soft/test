Ext.define('SAMPLE.view.CountryList' ,{
	extend: 'Ext.grid.Panel',
	alias : 'widget.countrylist',
	title : 'List of Countries',
	store : 'Countries',
	loadMask: true,
	autoHeight: true,
	width: 1000,
	dockedItems: [{
		xtype: 'pagingtoolbar',
		store: 'Countries', 
		dock: 'bottom',
		displayInfo: true,
		items: [
			{
				xtype: 'tbseparator'
			},
			{
				xtype : 'trigger',
				itemId : 'gridTrigger',
				fieldLabel: 'Filter Grid Data',
				triggerCls : 'x-form-clear-trigger',
				emptyText : 'Start typing to filter grid',
				size : 30,
				minChars : 1,
				enableKeyEvents : true,
				onTriggerClick : function(){
					this.reset();
					this.fireEvent('triggerClear');
				}
			}
		]
	}],

	initComponent: function() {

	this.columns = [
		{header: 'Id', dataIndex: 'id',  flex: 1},
		{header: 'Name', dataIndex: 'name', flex: 1}
	];

	this.callParent(arguments);
	}
});