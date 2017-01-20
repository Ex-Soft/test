Ext.define('TestMVCIII.view.Viewport', {
    extend: 'Ext.container.Viewport',
    requires:[
        'Ext.layout.container.Fit',
        'TestMVCIII.view.Main'
    ],

    layout: {
        type: 'fit'
    },

    items: [{
        xtype: 'app-main'
    }]
});
