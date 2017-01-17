Ext.ns('App.Components');
 
App.Components.NameFormPanel = Ext.extend(App.Components.AbstractFormPanel, {
     title:'Edit name data'
    ,submitUrl:'nameAction.asp'
    ,okT:'OK'
 
    ,buildItems:function(config) {
        config.items = [{
             name:'firstName'
            ,fieldLabel:'First Name'
        },{
             name:'lastName'
            ,fieldLabel:'Last Name'
        },{
             name:'middleName'
            ,fieldLabel:'Middle Name'
        },{
             xtype:'datefield'
            ,name:'dob'
            ,fieldLabel:'DOB'
        }];
    } // eo function buildItems
 
    //Extension
    ,buildButtons:function(config) {
 
        // let parent build buttons first
        App.Components.NameFormPanel.superclass.buildButtons.apply(this, arguments);
 
        // tweak the submit button
        config.buttons[0].text = this.okT;
        config.buttons[0].handler = this.onOkBtn;
 
    } // eo function buildButtons
 
    //Override
    ,onOkBtn:function() {
        console.info('OK btn pressed');
    } // eo function onOkBtn
 
}); // eo extend

Ext.reg('nameformpanel', App.Components.NameFormPanel);
 
// eof