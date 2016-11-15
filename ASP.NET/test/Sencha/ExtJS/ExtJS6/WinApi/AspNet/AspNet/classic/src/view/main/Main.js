Ext.define('AspNetApp.view.main.Main', {
    extend: 'Ext.container.Viewport',
    xtype: 'app-main',
    layout: 'border',

    requires: [
        'AspNetApp.view.main.MainController',
        'AspNetApp.view.main.MainModel',
        'AspNetApp.view.main.ListController',
        'AspNetApp.view.main.List'
    ],

    controller: 'main',
    viewModel: 'main',

    items:[{
        region: 'west',
        title: 'Date',
        width: '20%',
        items:[{
            xtype: 'datepicker',
            listeners: {
                afterrender: 'onDatePickerAfterRender',
                select: 'onDatePickerSelect'
            }
        }]
    }, {
        region: 'center',
        xtype: 'mainlist'
    }]
});
