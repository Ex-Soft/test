Ext.define('AspNetApp.Application', {
    extend: 'Ext.app.Application',
    
    name: 'AspNetApp',

    stores: [
        'AspNetApp.store.Task'
    ],
    
    launch: function () {
        // TODO - Launch the application
    },

    onAppUpdate: function () {
        Ext.Msg.confirm('Application Update', 'This application has an update, reload?',
            function (choice) {
                if (choice === 'yes') {
                    window.location.reload();
                }
            }
        );
    }
});
