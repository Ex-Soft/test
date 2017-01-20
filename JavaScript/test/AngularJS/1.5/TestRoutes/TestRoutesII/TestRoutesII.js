if(window.console && console.clear)
	console.clear();

if(window.console && console.log)
	console.log("%s", angular.version.full);

var
	demoApp = angular.module("demoApp", ["ngRoute"]);

demoApp.config(["$routeProvider", "$locationProvider", function($routeProvider, $locationProvider) {
	$routeProvider
		.when("/view1",
			{
				controller: "controllerView1",
				templateUrl: "View1.html"
			})
		.when("/view2",
			{
				controller: "controllerView2",
				templateUrl: "View2.html"
			})
		.when("/view3",
			{
				controller: "controllerView3",
				templateUrl: "View3.html"
			})
		.when("/view4",
			{
				controller: "controllerView4",
				templateUrl: "View4.html"
			})
		.otherwise({ redirectTo: "/view1" });

	//$locationProvider.html5Mode(true);
}]);

demoApp.controller("controllerView1", function($scope) {
	if(window.console && console.log)
		console.log("%o", arguments);
});

demoApp.controller("controllerView2", function($scope) {
	if(window.console && console.log)
		console.log("%o", arguments);
});

demoApp.controller("controllerView3", function($scope) {
	if(window.console && console.log)
		console.log("%o", arguments);
});

demoApp.controller("controllerView4", function($scope) {
	if(window.console && console.log)
		console.log("%o", arguments);
});
