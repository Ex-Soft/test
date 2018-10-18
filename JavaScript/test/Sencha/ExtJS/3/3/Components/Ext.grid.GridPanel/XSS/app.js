Ext.BLANK_IMAGE_URL="../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3.3.1/resources/images/default/s.gif";

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		store = new Ext.data.JsonStore({
			autoDestroy: true,
			fields: [
				{ name: "id", type: "int" },
				{ name: "name", type: "string", convert: function(value) {
					if(window.console && console.log)
						console.log("convert(%o)", arguments);

					return value;
				}}
			],
			root: "data",
			url: "data.json",
			listeners: {
				load: function(store, records, options) {
					if(window.console && console.log)
						console.log("Ext.data.JsonStore.load(%o)", arguments);
				}
			}
		}),
		colModel = new Ext.grid.ColumnModel({
			columns: [
				{ dataIndex: "id", header: "Id" },
				{ dataIndex: "name", header: "Name", renderer: function(value) {
					if(window.console && console.log)
						console.log("renderer(%o)", arguments);

					return value;
				}}
			]
		}),
		selModel = new Ext.grid.RowSelectionModel({
			singleSelect: true
		}), 
		grid = new Ext.grid.GridPanel({
			renderTo: Ext.getBody(),
			store: store,
			colModel: colModel,
			selModel: selModel,
			height: 200,
			tbar: {
				items: [{
					text: "load",
					handler: function (btn) {
						var grid;

						if (!(grid = btn.findParentByType("grid")))
							return;

						grid.getStore().load();
					}
				}, {
					text: "addXSS",
					handler: function (btn) {
						var grid,
							store,
							rec;

						if (!(grid = btn.findParentByType("grid"))
							|| !(store = grid.getStore()))
							return;

						rec = new store.recordType({ id: store.getCount() + 1, name: "<img src=x onerror=alert(document.cookie);>.zip" });
						store.add(rec);
					}
				}, {
					text: "getTextWidth",
					handler: function (btn) {
						var grid,
							els;

						if (!(grid = btn.findParentByType("grid"))
							|| Ext.isEmpty(els = grid.getEl().query(".x-grid3-row td div")))
							return;

						Ext.fly(els[els.length - 1]).getTextWidth("<img src=x onerror=alert(document.cookie);>.zip");
					}
				}]
			}
		});
});

/*
    update : function(html, loadScripts, callback) {
        if (!this.dom) {
            return this;
        }
        html = html || "";

        if (loadScripts !== true) {
            this.dom.innerHTML = html; <== !!!
            if (typeof callback == 'function') {
                callback();
            }
            return this;
        }
*/