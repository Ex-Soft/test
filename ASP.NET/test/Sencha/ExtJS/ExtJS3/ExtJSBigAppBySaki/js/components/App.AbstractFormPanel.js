Ext.ns('App.Components');
 
App.Components.AbstractFormPanel = Ext.extend(Ext.form.FormPanel, {
     defaultType:'textfield'
    ,frame:true
    ,width:300
    ,height:200
    ,labelWidth:75
    ,submitUrl:null
    ,submitT:'Submit'
    ,cancelT:'Cancel'
    ,initComponent:function() {
 
        // create config object
        var config = {
            defaults:{anchor:'-10'}
        };
 
        // build config
        this.buildConfig(config);
 
        // apply config
        Ext.apply(this, Ext.apply(this.initialConfig, config));
 
        // call parent
        App.Components.AbstractFormPanel.superclass.initComponent.call(this);
 
    } // eo function initComponent
 
    ,buildConfig:function(config) {
        this.buildItems(config);
        this.buildButtons(config);
        this.buildTbar(config);
        this.buildBbar(config);
    } // eo function buildConfig
 
    ,buildItems:function(config) {
        config.items = undefined;
    } // eo function buildItems
 
	,buildButtons:function(config) {
        config.buttons = [{
             xtype:'submitbutton'
            ,scope:this
            ,handler:this.onSubmit
        },{
             xtype:'cancelbutton'
            ,scope:this
            ,handler:this.onCancel
        }];
    } // eo function buildButtons

	/*
    ,buildButtons:function(config) {
        config.buttons = [{
             text:this.submitT
            ,scope:this
            ,handler:this.onSubmit
            ,iconCls:'icon-disk'
        },{
             text:this.cancelT
            ,scope:this
            ,handler:this.onCancel
            ,iconCls:'icon-undo'
        }];
    } // eo function buildButtons
	*/
	
    ,buildTbar:function(config) {
        config.tbar = undefined;
    } // eo function buildTbar
 
    ,buildBbar:function(config) {
        config.bbar = undefined;
    } // eo function buildBbar
 
    ,onSubmit:function() {
        Ext.MessageBox.alert('Submit', this.submitUrl);
    } // eo function onSubmit
 
    ,onCancel:function() {
		Ext.MessageBox.alert('Cancel', 'This form is canceled');
        //this.el.mask('This form is canceled');
    } // eo function onCancel
 
}); // eo extend