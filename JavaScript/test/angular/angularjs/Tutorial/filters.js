angular.module("angularFilters", []).filter("checkmark", function() {
	return function(input) {
		return input === "Spade" || input === "Club" ? '\u2713' : '\u2718';
	};
});
