// http://www.sencha.com/forum/showthread.php?247414-Selection-of-records-over-multiple-pages-in-a-grid

Ext.define('Ext.ux.grid.plugin.PagingSelectionPersistence', {
alias: 'plugin.pagingselectpersist',
extend: 'Ext.AbstractPlugin',
pluginId: 'pagingSelectionPersistence',


//array of selected records
selection: [],
//hash map of record id to selected state
selected: {},
    
init: function(grid) {
 
 this.grid = grid;
 this.selModel = this.grid.getSelectionModel();
 this.isCheckboxModel = (this.selModel.$className == 'Ext.selection.CheckboxModel');
 this.origOnHeaderClick = this.selModel.onHeaderClick;
 this.bindListeners();
},




destroy: function() {
 this.selection = [];
 this.selected = {};
 this.disable();
},


enable: function() {
 var me = this;
 if(this.disabled && this.grid) {
  this.grid.getView().on('refresh', this.onViewRefresh, this);
  this.selModel.on('select', this.onRowSelect, this);
  this.selModel.on('deselect', this.onRowDeselect, this);
  if(this.isCheckboxModel) {
   this.selModel.onHeaderClick = function(headerCt, header, e) {
   var isChecked = header.el.hasCls(Ext.baseCSSPrefix + 'grid-hd-checker-on');
   me.origOnHeaderClick.apply(this, arguments);        
   if(isChecked) {
    me.onDeselectPage();
   }
   else {
    me.onSelectPage();
    }
   };
  }
 }
 this.callParent();
},
    
disable: function() {
 if(this.grid) {
  this.grid.getView().un('refresh', this.onViewRefresh, this);
  this.selModel.un('select', this.onRowSelect, this);
  this.selModel.un('deselect', this.onRowDeselect, this);
  this.selModel.onHeaderClick = this.origOnHeaderClick;
 }
 this.callParent();
},




bindListeners: function() {
 var disabled = this.disabled;
 this.disable();
 if(!disabled) {
  this.enable();
 }
},


   
onViewRefresh : function(view, eOpts) {
 var store = this.grid.getStore(),
 sel = [],
 hdSelectState,
 rec,
 i;
 this.ignoreChanges = true;
 for(i = store.getCount() - 1; i >= 0; i--) {
  rec = store.getAt(i);
  if(this.selected[rec.getId()]) {
   sel.push(rec);
  }
 }
 this.selModel.select(sel, false);


 if(this.isCheckboxModel) {
  hdSelectState = (this.selModel.selected.getCount() === this.grid.getStore().getCount());
  this.selModel.toggleUiHeader(hdSelectState);
 }
 this.ignoreChanges = false;
},
    
onRowSelect: function(sm, rec, idx, eOpts) {
 if(this.ignoreChanges === true) {
  return;
 }
 if(!this.selected[rec.getId()]) 
 {  
  this.selection.push(rec);
  this.selected[rec.getId()] = true;
 }
  var r = grid.getSelectionModel().getSelection();  
  var results=new Array();
   for(i=0; i<=r.length-1; i++){
    var checkarray=r[i].get('id');   
   }
results.push(checkarray);
 alert('Selected Record is'+results);
},
      
onRowDeselect: function(sm, rec, idx, eOpts) {
 var i; 
 if(this.ignoreChanges === true) {
  return;
 }    
 if(this.selected[rec.getId()])
 {  
  for(i = this.selection.length - 1; i >= 0; i--) {
   if(this.selection[i].getId() == rec.getId()) {
    this.selection.splice(i, 1);
    this.selected[rec.getId()] = false;
    break;
   }
  }
 }
},
    
onSelectPage: function(){ 
 var sel = this.selModel.getSelection(),
 selectedCheckboxLength= this.getPersistedSelection().length, 
 i;
 for(i = 0; i < sel.length; i++) {
  selection1=this.onRowSelect(this.selModel, sel[i]); 
 }
 if(selectedCheckboxLength!== this.getPersistedSelection().length) {
  this.selModel.fireEvent('selectionchange', this.selModel, [], {});
 }
 var results=new Array();
 var r = grid.getSelectionModel().getSelection();  
  for(i=0; i<=r.length-1; i++){  
   var checkarray=r[i].get('id');  
   results.push(checkarray); 
   results.sort();
   for ( var i = 1; i < results.length; i++ ){
    if ( results[i] === results[ i - 1 ] ) {
     results.splice( i--, 1 );
    }  
   }   
  }  
alert('Selected Records are'+results);
},
   
onDeselectPage: function() {
 var store = this.grid.getStore(),
 selectedCheckboxLength= this.getPersistedSelection().length,
 i;
    
 for(i = store.getCount() - 1; i >= 0; i--) {
  this.onRowDeselect(this.selModel, store.getAt(i));
 }        
 if(selectedCheckboxLength!== this.getPersistedSelection().length) {
  this.selModel.fireEvent('selectionchange', this.selModel, [], {});
 }
},  
    
getPersistedSelection: function() {
  return [].concat(this.selection);
}, 
   
clearPersistedSelection: function(){ 
    var changed = (this.selection.length > 0);   
    this.selection = [];
    this.selected = {};
    this.onViewRefresh();    
    if(changed) {
     this.selModel.fireEvent('selectionchange', this.selModel, [], {});
   }
}


});