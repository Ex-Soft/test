Ext.define('AM.controller.Users', {
    extend: 'Ext.app.Controller',
    
    stores: ['Users'],

    models: ['User'],

    views: ['user.Edit', 'user.List'],

    refs: [
        {
            ref: 'usersPanel',
            selector: 'panel'
        }
    ],

    constructor: function (config) {
		if (window.console && console.log)
			console.log("AM.controller.Users.constructor(%o)", config);

		this.callParent(arguments);

		return this;
    },

    init: function(app) {
        if (window.console && console.log)
            console.log("AM.controller.Users.init(%o)", app);

        this.control({
            'viewport > userlist dataview': {
                itemdblclick: this.editUser
            },
            'useredit button[action=save]': {
                click: this.updateUser
            }
        });

        this.callParent(arguments);
    },

    editUser: function(grid, record) {
        var edit = Ext.create('AM.view.User.Edit').show();

        edit.down('form').loadRecord(record);
    },

    updateUser: function(button) {
        var win    = button.up('window'),
            form   = win.down('form'),
            record = form.getRecord(),
            values = form.getValues();

        record.set(values);
        win.close();
        this.getUsersStore().sync();
    }
});