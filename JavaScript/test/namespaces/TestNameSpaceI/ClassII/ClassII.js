TestNamespace.ClassII=function(valI, valII) {
	this.propertyI=valI;
	this.propertyII=valII;
};

TestNamespace.ClassII.prototype={

	SmthConst: "SmthConst",

	MethodI: function() {
		if(window.console && console.log)
			console.log("ClassII.MethodI(): %s", this.propertyI);
	},

	MethodII: function() {
		if(window.console && console.log)
			console.log("ClassII.MethodII(): %s", this.propertyII);
	}
};