Ext.BLANK_IMAGE_URL="../../../../../ExtJS/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	var
		Bus = new Ext.util.Observable();

	Bus.addEvents("EventN");
	Bus.addEvents("EventE");
	Bus.addEvents("EventS");
	Bus.addEvents("EventW");
	
	var
		nlog = new Ext.form.TextArea({
		}),
		n = new Ext.Panel({
			region: "north",
			height: 100,
			items: [{
				xtype: "button",
				text: "on",
				handler: function(){
					Bus.on("EventN", onEventN);
				}
			},{
				xtype: "button",
				text: "un",
				handler: function(){
					Bus.un("EventN", onEventN);
				}
			},
				nlog
			]
		}),
		onEventN = function(arg){
			nlog.setValue(nlog.getValue() + " " + arg);
		},
		elog = new Ext.form.TextArea({
		}),
		e = new Ext.Panel({
			region: "east",
			width: 100,
			items: [{
				xtype: "button",
				text: "on",
				handler: function(){
					Bus.on("EventE", onEventE);
				}
			},{
				xtype: "button",
				text: "un",
				handler: function(){
					Bus.un("EventE", onEventE);
				}
			},
				elog
			]
		}),
		onEventE = function(arg){
			elog.setValue(elog.getValue() + " " + arg);
		},
		slog = new Ext.form.TextArea({
		}),
		s = new Ext.Panel({
			region: "south",
			height: 100,
			items: [{
				xtype: "button",
				text: "on",
				handler: function(){
					Bus.on("EventS", onEventS);
				}
			},{
				xtype: "button",
				text: "un",
				handler: function(){
					Bus.un("EventS", onEventS);
				}
			},
				slog
			]
		}),
		onEventS = function(arg){
			slog.setValue(slog.getValue() + " " + arg);
		},
		wlog = new Ext.form.TextArea({
		}),
		w = new Ext.Panel({
			region: "west",
			width: 100,
			items: [{
				xtype: "button",
				text: "on",
				handler: function(){
					Bus.on("EventW", onEventW);
				}
			},{
				xtype: "button",
				text: "un",
				handler: function(){
					Bus.un("EventW", onEventW);
				}
			},
				wlog
			]
		}),
		onEventW = function(arg){
			wlog.setValue(wlog.getValue() + " " + arg);
		},
		c = new Ext.Panel({
			region: "center",
			items: [{
				xtype: "button",
				text: "North",
				handler: function(){
					Bus.fireEvent("EventN", "North");
				}
			}, {
				xtype: "button",
				text: "East",
				handler: function(){
					Bus.fireEvent("EventE", "East");
				}
			}, {
				xtype: "button",
				text: "South",
				handler: function(){
					Bus.fireEvent("EventS", "South");
				}
			}, {
				xtype: "button",
				text: "West",
				handler: function(){
					Bus.fireEvent("EventW", "West");
				}
			}]
		}),
		viewport = new Ext.Viewport({
			layout: "border",
			items: [n, e, s, w, c],
			renderTo: Ext.getBody(),
			listeners: {
				render: function(){
					Bus.on("EventN", onEventN);
					Bus.on("EventE", onEventE);
					Bus.on("EventS", onEventS);
					Bus.on("EventW", onEventW);
				}
			}
		});
});
