if(window.console && console.log)
{
	console.log("jQuery: %s", $.fn.jquery);
	console.log("AngularJS: %o", angular.version.full);
}

angular.module("heroApp", []).controller("mainCtrl", function() {
	this.hero = {
		name: "Spawn"
	};
});

