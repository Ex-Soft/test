TestNamespace.ClassI = new (function() {
	this.MethodI = function() {
		if(window.console && console.log)
			console.log("ClassI.MethodI(%o)", this);
	};

	this.MethodII = function() {
		if(window.console && console.log)
			console.log("ClassI.MethodII(%o)", this);
		
		this.MethodI();
	};
})();