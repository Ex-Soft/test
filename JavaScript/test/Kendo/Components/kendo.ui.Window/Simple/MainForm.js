$(document).ready(function () {
	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
	{
		console.log("jquery: %s", $.fn.jquery);
		console.log("kendo: %s", kendo.version);
	}

	var
		kWindow = $("#divWindow").kendoWindow({
			actions: [ "Pin", "Minimize", "Maximize", "Close" ],
			title: "Title",
			//title: false,
			visible: false,
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

				kWindow.data("kendoWindow").open();
			}
		}),
		btnClose = $("#btnClose").kendoButton({
			click: function() {
				kWindow.data("kendoWindow").close();
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
					kWindow.data("kendoWindow").content(value);
				else
					inpContent.val(kWindow.data("kendoWindow").content());
			}
		});
});
