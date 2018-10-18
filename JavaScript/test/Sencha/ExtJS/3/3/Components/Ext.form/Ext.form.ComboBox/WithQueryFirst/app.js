Ext.BLANK_IMAGE_URL = "../../../../../../../../Sencha/ExtJS/ExtJS3/ExtJS3/resources/images/default/s.gif";

Ext.ns("Test");

Test.ComboBox = Ext.extend(Ext.form.ComboBox, {
	triggerClass: "x-form-clear-trigger",

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

	/*initTrigger: function() {
		var me = this;

		Test.ComboBox.superclass.initTrigger.apply(me, arguments);

		if (window.console && console.log)
			console.log("initTrigger(%o)", arguments);
	},*/

	/*selectPrev: function() {
		Test.ComboBox.superclass.selectPrev.apply(this, arguments);

		if (window.console && console.log)
			console.log("selectPrev(%o)", arguments);
	},*/

	/*selectNext: function() {
		Test.ComboBox.superclass.selectNext.apply(this, arguments);

		if (window.console && console.log)
			console.log("selectNext(%o)", arguments);
	},*/

	onTriggerClick: function(e, target, eOpts) {
		var me = this,
			el;

		if (window.console && console.log)
			console.log("onTriggerClick(%o)", arguments);

		if (!target || !(el = Ext.fly(target)) || !el.hasClass(me.triggerClass)) {
			if (window.console && console.log)
				console.log("superclass.onTriggerClick(%o)", arguments);

			Test.ComboBox.superclass.onTriggerClick.apply(me, arguments);
			return;
		}

		me.setRawValue();
		me.collapse();
	},

    doQuery : function(q, forceAll){
        q = Ext.isEmpty(q) ? '' : q;
        var qe = {
            query: q,
            forceAll: forceAll,
            combo: this,
            cancel:false
        }, filters;
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
						this.processWithQueryRecord();
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

	processWithQueryRecord: function() {
		var me = this,
			searchQuery = me.getRawValue(),
			rec = me.store.getById(this.queryRecId);

		if (Ext.isEmpty(searchQuery) && rec) {
			me.store.remove(rec);
			return;
		}

		if (!rec) {
			o = {};
			o[this.store.idProperty] = this.queryRecId;
			o[this.displayField] = searchQuery;
			this.store.insert(0, new this.store.recordType(o, this.queryRecId));
		}
		else
			rec.set(this.displayField, searchQuery);
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
	},

	onSelectionChange: function(view, selectedElements) {
		var me = this,
			rec;

		if (!me.inKeyMode || !(rec = me.store.getAt(me.selectedIndex)))
			return;

		//me.setValue(3);
		me.lastSelectionText = me.getDisplayedText(rec);
		Ext.form.ComboBox.superclass.setValue.call(me, me.lastSelectionText);
	},

	getDisplayedText: function(rec) {
		var me = this,
			type = rec.get("type"),
			value = rec.get(me.displayField),
			queryRec = me.store.getById(me.queryRecId);

		return !Ext.isEmpty(type) ? String.format("{0} {1}:{2}", queryRec.get(me.displayField), type, value) : value;
	}
});

Ext.onReady(function() {
	Ext.QuickTips.init();

	if(window.console && console.clear)
		console.clear();

	if(window.console && console.log)
		console.log(Ext.version);

	var
		onSelect = function(combo, record, index) {
			if(window.console && console.log)
				console.log("onSelect(%o)", arguments);
		},
		store = new Ext.data.ArrayStore({
			autoDestroy: true,
			idIndex: 0,
			fields: [ "id", "type", "value"],
			data : [
				[ 1, "", "Env1" ],
				[ 2, "", "Env2" ],
				[ 3, "", "Env3" ],
				[ 4, "group", "Group1" ],
				[ 5, "group", "Group2" ],
				[ 6, "group", "Group3" ],
				[ 7, "region", "Region1" ],
				[ 8, "region", "Region2" ],
				[ 9, "region", "Region3" ]
			]
		}),
		combobox1 = new Test.ComboBox({
			store: store,
			valueField: "id",
			displayField: "value",
			groupField: "group",
			mode: "local"
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

	combobox1.on("select", onSelect);
});
