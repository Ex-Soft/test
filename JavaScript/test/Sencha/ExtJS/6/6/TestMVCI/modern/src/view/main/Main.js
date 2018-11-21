Ext.define('TestMVCI.view.main.Main', {
    extend: 'Ext.tab.Panel',
    xtype: 'app-main',

    requires: [
        'TestMVCI.view.main.MainController'
    ],

    controller: 'main',

    defaults: {
        tab: {
            iconAlign: 'top'
        },
        styleHtmlContent: true
    },

    tabBarPosition: 'bottom',

    items: [
        {
            title: 'Home',
            iconCls: 'x-fa fa-home',
            layout: 'fit',
            items: [{
                xtype: "grid",
                store: new Ext.data.Store({
                    fields:[ 'name', 'email', 'phone'],
                    data: [
                        { name: 'Lisa', email: 'lisa@simpsons.com', phone: '555-111-1224' },
                        { name: 'Bart', email: 'bart@simpsons.com', phone: '555-222-1234' },
                        { name: 'Homer', email: 'homer@simpsons.com', phone: '555-222-1244' },
                        { name: 'Marge', email: 'marge@simpsons.com', phone: '555-222-1254' }
                    ]
                }),
                columns: [
                    { text: 'Name', dataIndex: 'name' },
                    { text: 'Email', dataIndex: 'email', flex: 1 },
                    { text: 'Phone', dataIndex: 'phone' }
                ]
            }]
        },{
            title: 'Users',
            iconCls: 'x-fa fa-user'/*,
            bind: {
                html: '{loremIpsum}'
            }*/
        },{
            title: 'Groups',
            iconCls: 'x-fa fa-users'/*,
            bind: {
                html: '{loremIpsum}'
            }*/
        },{
            title: 'Settings',
            iconCls: 'x-fa fa-cog'/*,
            bind: {
                html: '{loremIpsum}'
            }*/
        }
    ]
});
