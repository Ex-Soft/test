Ext.BLANK_IMAGE_URL = "../../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.ns("Test");

Test.ComboBox = Ext.extend(Ext.form.ComboBox, {
	queryRecId: -1,
	groupRe: /([^:]+)(:?)(.*)/,
	groupField: "",

	initList: function() {
		Test.ComboBox.superclass.initList.apply(this, arguments);

		this.view.on({
			selectionchange: this.onSelectionChange,
			scope: this
		});
	},

	onSelectionChange: function(view, selectedElements) {
		var me = this,
			rec;

		if (!me.inKeyMode || !(rec = me.store.getAt(me.selectedIndex)) || rec.get(me.idProperty) == me.queryRecId)
			return;
			//this.lastSelectionText = text;
			//Ext.form.ComboBox.superclass.setValue.call(this, text);
		me.setValue(/*rec.get(me.displayField) + "blah"*/3);
	},

	selectPrev: function() {
		Test.ComboBox.superclass.selectPrev.apply(this, arguments);

		if (window.console && console.log)
			console.log("selectPrev(%o)", arguments);
	},

	selectNext: function() {
		Test.ComboBox.superclass.selectNext.apply(this, arguments);

		if (window.console && console.log)
			console.log("selectNext(%o)", arguments);
	},

    /**
     * Execute a query to filter the dropdown list.  Fires the {@link #beforequery} event prior to performing the
     * query allowing the query action to be canceled if needed.
     * @param {String} query The SQL query to execute
     * @param {Boolean} forceAll <tt>true</tt> to force the query to execute even if there are currently fewer
     * characters in the field than the minimum specified by the <tt>{@link #minChars}</tt> config option.  It
     * also clears any filter previously saved in the current store (defaults to <tt>false</tt>)
     */
    doQuery : function(q, forceAll){
        q = Ext.isEmpty(q) ? '' : q;
        var qe = {
            query: q,
            forceAll: forceAll,
            combo: this,
            cancel:false
        }, filters, rec, o;
        if(this.fireEvent('beforequery', qe)===false || qe.cancel){
            return false;
        }
        q = qe.query;
        forceAll = qe.forceAll;
        if(forceAll === true || (q.length >= this.minChars)){
            if(this.lastQuery !== q){
                this.lastQuery = q;
                if(this.mode == 'local'){
                    this.selectedIndex = -1;
                    if(forceAll){
                        this.store.clearFilter();
                    }else{
						if (!(rec = this.store.getById(this.queryRecId))) {
							o = {};
							o[this.store.idProperty] = this.queryRecId;
							o[this.displayField] = q;
							this.store.insert(0, new this.store.recordType(o, this.queryRecId));
						}
						else
							rec.set(this.displayField, q);

						if(filters = this.getFilters(q)){
							this.store.filter(filters);
						}else{
							this.store.filter(this.displayField, q, true);
						}
                    }
                    this.onLoad();
                }else{
                    this.store.baseParams[this.queryParam] = q;
                    this.store.load({
                        params: this.getParams(q)
                    });
                    this.expand();
                }
            }else{
                this.selectedIndex = -1;
                this.onLoad();
            }
        }
	},

	getFilters: function(q){
		var me = this,
			match = q.match(me.groupRe),
			result = null;

		if (!Ext.isEmpty(me.groupField) && !Ext.isEmpty(match) && match.length > 3 && match[2] == ":") {
			result = [{ property: me.groupField, value: match[1], anyMatch: true, caseSensitive: false, exactMatch: false }];
			
			if (!Ext.isEmpty(match[3]))
				result.push({ property: me.displayField, value: match[3], anyMatch: true, caseSensitive: false, exactMatch: false });
		}

		return result;			
	}
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		store = new Ext.data.ArrayStore({
			autoDestroy: true,
			idIndex: 0,
			fields: [ "id", "group1", "group2", "group3", "value"],
			data : [
				[ 1, "g1", "g11", "g111", "aaaaaaa" ],
				[ 2, "g1", "g11", "g112", "abbbbbb" ],
				[ 3, "g1", "g11", "g113", "abccccc" ],
				[ 4, "g1", "g12", "g121", "abcdddd" ],
				[ 5, "g1", "g12", "g122", "abcdeee" ],
				[ 6, "g1", "g12", "g123", "abcdeff" ],
				[ 7, "g1", "g13", "g131", "abcdefg" ]
			]
		}),
		combobox1 = new Test.ComboBox({
			store: store,
			valueField: "id",
			displayField: "value",
			groupField: "group",
			mode: "local",
			hideTrigger: true
		})
		panel = new Ext.Panel({
			layout: {
				type: "hbox"
			},
			items: [
				combobox1
			],
			renderTo: Ext.getBody()
		});
});
