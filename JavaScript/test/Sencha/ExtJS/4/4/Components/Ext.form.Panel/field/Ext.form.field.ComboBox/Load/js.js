//http://blog.oomta.com/extjs-4-comboboxes-mvc-autoloading-of-many-stores-loading-models/
Ext.form.field.ComboBox.override( {
  setValue: function(v) {
    if(!this.store.isLoaded && this.queryMode == 'remote' && this.store.proxy.type !== 'direct') {
      v = (v && v.toString) ? v.toString() : v;
      this.store.addListener('load', function() {
        this.store.isLoaded = true;
        this.setValue(v);
      }, this);
      this.store.load();
    } else {
      this.callOverridden(arguments);
    }
  }
});