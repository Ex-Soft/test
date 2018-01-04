var angularControllers = angular.module("angularControllers", []);

angularControllers.controller("angularListCtrl", [ "$scope", "Card", function ($scope, Card) {
	$scope.data = Card.query();

	$scope.orderProp = "field1";
}]);

angularControllers.controller("angularDetailCtrl", ["$scope", "$routeParams", "Card", function($scope, $routeParams, Card) {
	$scope.data = Card.get({cardId:$routeParams.id}, function(card){
		$scope.item = card;
	});
	
	$scope.onImageClick = function() {
		if(window.console && console.log)
			console.log("onImageClick(%o)", arguments);
	}
}]);