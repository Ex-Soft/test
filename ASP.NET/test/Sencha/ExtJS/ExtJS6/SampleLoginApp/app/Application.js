/**
 * The main application class. An instance of this class is created by app.js when it
 * calls Ext.application(). This is the ideal place to handle application launch and
 * initialization details.
 */
Ext.define('SimpleLoginApp.Application', {
    extend: 'Ext.app.Application',
    
    name: 'SimpleLoginApp',

    stores: [
        // TODO: add global / shared stores here
    ],

    views: [
        'SimpleLoginApp.view.login.Login',
        'SimpleLoginApp.view.main.Main'
    ],

    launch: function () {
        var loggedIn;

        loggedIn = localStorage.getItem("TutorialLoggedIn");

        Ext.create({
            xtype: loggedIn ? 'app-main' : 'login'
        });
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
