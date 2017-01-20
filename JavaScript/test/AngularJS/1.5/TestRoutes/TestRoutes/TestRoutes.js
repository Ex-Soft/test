if(window.console && console.clear)
	console.clear();

if(window.console && console.log)
	console.log("%s", angular.version.full);

var
	demoApp = angular.module("demoApp", ["ngRoute"]);

demoApp.config(["$routeProvider", function($routeProvider) {
	$routeProvider
		.when("/view1",
			{
				controller: "SimpleController",
				templateUrl: "View1.html"
			})
		.when("/view2",
			{
				controller: "SimpleController",
				templateUrl: "View2.html"
			})
		.otherwise({ redirectTo: "/view1" });
}]);

demoApp.controller("SimpleController", function($scope) {
	if(window.console && console.log)
		console.log("%o", arguments);

	$scope.namesObj = [
		{ id: '3rd', value: '3rd' },
		{ id: '2nd', value: '2nd' },
		{ id: '1st', value: '1st' }
	];

	$scope.addNewObj = function() {
		$scope.namesObj.push({
			id: $scope.newObj.id,
			value: $scope.newObj.value
		});
	};
});
