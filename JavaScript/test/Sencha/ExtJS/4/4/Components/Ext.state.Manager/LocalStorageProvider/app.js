Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.onReady(function() {
	Ext.QuickTips.init();
	Ext.state.Manager.setProvider(Ext.create("Ext.state.LocalStorageProvider"));

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	Ext.create("Ext.toolbar.Toolbar", {
		items: [{
			text: "window",
			handler: function(btn, e) {
				Ext.create("Ext.window.Window", {
					title: "title",
					height: 300,
					width: 300,
					autoShow: true,
					stateId: "stateWindowExample",
					stateful: true,
					html: "html"
				});
			}
		}, {
			text: "watch",
			disabled: !window.localStorage,
			handler: function(btn, e) {
				var
					getLocalStoreItems = function() {
						var
							items = [],
							key,
							localStorageProvider = Ext.state.Manager.getProvider(),
							prefix = localStorageProvider.prefix,
							prefixLen = prefix.length;

						for(var i=0, len=localStorage.length; i<len; i++)
							items.push( { id: key=localStorage.key(i), value: localStorage.getItem(key), decodeValue: key.substring(0, prefixLen) == prefix ? Ext.JSON.encode(localStorageProvider.decodeValue(localStorage.getItem(key))) : "" } );

						return items;
					};

				Ext.create("Ext.window.Window", {
					title: "window.localStorage",
					layout: "fit",
					height: (window.innerHeight ? window.innerHeight : (document.documentElement && document.documentElement.clientHeight ? document.documentElement.clientHeight : (document.body.clientHeight ? document.body.clientHeight : 400))) - 200,
					width: (window.innerWidth ? window.innerWidth : (document.documentElement && document.documentElement.clientWidth ? document.documentElement.clientWidth : (document.body.clientWidth ? document.body.clientWidth : 800))) - 200,
					plain: true,
					modal: true,
					autoShow: true,
					stateId: "stateWindowLocalStorage",
					stateful: true,
					items: [{
						xtype: "gridpanel",
						store: Ext.create("Ext.data.Store", {
							autoDestroy: true,
							fields: [ "id", "value", "decodeValue" ],
							data: getLocalStoreItems()
						}),
						columns: [
							{ dataIndex: "id", header: "key", flex: 1 },
							{ dataIndex: "value", header: "value", flex: 2 },
							{ dataIndex: "decodeValue", header: "decodeValue", flex: 2 }
						],
						autoDestroy: true,
						stateId: "stateGridLocalStorage",
						stateful: true
					}]
				});
			}
		}],
		renderTo: Ext.getBody()
	});
});