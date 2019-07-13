/**
 * The main application class. An instance of this class is created by app.js when it
 * calls Ext.application(). This is the ideal place to handle application launch and
 * initialization details.
 */
Ext.define('TestMVCI.Application', {
    extend: 'Ext.app.Application',

    name: 'TestMVCI',

    quickTips: false,
    platformConfig: {
        desktop: {
            quickTips: true
        }
    },

    stores: [
        // TODO: add global / shared stores here
    ],

    launch: function () {
        if(window.console && console.log)
            console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

        if (window.console && console.log)
            console.log("launch(%o)", arguments);
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
