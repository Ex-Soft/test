Ext.define('TestMVCI.view.main.Main', {
    extend: 'Ext.container.Viewport',
    xtype: 'app-main',

    requires: [
        'TestMVCI.view.main.MainController',
        'TestMVCI.ux.tab.CustomPanel'
    ],

    controller: 'main',

    layout: "border",

    items: [{
        region: "west",
        title: "West Nav Panel",
        width: 200,
        collapsible: true,
        split: true,
        bodyPadding: 12,
        layout: 'anchor',
        defaultType: 'button',
        defaults: {
            margin: '0 0 12 0',
            anchor: '100%'
        },
        items: [{
            text: 'Nav Button 1',
            listeners: {
                click: "onNavButton1Click"
            }
        }, {
            text: 'Nav Button 2',
            handler: "onNavButton2Click"
        }, {
            text: 'Nav Button 3',
            handler: function (btn , e) {
                btn.fireEvent("customEvent", btn, "blah-blah-blah");
            },
            listeners: {
                customEvent: "onCustomEvent"
            }
        }, {
            text: 'Nav Button 4',
            handler: function (btn , e) {
                Ext.GlobalEvents.fireEvent("globalEvent", btn, "blah-blah-blah");
            }
        }]
    }, {
        region: "center",
        title: "Center",
        xtype: "customtabpanel",
        items:[{
            title: "Tab #1",
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
        }, {
            title: "Tab #2"
        }, {
            title: "Tab #3"
        }]
    }]
});
