Ext.define('App.view.SpikeView', {
  extend: 'Ext.Component',
  alias: 'widget.spike_view',
  html: 'this is a test component',
  
  initComponent: function() {
    this.callParent(arguments)
    this.addEvents('test_event')
  }
});