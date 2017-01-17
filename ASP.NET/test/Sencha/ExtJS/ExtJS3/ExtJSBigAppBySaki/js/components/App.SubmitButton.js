Ext.ns('App.Components');
 
App.Components.SubmitButton = Ext.extend(Ext.Button, {
     text:'Submit'
    ,iconCls:'icon-disk'
    ,initComponent:function() {
        App.Components.SubmitButton.superclass.initComponent.apply(this, arguments);
    } // eo function initComponent
}); // eo extend
 
Ext.reg('submitbutton', App.Components.SubmitButton);

// eof