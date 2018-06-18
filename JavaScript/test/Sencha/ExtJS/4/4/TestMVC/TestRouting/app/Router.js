Ext.define("TestRouting.Router", {
    requires: [
        "Ext.util.History"
    ],

    singleton: true,

    tag: "!\/",
    paramsDelimiter: "?",

    init: function (application) {
        var me = this;

        if (me.ready) {
            return me;
        }

        me.history = Ext.util.History;
        me.application = application;

        me.history.init();
        me.history.on("change", me.onChange, me);

        me.application.on("navNodeSelected", me.onNavNodeSelected, me);
        me.application.on("gridRowSelected", me.onGridRowSelected, me);

        me.onChange(me.history.getToken());

        me.ready = true;
    },

    onChange: function (token) {
        if (window.console && console.log)
            console.log("Router.onChange(\"%s\") %o", token, arguments);
    },

    onNavNodeSelected: function() {
        if (window.console && console.log)
    		console.log("Router.onNavNodeSelected(%o)", arguments);
    },

    onGridRowSelected: function() {
        if (window.console && console.log)
    		console.log("Router.onGridRowSelected(%o)", arguments);
    }
});