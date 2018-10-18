Ext.BLANK_IMAGE_URL="../../../../ExtJS/resources/images/default/s.gif";

Ext.ns("App");

Ext.onReady(function() {
    Ext.QuickTips.init();

    App.Layout = new App.Components.Layout();
});
