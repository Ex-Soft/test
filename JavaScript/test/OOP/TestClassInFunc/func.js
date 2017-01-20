function onLoad()
{
	(function(){
		if (window.console && console.log)
			console.log("this=%o", this)

		var
			global = this;

		if (typeof(TestClassInFunc) === "undefined") {
			global.TestClassInFunc = {};
			global.TestClassInFunc.global = global;

			global.TestClassInFunc.ClassI = new(function() {
				this.FooI = function() {
					if (window.console && console.log)
						console.log("TestClassInFunc.ClassI.FooI(%o)", arguments);
				};
			})();
			
			global.TestClassInFunc.ClassII = function(valI, valII) {
				this.propertyI = valI;
				this.propertyII = valII;
				
				this.FooI = function() {
					if (window.console && console.log)
						console.log("TestClassInFunc.ClassII.FooI(%o)", arguments);
				};
				
				this.ShowProperties = function() {
					if (window.console && console.log)
						console.log("TestClassInFunc.ClassII.ShowProperties(%o) {propertyI: %o, propertyII: %o}", arguments, this.propertyI, this.propertyII);
				};
			};
		}
		
		var
			o1 = new TestClassInFunc.ClassII(),
			o2 = new TestClassInFunc.ClassII("o2I"),
			o3 = new TestClassInFunc.ClassII("o3I", "o3II");

		TestClassInFunc.ClassI.FooI();
		
		o1.FooI();
		o1.ShowProperties();
		
		o2.FooI();
		o2.ShowProperties();

		o3.FooI();
		o3.ShowProperties();
	})();
}
