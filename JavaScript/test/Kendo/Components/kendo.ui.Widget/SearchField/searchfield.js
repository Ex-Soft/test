// https://gist.github.com/joeriks/4754079
// http://blogs.telerik.com/kendoui/posts/12-10-16/inheriting_from_custom_widgets
// http://jsbin.com/OfIHOm/1/edit?html,js,output
// http://jsfiddle.net/lhoeppner/qj2HL/
// http://jsfiddle.net/cn172/s7RF3/
// http://blogs.telerik.com/kendoui/posts/12-04-03/creating_custom_kendo_ui_plugins
(function($) {
	var
		kendo = window.kendo,
		ui = kendo.ui,
		Widget = ui.Widget,
		CLICK = "click",
		CHANGE = "change",
		BUTTONCLICK = "buttonclick",
		BLUR = "blur",
		ns = ".searchField";

	var SearchField = Widget.extend({
		init: function (element, options) {
			var that = this;

			options = options || that.options;

			Widget.fn.init.call(this, element, options);
			
			element = that.element.on(BLUR + ns, $.proxy(that._blur, that));
			that._create();

			if (options.value) {
				that.value(options.value);
			}
		},

		options: {
			name: "SearchField",
			value: null,
			iconclass: "k-i-search",
			width: 150
		},

		set: function (value) {
			var that = this;
			if (that._old != value) {
				that._update(value);
				that._old = value;
				that.trigger(CHANGE);
			}
		},

		value: function(value) {
			var that = this;

			if (value === undefined) {
				return that._value;
			}
			that._update(value);
			that._old = that._value;
		},

		events: [CHANGE, BUTTONCLICK],

		_create: function () {
			var that = this;

			var template = kendo.template(that._templates.icon);
			that.icon = $(template(that.options));
			template = kendo.template(that._templates.textbox);
			that.textbox = $(template(that.options));

			that.icon.on(CLICK, $.proxy(that._buttonclick, that));

			that.element.attr("name", that.options.name);
			that.element.attr("data-role", "searchfield");
			that.element.addClass("k-input");
			that.element.css("width", "100%");
			that.element.wrap(that.textbox);

			that.element.after(that.icon);
		},

		_buttonclick: function (element) {
			var that = this;
			that.trigger(BUTTONCLICK, { element: element });
			return that;
		},

		_templates: {
			textbox: "<span style='width: #: width #px;' class='k-widget k-datepicker k-header tb'><span class='k-picker-wrap k-state-default'></span></span>",
			icon: "<span unselectable='on' class='k-select' role='button'><span unselectable='on' class='k-icon #: iconclass #'>...</span></span>"
		},

		_blur: function () {
			var that = this;
			that._change(that.element.val());
		},

		_update: function (value) {
			var that = this;
			that._value = value;
			that.element.val(value);
		},

		_change: function (value) {
			var that = this;
			if (that._old != value) {
				that._update(value);
				that._old = value;
				that.trigger(CHANGE);
			}
		}
	});

	ui.plugin(SearchField);
})(jQuery);