Ext.Loader.setConfig({
    enabled: true,
    disableCaching: false
});

Ext.application({
    name: "TG",

    appFolder: "app",

    controllers: [
        "Staffs",
        "Tabs"
    ],

    launch: function () {
        if (window.console && console.clear)
            console.clear();

        if (window.console && console.log)
            console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

        if (window.console && console.log)
            console.log("Ext.application.launch");

        Ext.create("TG.view.Viewport", {
        });
    }
});