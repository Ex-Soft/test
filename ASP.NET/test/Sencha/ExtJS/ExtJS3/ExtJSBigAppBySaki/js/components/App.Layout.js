Ext.ns("App.Components");
Ext.ns("App.Layout");

App.Components.NorthPanel = Ext.extend(Ext.Toolbar, {
	initComponent: function(config){
		config = config || {
			region:'north',
			height:50,
			items: [{
				xtype:'tbspacer'
			}, {
				xtype:'tbtext',
				text: 'xtype: \"tbtext\"'
			}, {
				xtype:'tbspacer'
			}, {
				xtype:'tbseparator'
			}, {
				xtype:'tbspacer'
			}, {
				text:'Button# 1',
				handler:this.onButtonClick
			}, {
				xtype:'tbspacer'
			}, {
				xtype:'tbseparator'
			}, {
				xtype:'tbspacer'
			}, {
				text:'Button# 2',
				handler:this.onButtonClick
			}, {
				xtype:'tbfill'
			}]
		};
        Ext.apply(this, Ext.apply(this.initialConfig, config));
        App.Components.NorthPanel.superclass.initComponent.apply(this, arguments);
	},
	onButtonClick:function(b, e){
		Ext.MessageBox.alert('Info', b.getText());
	}
});

App.Components.CenterPanel = Ext.extend(Ext.Panel, {
	initComponent: function(config){
        //var formPanel = new App.Components.NameFormPanel();
        //var formPanel = new App.Components.AddressFormPanel();
        
        var formPanel = new App.Components.AbstractFormPanel({
			 title:'Name Form Panel configured inline'
			,width:300
			,height:200
			//,renderTo:Ext.getBody()
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
		});

		config = config || {
            title: "FormPanel:",
            region: "center",
            layout: "fit",
            margins: "0 5 0 5",
            items: [formPanel]
		}

        Ext.apply(this, Ext.apply(this.initialConfig, config));
        App.Components.CenterPanel.superclass.initComponent.apply(this, arguments);
	}
});

/* http://www.sencha.com/forum/showthread.php?47210-constructor-Vs-initComponent */
/* http://www.sencha.com/forum/showthread.php?28085-Tutorial-Extending-an-Ext-Class&p=196221#post196221 */
App.Components.Layout = Ext.extend(Ext.Viewport, {
    constructor: function(config){
        config = config || {};

		config.listeners = config.listeners || {};

		Ext.applyIf(config.listeners, {
			// add listeners config here
		});

        Ext.apply(config, {
            //stuff
        });
        
		if(Ext.isGecko)
			console.info('1. before constructor parent');        

        // call the superclass's constructor 
        App.Components.Layout.superclass.constructor.call(this, config);
        
		if(Ext.isGecko)     
			console.info('4. after constructor parent');        
    },
    
    /** @private */
    initComponent: function(config){
		config = config || {
			layout:'border',
			renderTo: Ext.getBody(),
			items: [new App.Components.NorthPanel(), new App.Components.CenterPanel()]
		};
		
		if(Ext.isGecko)
			console.info('2. before initComponent parent');        

        Ext.apply(this, Ext.apply(this.initialConfig, config));

        // call the superclass's constructor 
        App.Components.Layout.superclass.initComponent.apply(this, arguments);

		if(Ext.isGecko)
			console.info('3. after initComponent parent');        
    }
});