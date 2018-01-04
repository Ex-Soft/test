// http://www.bennadel.com/blog/2853-ngshow-nghide-classes-get-applied-in-the-postdigest-phase-in-angularjs-1-3.htm
// http://blogs.microsoft.co.il/choroshin/2014/04/08/angularjs-postdigest-vs-timeout-when-dom-update-is-needed/

var app = angular.module("Demo", []);

app.controller(
	"AppController",
	function( $scope ) {
		// Define the controller as the view-model.
		var vm = this;
		// I determine if the container is visible.
		vm.isContainerVisible = true;
		// Expose the public API.
		vm.toggleContainer = toggleContainer;
		// ---
		// PUBLIC METHODS.
		// ---
		// I toggle the visibility of the container.
		function toggleContainer() {
			vm.isContainerVisible = ! vm.isContainerVisible;
		}
	}
);

app.directive(
	"bnContainer",
	function($timeout) {
		// Return the directive configuration object.
		// --
		// NOTE: Using priority 1 to make sure that this link function (post-link),
		// is executed after the ng-show link function (priority 0 - they are
		// linked in reverse order). That way, the ng-show $watch() bindings are
		// bound first, which means that our $watch() handler will execute after
		// the ng-show $watch() handler.
		return({
			link: link,
			priority: 1,
			restrict: "A"
		});
		// I bind the JavaScript events to the local view-model.
		function link( scope, element, attributes ) {
			// The calling context is passing in an expression that will determine
			// when the container changes its visibility. When it changes, we want
			// to inspect the dimensions of the element.
			scope.$watch( attributes.bnContainer, testContainerDimensions );
			// I log the dimensions of the element when the visibility changes.
			function testContainerDimensions( newValue ) {
				var height = element.height();
				var width = element.width();
				
				if (window.console && console.log)
				{
					console.log( newValue ? "Visible" : "Hidden" );
					console.log( "Dimensions:", width, "x", height );
				}
				
				$timeout(
					function asyncCheck() {
						var height = element.height();
						var width = element.width();
						
						if (window.console && console.log)
							console.log( "Async Dimensions:", width, "x", height );
					},
					0,
					false // Don't trigger a digest.
				);
			}
		}
	}
);
