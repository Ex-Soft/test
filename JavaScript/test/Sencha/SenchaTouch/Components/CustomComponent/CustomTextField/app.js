Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.define("CustomFieldInput",{
	extend: "Ext.field.Input",
	xtype: "customfieldinput",
	alias: "widget.customfieldinput",

	initElement: function() {
		var me = this;

		me.callParent();

		if(me.selectIcon)
			me.selectIcon.on({
				tap: "onSelectIconTap",
				touchstart: "onSelectIconPress",
				touchend: "onSelectIconRelease",
				scope: me
			});
	},

	getTemplate: function() {
		var items = [
			{
				reference: 'input',
				tag: this.tag
			},
			{
				reference: 'mask',
				classList: [this.config.maskCls]
			},
			{
				reference: 'selectIcon',
				cls: 'x-more-icon'
			},
			{
				reference: 'clearIcon',
				cls: 'x-clear-icon'
			}
		];

		return items;
	},

	onSelectIconTap: function(e) {
		this.fireEvent('selecticontap', this, e);
		console.log('onSelectIconTap');
	},

	onSelectIconPress: function() {
		this.selectIcon.addCls(Ext.baseCSSPrefix + 'pressing');
	},

	onSelectIconRelease: function() {
		this.selectIcon.removeCls(Ext.baseCSSPrefix + 'pressing');
	}
});


Ext.define("CustomFieldText",{
	extend: "Ext.field.Text",
	xtype: "customfieldtext",
	alias: "widget.customfieldtext",

	config: {
		label: "Label",
		component: {
			xtype: 'customfieldinput',
			type: 'text',
			fastFocus: true
		}
	},

	constructor: function(config) {
		if(window.console && console.log)
			console.log("constructor(%o)", arguments);

		this.callParent(arguments);

		return this;
	},

	initConfig: function(config) {
		if(window.console && console.log)
			console.log("initConfig(%o)", arguments);

		this.callParent(arguments);

		return this;
	},

	initialize: function() {
		if(window.console && console.log)
			console.log("initialize(%o)", arguments);

		this.callParent(arguments);

		this.getComponent().on({
			scope: this,

			selecticontap: "onSelect"
		});

		return this;
	},

	onSelect: function() {
		if(window.console && console.log)
			console.log("onSelect(%o)", arguments);
	}
});

Ext.application({
	launch: function() {
		if(window.console && console.log)
			console.log("core: %s, touch: %s", Ext.versions.core.version, Ext.versions.touch.version);

		Ext.Viewport.add(Ext.create("Ext.Panel", {
			fullscreen: true,
			items: [{
				xtype: "customfieldtext"
			}]
		}));
	}
});