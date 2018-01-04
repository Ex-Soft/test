var angularServices = angular.module("angularServices", ["ngResource"]);

angularServices.factory("Card", ["$resource", function($resource) {
	return $resource("data:cardId.json", {}, {
		query: {method:"GET", params:{cardId:""}, isArray:true}
	});
}]);