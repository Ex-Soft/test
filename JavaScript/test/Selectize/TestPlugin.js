Selectize.define("test_plugin", function(options) {
	var self = this;
	
	this.setup = (function() {
		var original = self.setup;
		
		return function() {
			original.apply(this, arguments);
			
			this.on("dropdown_open", function(dropdown) {
				if (window.console && console.log)
					console.log("dropdown_open %o", dropdown);
				
				var
					wrapper,
					wrapperPosition,
					wrapperOffset,
					wrapperHeight,
					dropdownContent,
					maxHeightStr,
					maxHeight,
					heightAbove,
					heightBelow,
					space,
					newTop,
					dropdownOffset,
					dropdownPositionTop,
					control,
					controlHeight;

				if (!dropdown
					|| !(wrapper = this.$wrapper)
					|| !(dropdownContent = this.$dropdown_content)
					|| !(control = this.$control)
					|| !(maxHeightStr = dropdownContent.css("max-height"))
					|| isNaN(maxHeight = parseInt(maxHeightStr.replace(/[^\d]/, ""), 10)))
					return;
					
				wrapperPosition = wrapper.position();
				wrapperOffset = Math.floor(wrapper.offset().top);
				wrapperHeight = wrapper.height();
				heightAbove = wrapperOffset;
				heightBelow = jQuery(window).height() - wrapperOffset - wrapperHeight;
				space = Math.max(heightAbove, heightBelow);
				dropdownOffset = Math.floor(dropdown.offset().top);
				dropdownPositionTop = dropdown.position().top;
				controlHeight = control.height();
				controlInnerHeight = control.innerHeight();
				controlOuterHeight = control.outerHeight();
				controlPadding = control.css("padding");

				if (window.console && console.log)
				{
					console.log("wrapper: %o", wrapper);
					console.log("dropdownContent: %o", dropdownContent);
					console.log("wrapperOffset: %o", wrapperOffset);
					console.log("wrapperHeight: %o", wrapperHeight);
					console.log("heightAbove: %o", heightAbove);
					console.log("heightBelow: %o", heightBelow);
					console.log("maxHeight: %i", maxHeight);
					console.log("jQuery(window).height(): %i", jQuery(window).height());
					console.log("space: %i", space);
					console.log("newTop: %i", newTop);
					console.log("dropdownOffset: %i", dropdownOffset);
					console.log("dropdownPositionTop: %i", dropdownPositionTop);
					console.log("controlHeight: %i", controlHeight);
					console.log("controlInnerHeight: %i", controlInnerHeight);
					console.log("controlOuterHeight: %i", controlOuterHeight);
				}

				if ((newTop = maxHeight > heightBelow ? -maxHeight : controlOuterHeight) !== dropdownPositionTop)
					dropdown.css({ "top": newTop + "px" });
			});
		};
	})();
});
