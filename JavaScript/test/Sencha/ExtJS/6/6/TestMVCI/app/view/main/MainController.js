Ext.define('TestMVCI.view.main.MainController', {
    extend: 'Ext.app.ViewController',

    alias: 'controller.main',

    listen: {
        global: {
            globalEvent: "onGlobalEvent"
        }
    },

    onNavButton1Click: function () {
        if (window.console && console.log)
            console.log("onNavButton1Click(%o)", arguments);
    },

    onNavButton2Click: function () {
        if (window.console && console.log)
            console.log("onNavButton2Click(%o)", arguments);
    },

    onCustomEvent: function () {
        if (window.console && console.log)
            console.log("onCustomEvent(%o)", arguments);
    },

    onGlobalEvent: function () {
        if (window.console && console.log)
            console.log("onGlobalEvent(%o)", arguments);
    }
});
