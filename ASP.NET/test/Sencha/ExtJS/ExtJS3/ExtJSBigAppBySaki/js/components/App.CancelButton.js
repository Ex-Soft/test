Ext.ns('App.Components');

App.Components.CancelButton = Ext.extend(Ext.Button, {
     text:'Cancel'
    ,iconCls:'icon-undo'
    ,initComponent:function() {
        App.Components.CancelButton.superclass.initComponent.apply(this, arguments);
    } // eo function initComponent
}); // eo extend
 
Ext.reg('cancelbutton', App.Components.CancelButton);
 
// eof