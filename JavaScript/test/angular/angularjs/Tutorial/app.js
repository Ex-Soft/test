var angularApp = angular.module("angularApp", [
	"ngRoute",
	"angularControllers",
	"angularFilters",
	"angularServices"
]);

angularApp.config(["$routeProvider",
	function($routeProvider) {
		$routeProvider.
			when("/cards", {
				templateUrl: "partials/card-list.html",
				controller: "angularListCtrl"
			}).
			when("/cards/:id", {
				templateUrl: "partials/card-detail.html",
				controller: "angularDetailCtrl"
			}).
			otherwise({
				redirectTo: "/cards"
			});
	}
]);
