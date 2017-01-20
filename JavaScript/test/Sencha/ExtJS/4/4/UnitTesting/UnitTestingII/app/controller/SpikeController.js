Ext.define('App.controller.SpikeController', {
  extend: 'Ext.app.Controller',

  views: [ "SpikeView" ],

  refs: [
    { ref: 'foobar', selector: '#foobar' },
    { ref: 'bazbux', selector: '#bazbux' },
    { ref: 'spikeView', selector: 'spike_view' }
  ],
  
  init: function() {
    this.control({
      // bind an event to a specific ID.
      '#foobar': {
//        test_event: this.onTestEvent // WORKS, BUT IS NOT TESTABLE - the spy will replace the implementation of onTestEvent, but won't change the listener
        test_event: Ext.Function.alias(this, 'onTestEvent') // ALSO WORKS, AND IS TESTABLE
      },
      
      // bind an event to a family of widgets - all widgets with this xtype.
      'spike_view': {
        test_event: Ext.Function.alias(this, 'onGenericTestEvent')
      }
    })
  },
  
  onTestEvent: function() {
    console.log('test event fired')
  },
  
  onGenericTestEvent: function() {
    console.log('generic test event fired')
  }

});