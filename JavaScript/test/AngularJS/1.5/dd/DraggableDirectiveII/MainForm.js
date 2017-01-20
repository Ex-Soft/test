angular.module("testDragDivAkaWindow", [])

.directive("ngDraggable", function($document) {
	return {
		scope: {
			dragOptions: "=ngDraggable"
		},
		link: function(scope, elem, attr) {
			var container = document.querySelector(".container");

			elem.on("mousedown", function(e) {
				e.preventDefault();

				var
					containerBoundingClientRect = container.getBoundingClientRect(),
					shiftX = e.pageX - (Math.floor(containerBoundingClientRect.left) + pageXOffset),
					shiftY = e.pageY - (Math.floor(containerBoundingClientRect.top) + pageYOffset),
					moveAt = function(e) {
						container.style.top = e.pageY - shiftY + "px";
						container.style.left = e.pageX - shiftX + "px";
					},
					onMouseMove = function(e) {
						moveAt(e);
					},
					onMouseUp = function(e) {
						$document.unbind("mousemove", onMouseMove);
						elem.unbind("mouseup", onMouseUp);
					};

				moveAt(e);

				$document.on("mousemove", onMouseMove);
				elem.on("mouseup", onMouseUp);
			});
			
			elem.on("dragstart", function(e) {
				return false;
			});
		}
	}
})
.controller("dragController", function($scope) {
	if (window.console && console.log)
		console.log("AngularJS: %s", angular.version.full);
});

/*
.directive("ngDraggable", function ($document) {
    return {
        restrict: "A",
        scope: {
            dragOptions: "=ngDraggable"
        },
        link: function (scope, elem, attr) {
            var container = document.querySelector(".modalOverlay .modalContainer");

            elem.on("mousedown", function (e) {
                e.preventDefault();

                var
					containerBoundingClientRect = container.getBoundingClientRect(),
					shiftX = e.pageX - (Math.floor(containerBoundingClientRect.left) + pageXOffset),
					shiftY = e.pageY - (Math.floor(containerBoundingClientRect.top) + pageYOffset),
					moveAt = function (e) {
					    container.style.top = e.pageY - shiftY + "px";
					    container.style.left = e.pageX - shiftX + "px";
					},
					onMouseMove = function (e) {
					    moveAt(e);
					},
					onMouseUp = function (e) {
					    $document.unbind("mousemove", onMouseMove);
					    elem.unbind("mouseup", onMouseUp);
					};

                moveAt(e);

                $document.on("mousemove", onMouseMove);
                elem.on("mouseup", onMouseUp);
            });

            elem.on("dragstart", function (e) {
                return false;
            });
        }
    }
})
*/