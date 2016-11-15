Ext.define("TG.controller.Tabs", {
    extend: "Ext.app.Controller",

    views: ["TGTabPanel"],

    init: function (application) {
        if (window.console && console.log)
            console.log("TG.controller.Tabs.init(%o)", arguments);

        this.control({
            "viewport > panel": {
                render: this.onRendered
            }
        });
    },

    onRendered: function () {
        if (window.console && console.log)
            console.log("TG.controller.Tabs.onRendered(%o)", arguments);
    }
});