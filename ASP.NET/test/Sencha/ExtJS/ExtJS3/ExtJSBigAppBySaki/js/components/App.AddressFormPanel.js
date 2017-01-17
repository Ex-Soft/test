Ext.ns('App.Components');
 
App.Components.AddressFormPanel = Ext.extend(App.Components.AbstractFormPanel, {
     title:'Edit address data'
    ,submitUrl:'addressAction.asp'
    ,buildItems:function(config) {
        config.items = [{
             name:'address1'
            ,fieldLabel:'Address 1'
        },{
             name:'address2'
            ,fieldLabel:'Address 2'
        },{
             name:'city'
            ,fieldLabel:'city'
        },{
             xtype:'combo'
            ,name:'state'
            ,fieldLabel:'State'
            ,store:['MD', 'VA', 'DC']
        },{
             xtype:'numberfield'
            ,name:'zip'
            ,fieldLabel:'Zip Code'
        }];
    } // eo function buildItems
 
});

Ext.reg('addressformpanel', App.Components.AddressFormPanel);
 
// eof