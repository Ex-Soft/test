Ext.define('AM.view.user.List' ,{
    extend: 'Ext.grid.Panel',
    alias : 'widget.userlist',

    title : 'All Users',
    store: 'Users',

	constructor: function (config) {
		if (window.console && console.log)
			console.log("AM.view.user.List.constructor(%o)", config);

		this.callParent([config]);

		return this;
	},

    initComponent: function() {
        if (window.console && console.log)
            console.log("AM.view.user.List.initComponent()");

        this.callParent(arguments);
    },

    columns: [
            {header: 'Name',  dataIndex: 'name',  flex: 1},
            {header: 'Email', dataIndex: 'email', flex: 1}
    ]
});