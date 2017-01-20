Selectize.define("open_up", function () {
	var self = this;

	this.setup = (function () {
		var original = self.setup;

		self.openDown = true;

		return function () {
			original.apply(this, arguments);
			
			this.on("dropdown_open", function (dropdown) {
				var
					wrapper,
					control,
					dropdownContent,
					wrapperOffsetTop,
					dropdownContentMaxHeightStr,
					dropdownContentMaxHeight;

				if (!dropdown
					|| !(wrapper = this.$wrapper)
					|| !(control = this.$control)
					|| !(dropdownContent = this.$dropdown_content)
					|| !(dropdownContentMaxHeightStr = dropdownContent.css("max-height"))
					|| isNaN(dropdownContentMaxHeight = parseInt(dropdownContentMaxHeightStr.replace(/[^\d]/, ""), 10)))
					return;

				if (!self.dropdownContentMaxHeightOriginal)
					self.dropdownContentMaxHeightOriginal = dropdownContentMaxHeight;
				
				if (!self.dropdownBorderTopStyleOriginal)
					self.dropdownBorderTopStyleOriginal = dropdown.css("border-top-style");

				if (!self.dropdownBorderBottomStyleOriginal)
					self.dropdownBorderBottomStyleOriginal = dropdown.css("border-bottom-style");
				
				if (!self.dropdownBorderBottomWidthOriginal)
					self.dropdownBorderBottomWidthOriginal = dropdown.css("border-bottom-width");
				
				if (!self.dropdownBorderRadiusOriginal)
					self.dropdownBorderRadiusOriginal = dropdown.css("border-bottom-left-radius");

				var
					heightBelow = jQuery(window).height() - ((wrapperOffsetTop = Math.floor(wrapper.offset().top)) - window.pageYOffset) - wrapper.height(),
					dropdownPositionTop = dropdown.position().top,
					controlOuterHeight = control.outerHeight();
				
				if (self.openDown = heightBelow >= self.dropdownContentMaxHeightOriginal) {
					var style = {};
					
					if (dropdownPositionTop !== controlOuterHeight)
						style["top"] = controlOuterHeight + "px";
					
					if (dropdownContentMaxHeight !== self.dropdownContentMaxHeightOriginal)
						style["max-height"] = self.dropdownContentMaxHeightOriginal + "px";

					if (dropdown.css("border-top-style") !== self.dropdownBorderTopStyleOriginal)
						style["border-top-style"] = self.dropdownBorderTopStyleOriginal;

					if (dropdown.css("border-bottom-style") !== self.dropdownBorderBottomStyleOriginal)
						style["border-bottom-style"] = self.dropdownBorderBottomStyleOriginal;

					if (dropdown.css("border-top-width") !== "0px")
						style["border-top-width"] = "0";

					if (dropdown.css("border-bottom-width") !== self.dropdownBorderBottomWidthOriginal)
						style["border-bottom-width"] = self.dropdownBorderBottomWidthOriginal;

					if (dropdown.css("border-top-left-radius") !== "0px")
						style["border-top-left-radius"] = "0";
					
					if (dropdown.css("border-top-right-radius") !== "0px")
						style["border-top-right-radius"] = "0";
					
					if (dropdown.css("border-bottom-left-radius") !== self.dropdownBorderRadiusOriginal)
						style["border-bottom-left-radius"] = self.dropdownBorderRadiusOriginal;
					
					if (dropdown.css("border-bottom-right-radius") !== self.dropdownBorderRadiusOriginal)
						style["border-bottom-right-radius"] = self.dropdownBorderRadiusOriginal;

					dropdown.css(style);

					return;
				}
				
				if (dropdownContentMaxHeight > wrapperOffsetTop) {
					dropdownContentMaxHeight = wrapperOffsetTop;
					dropdownContent.css({ "max-height": dropdownContentMaxHeight + "px" });
				}

				dropdown.css({ "top": -dropdownContentMaxHeight + "px", "border-top-style": self.dropdownBorderBottomStyleOriginal, "border-bottom-style": "none", "border-top-width": self.dropdownBorderBottomWidthOriginal, "border-bottom-width": "0", "border-top-left-radius": self.dropdownBorderRadiusOriginal, "border-top-right-radius": self.dropdownBorderRadiusOriginal, "border-bottom-left-radius": "0", "border-bottom-right-radius": "0", "border-top-color": dropdown.css("border-bottom-color") });
			});
		};
	})();

	this.positionDropdown = (function () {
		var original = self.positionDropdown;

		return function () {
			if (this.isOpen && !this.openDown)
				return undefined;

			return original.apply(this, arguments);
		};
	})();
});
