$(document).ready(function () {
	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log)
	{
		console.log("jquery: %s", $.fn.jquery);
		console.log("kendo: %s", kendo.version);
	}

	//create dataSource
	var
		listA_DS = new kendo.data.DataSource({
			data: [
				{ id: 1, item: "Item 1" },
				{ id: 2, item: "Item 2" },
				{ id: 3, item: "Item 3" }
			],
			schema: {
				model: {
					id: "id",
					fields: {
						id: { type: "number" },
						item: { type: "string" }
					}
				}
			}
		}),
		listB_DS= new kendo.data.DataSource({
			data: [ /* still no data */ ],
			schema: {
				model: {
					id: "id",
					fields: {
						id: { type: "number" },
						item: { type: "string" }
					}
				}
			}
		});

    //display dataSource's data through ListView
    $("#listA").kendoListView({
        dataSource: listA_DS,
        template: "<div class='item'>ListA: #: item #</div>"
    });

    //create a draggable for the parent container
    $("#listA").kendoDraggable({
        filter: ".item", //specify which items will be draggable
        dragstart: function(e) {
            var draggedElement = e.currentTarget, //get the DOM element that is being dragged
                dataItem = listA_DS.getByUid(draggedElement.data("uid")); //get corresponding dataItem from the DataSource instance

		if (window.console && console.log)
			console.log(dataItem);
        },
        hint: function(element) { //create a UI hint, the `element` argument is the dragged item
            return element.clone().css({
                "opacity": 0.6,
                "background-color": "#0cf"
            });
        }
    });

	//$("#listB").kendoDropTarget();

    $("#listB").kendoListView({
        dataSource: listB_DS,
        template: "<div class='item'>ListB: #: item #</div>"
    });

    function addStyling(e) {
        this.element.css({
            "border-color": "#06c",
            "background-color": "#e0e0e0",
            "opacity": 0.6
        });
    }

    function resetStyling(e) {
        this.element.css({
            "border-color": "black",
            "background-color": "transparent",
            "opacity": 1
        });
    }

    //create dropTarget
    $("#listB").kendoDropTarget({
        dragenter: addStyling, //add visual indication
        dragleave: resetStyling, //remove the visual indication
        drop: function(e) { //apply changes to the data after an item is dropped
            var draggableElement = e.draggable.currentTarget,
            dataItem = listA_DS.getByUid(draggableElement.data("uid")); //find the corresponding dataItem by uid

            listA_DS.remove(dataItem); //remove the item from ListA
            listB_DS.add(dataItem); //add the item to ListB

            resetStyling.call(this); //reset visual dropTarget indication that was added on dragenter
        }
    });
});
