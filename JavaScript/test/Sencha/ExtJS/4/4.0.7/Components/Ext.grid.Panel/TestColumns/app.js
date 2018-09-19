Ext.Loader.setConfig({
	enabled: true,
	disableCaching: false
});

Ext.override(Ext.grid.column.Column, {
	setWidth: function(width, /* private - used internally */ doLayout) {
        var me = this,
            headerCt = me.ownerCt,
            siblings,
            len, i,
            oldWidth = me.getWidth(),
            groupWidth = 0,
            sibling;

        if (width !== oldWidth) {
            me.oldWidth = oldWidth;

            me.width = Ext.Number.constrain(width, me.minWidth, me.maxWidth);

            // Bubble size changes upwards to group headers
            if (headerCt.isGroupHeader) {
                siblings = headerCt.items.items;
                len = siblings.length;

                for (i = 0; i < len; i++) {
                    sibling = siblings[i];
                    if (!sibling.hidden) {
                        groupWidth += (sibling === me) ? width : sibling.getWidth();
                    }
                }
                headerCt.setWidth(groupWidth, doLayout);
            } else if (doLayout !== false) {
                // Allow the owning Container to perform the sizing
                headerCt.doLayout();
            }
        }
    }
});

Ext.onReady(function() {
	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log("core: %s, extjs: %s", Ext.versions.core.version, Ext.versions.extjs.version);

	var
		store = Ext.create("Ext.data.Store", {
			fields: [
				{ name: "id", type: "int" },
				"fstring1",
				"fstring2",
				"fstring3",
				"fstring4",
				{ name: "fdate", type: "date" }
			],
			data: [
				{ id: 1, fstring1: "fstring1", fstring2: "fstring2", fstring3: "fstring3", fstring4: "fstring4", fdate: new Date(2012, 9, 24) },
				{ id: 2, fstring1: "fstring1", fstring2: "fstring2", fstring3: "fstring3", fstring4: "fstring4", fdate: new Date(2012, 10, 24) },
				{ id: 3, fstring1: "fstring1", fstring2: "fstring2", fstring3: "fstring3", fstring4: "fstring4", fdate: new Date(2012, 11, 24) },
				{ id: 4, fstring1: "fstring1", fstring2: "fstring2", fstring3: "fstring3", fstring4: "fstring4", fdate: new Date(2013, 0, 24) },
				{ id: 5, fstring1: "fstring1", fstring2: "fstring2", fstring3: "fstring3", fstring4: "fstring4", fdate: new Date(2013, 1, 24) }
			]
		}),
		columnWithMinWidth = Ext.create("Ext.grid.column.Column", {
			header: "minWidth",
			dataIndex: "fstring4",
			width: 150,
			minWidth: 100,
			listeners: {
				columnresize: function(ct, column, width, eOpts) {
					if (window.console && console.log)
						console.log("column.columnresize(%o)", arguments);
				}
			}
		});

	Object.defineProperty(columnWithMinWidth, "_minWidth", {
		configurable: true,
		enumerable: true,
		value: columnWithMinWidth.minWidth,
		writable: true
	});

	Object.defineProperty(columnWithMinWidth, "minWidth", {
		get: function() {
				return this._minWidth;
		},
		set: function(value) {
			this._minWidth = value;
		}
	});

	columnWithMinWidth.minWidth = 100;
		
	Ext.create("Ext.grid.Panel", {
		store: store,
		columns: [
			{ header: "id", dataIndex: "id" },
			{ header: "fstring1", dataIndex: "fstring1", columns: [
				{ header: "fstring2", dataIndex: "fstring2" },
				{ header: "fstring3", dataIndex: "fstring3" }
			]},
			{ header: "fstring4", dataIndex: "fstring4"/*, items: [
				Ext.create("Ext.form.field.Text")
			]*/},
			{ text: "fdate", dataIndex: "fdate", xtype: "datecolumn", format: "d.m.Y" },
			{ header: "fdate", dataIndex: "fdate", renderer: Ext.util.Format.dateRenderer("d.m.Y") },
			columnWithMinWidth,
			{ header: "fstring4", dataIndex: "fstring4" },
		],
		tbar: {
			items: [{
				text: "columnresize",
				handler: function (btn, e) {
					columnWithMinWidth.fireEvent("columnresize");
				}
			}]
		},
		listeners: {
			columnresize: function(ct, column, width, eOpts) {
				if (window.console && console.log)
						console.log("grid.columnresize(%o)", arguments);
			}
		},
		renderTo: Ext.getBody()
	});
});