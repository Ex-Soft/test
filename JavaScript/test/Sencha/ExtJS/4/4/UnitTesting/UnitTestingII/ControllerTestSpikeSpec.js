// https://gist.github.com/twasink/4070009

describe('A spike for a technique for testing controllers', function() {

  var controller = null
  it('should be able to instantiate a controller', function() {
    controller = App.app.getController('SpikeController')
    // NB: We've created a controller outside of the lifecycle of the Application. We must manually initialise it.
    controller.init()
    // If we'd defined a launch method for controller, we'd need to call it here
    expect(controller).toBeTruthy()
  })
  
  it("should have no valid references before making widgets", function() {
    expect(controller.getFoobar()).toBeUndefined()
    expect(controller.getBazbux()).toBeUndefined()
    expect(controller.getSpikeView()).toBeUndefined()
  })
  
  var widget = null
  it("should be able to create a widget, via the controller", function() {
    widget = controller.getView('SpikeView').create({ id: 'foobar' })
    
    expect(widget).toBeTruthy()
  })
  it("should be able to fire events on the widget, and have them picked up by the controller", function() {
    spyOn(controller, 'onTestEvent')
    
    widget.fireEvent('test_event')
    
    expect(controller.onTestEvent).toHaveBeenCalled()
  })
  it("should be able to fire events on the widget, and have them picked up by the controller using the xtype", function() {
    spyOn(controller, 'onGenericTestEvent')
    widget.fireEvent('test_event')
    
    expect(controller.onGenericTestEvent).toHaveBeenCalled()
  })
  
  it("should now be able to get refs for foobar widget", function() {
    expect(controller.getFoobar()).toBeDefined()
    expect(controller.getBazbux()).toBeUndefined()
    expect(controller.getSpikeView()).toBeDefined()
    
    expect(controller.getFoobar()).toBe(controller.getSpikeView()) // because we made foobar first
  })
  
  var widget2 = null
  it("should be able to pick up events via the xytpe on random widgets", function() {
    widget2 = controller.getView('SpikeView').create({ id: 'bazbux' })

    spyOn(controller, 'onTestEvent')
    spyOn(controller, 'onGenericTestEvent')
    widget2.fireEvent('test_event')
    
    expect(controller.onTestEvent).not.toHaveBeenCalled()
    expect(controller.onGenericTestEvent).toHaveBeenCalled()
  })

  it("should now be able to get refs for bazbux widget", function() {
    expect(controller.getBazbux()).toBeDefined()
    
    expect(controller.getFoobar()).toBe(controller.getSpikeView()) // because we made foobar first
  })

  it("references are the widgets", function() {
    expect(controller.getFoobar()).toBe(widget)  
  })
  
  if (render_tests) {
    // Notice that we could do all of that event testing without rendering the view!
    it("should be able to render the widget", function() {
      widget.render('main')
      expect(widget.rendered).toBeTruthy()
    })
  }
})