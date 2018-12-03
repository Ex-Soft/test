Ext.application({
    name: "DbView",

    extend: "DbView.Application",

    requires: [
        "DbView.view.main.Main"
    ],

    mainView: "DbView.view.main.Main"
});
