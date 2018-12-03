Ext.define("DbView.Application", {
    extend: "Ext.app.Application",

    name: "DbView",

    quickTips: false,
    platformConfig: {
        desktop: {
            quickTips: true
        }
    },

    stores: [],

    launch: function () {
    },

    onAppUpdate: function () {
        Ext.Msg.confirm("Application Update", "This application has an update, reload?",
            function (choice) {
                if (choice === "yes") {
                    window.location.reload();
                }
            }
        );
    }
});
