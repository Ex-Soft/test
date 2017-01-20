// https://gist.github.com/twasink/4070009
// http://loongest.com/extjs/jasmine/
// http://compiledammit.com/2012/09/06/using-jasmine-to-test-an-extjs-application/
// http://jonathangrimes.com/2011/10/jasmine-extjs-mvc-a-love-story/ (Ajax hook)
describe("UnitTestingI.controller.MainMenu", function() {
	var
		controller = null,
		widget = null,
		tmpDiv = null,
		tmpDivId = "componentTestArea";

	it('should be able to instantiate a controller', function() {
		controller = UnitTestingI.app.getController("MainMenu")
		// NB: We've created a controller outside of the lifecycle of the Application. We must manually initialise it.
		controller.init()
		// If we'd defined a launch method for controller, we'd need to call it here
		expect(controller).toBeTruthy()
	});

	it("should be able to create a widget, via the controller", function() {
		if(!tmpDiv)
			tmpDiv = Ext.DomHelper.append(Ext.getBody(), Ext.String.format("<div id=\"{0}\" style=\"visibility: hidden\"></div>", tmpDivId));

		widget = controller.getView("MainMenu").create({ renderTo: Ext.get(tmpDivId) });

		expect(widget).toBeTruthy()
	});

	it("should be able to fire events on the widget, and have them picked up by the controller", function() {
		spyOn(controller, "onTestEvent")

		widget.fireEvent("testEvent");

		expect(controller.onTestEvent).toHaveBeenCalled()
	});

	/*
	beforeEach(function() {
		if(!tmpDiv)
			tmpDiv = Ext.DomHelper.append(Ext.getBody(), Ext.String.format("<div id=\"{0}\" style=\"visibility: hidden\"></div>", tmpDivId));

		if(!ctrl)
		{
			ctrl = UnitTestingI.app.getController("MainMenu");
			ctrl.init();
		}
		
		if(!view)
			view = ctrl.getView("MainMenu").create({ renderTo: Ext.get(tmpDivId) });
	});
	*/

	it("should ref MainMenu objects", function() {
		var cmp = controller.getMainMenu();

		expect(cmp).toBeDefined();
	});

	it("should ref MainMenu button \"DoIt!\"", function() {
		var btn = controller.getButtonDoIt();

		expect(btn.text).toBe("DoIt!");
	});

	it("should control MainMenu button click events", function() {
		spyOn(controller, "onButtonClick");

		widget.down("button").fireEvent("click");

		expect(controller.onButtonClick).toHaveBeenCalled();
	});
});