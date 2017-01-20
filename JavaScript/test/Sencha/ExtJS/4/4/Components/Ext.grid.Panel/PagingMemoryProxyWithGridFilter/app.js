Ext.Loader.setPath('Ext.ux', '../../../../../../../ExtJS/ExtJS4/ExtJS4.1.1/examples/ux');

Ext.Loader.setConfig({
	enabled: true
});

// http://ido.nl.eu.org/static/js/Ext.ux.data.PagingMemoryProxy.js

Ext.require([
	'Ext.data.*',
	'Ext.grid.*',
	'Ext.ux.data.PagingMemoryProxy'
]);

Ext.application({
	name: 'SAMPLE',

	appFolder: 'app',

	controllers: [
		'Countries'
	],

	launch: function() {
		if(window.console && console.log)
			console.log("Ext.application.launch");

		Ext.create('Ext.container.Viewport', {
			layout: 'fit',
			items: [
				{
					xtype: 'countrylist'
				}
			]
		});
	}
});