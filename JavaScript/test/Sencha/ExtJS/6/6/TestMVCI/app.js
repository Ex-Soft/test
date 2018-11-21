Ext.application({
    name: 'TestMVCI',

    extend: 'TestMVCI.Application',

    requires: [
        'TestMVCI.view.main.Main'
    ],

    mainView: 'TestMVCI.view.main.Main'
});
