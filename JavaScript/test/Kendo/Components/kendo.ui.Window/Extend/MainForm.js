// http://jsfiddle.net/lhoeppner/qj2HL/
// http://jsbin.com/OfIHOm/1/edit
// http://blogs.telerik.com/kendoui/posts/12-04-03/creating_custom_kendo_ui_plugins
// http://blogs.telerik.com/kendoui/posts/12-10-16/inheriting_from_custom_widgets
// https://gist.github.com/joeriks/4754079

(function ($) {
	var
		kendo = window.kendo,
		ui = kendo.ui,
		Window = ui.Window,
		KWINDOWCONTENT = ".k-window-content";

	var
		MyWindow = Window.extend({
			init: function (element, options) {
				var
					that = this.MyWindow.fn;

				if(typeof element !== "undefined"
					&& $.isPlainObject(element)
					&& typeof element.tagName === "undefined"
					&& typeof options === "undefined")
				{
					options = element;
					element = $("<div>").attr({ id: "testDiv", "data-role": "mywindow", role: "dialog", class: "k-window-content k-content" }).appendTo("body")[0];
					//$.fn.init(element);
				}

				Window.fn.init.call(that, element, options);

				that._customize();

				return that;
			},
			destroy: function () {
				var
					that = this;

				that._destroyCustomize();
				Window.fn.destroy.call(that);
			},

			options: {
				name: 'MyWindow'
			},

			_customize: function () {
				this.originalValue = $(this.element).css('color');
				$(this.element).css('color', 'green');
			},

			_destroyCustomize: function () {
				$(this.element).css('color', this.originalValue);
			}
		});

	ui.plugin(MyWindow);

	/**
	* update kendoWindow's _object method to return our new widget as well
	*/
	ui.Window.fn._object = function (element) {
		var
			content = element.children(KWINDOWCONTENT);

		return content.data("kendoWindow") || content.data("kendoMyWindow") || content.data("kendo" + this.options.name);
	};
})(jQuery);

$(document).ready(function () {
	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
	{
		console.log("jquery: %s", $.fn.jquery);
		console.log("kendo: %s", kendo.version);
	}

	var
		kWindow =
			//$("#divWindow").kendoMyWindow
			kendo.ui.MyWindow
			//$.fn["kendoMyWindow"]
			//kendo.ui.Window
			//$.fn.getKendoMyWindow
			//$.fn.kendoMyWindow
			//$.kendoMyWindow
			({
			actions: [ "Pin", "Minimize", "Maximize", "Close" ],
			title: "Title",
			//title: false,
			//visible: false,
			width: 300,
			height: 300,
			activate: function() {
				if(window.console && console.log)
					console.log("kendoWindow.activate(%o)", arguments);
			},
			close: function() {
				if(window.console && console.log)
					console.log("kendoWindow.close(%o)", arguments);
			},
			deactivate: function() {
				if(window.console && console.log)
					console.log("kendoWindow.deactivate(%o)", arguments);
			},
			dragend: function() {
				if(window.console && console.log)
					console.log("kendoWindow.dragend(%o)", arguments);
			},
			dragstart: function() {
				if(window.console && console.log)
					console.log("kendoWindow.dragstart(%o)", arguments);
			},
			error: function() {
				if(window.console && console.log)
					console.log("kendoWindow.error(%o)", arguments);
			},
			open: function() {
				if(window.console && console.log)
					console.log("kendoWindow.open(%o)", arguments);
			},
			refresh: function() {
				if(window.console && console.log)
					console.log("kendoWindow.refresh(%o)", arguments);
			},
			resize: function() {
				if(window.console && console.log)
					console.log("kendoWindow.resize(%o)", arguments);
			}
		}),
		btnOpen = $("#btnOpen").kendoButton({
			click: function() {
				if(window.console && console.log)
					console.log("kendoButton.click(%o)", arguments);

				kWindow.open();				
				var data = $("#testDiv")/*kWindow*/.data("kendoMyWindow");
				$("#testDiv")/*kWindow*/.data("kendoMyWindow").open();
			}
		}),
		btnClose = $("#btnClose").kendoButton({
			click: function() {
				kWindow/*.data("kendoMyWindow")*/.close();
			}
		}),
		btnContent = $("#btnContent").kendoButton({
			click: function() {
				var
					inpContent = $("#inpContent"),
					value;

				if(inpContent)
					value = inpContent.val();

				if(value)
					kWindow.data("kendoMyWindow").content(value);
				else
					inpContent.val(kWindow.data("kendoMyWindow").content());
			}
		}),
		btnTest = $("#btnTest").kendoButton({
			click: function() {
				var
					w = $.fn.getKendoMyWindow(),
					ws = $.fn.getKendoMyWindow.toString();

				if(ws)
					;
			}
		});
});
