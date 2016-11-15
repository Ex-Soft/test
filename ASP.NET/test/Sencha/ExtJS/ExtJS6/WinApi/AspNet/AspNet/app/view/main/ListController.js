Ext.define('AspNetApp.view.main.ListController', {
    extend: 'Ext.app.ViewController',

    alias: 'controller.list',

    onSelect: function(grid, record , index , eOpts)  {
        if (window.console && console.log)
            console.log("ListController.onSelect(%o)", arguments);

        var
            _grid_;

        _grid_ = this.lookupReference('mainlist');
    }
});
