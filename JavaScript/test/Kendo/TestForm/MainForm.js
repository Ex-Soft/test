$(document).ready(function () {
	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
	{
		console.log("jquery: %s", $.fn.jquery);
		console.log("kendo: %s", kendo.version);
	}

	var
		generateDataSource = function() {
			var options = [];

			for(var i = 1; i < 15; ++i)
				options.push({ id: i, title: i});

			return options;
		},
		kComboBox = $("#comboBox").kendoComboBox({
			dataTextField: "title",
			dataValueField: "id",
			dataSource: generateDataSource()
		}),
		kDropDownList = $("#dropDownList").kendoDropDownList({
			dataTextField: "title",
			dataValueField: "id",
			dataSource: generateDataSource()
		}),
		btnSubmit = $("#btnSubmit").kendoButton({
			click: function() {
				var
					htmlSelect = document.getElementById("htmlSelect"),
					htmlSelectText = htmlSelect.options[htmlSelect.selectedIndex].text,
					formDataWrong = $("#testForm").serialize() + {htmlSelectText: htmlSelectText},
					formData = $("#testForm").serialize() + "&" + $.param({htmlSelectText: htmlSelectText});

				if(window.console && console.log)
					console.log("$(\"#testForm\").serialize() = %o", formData);
			}
		});
});
