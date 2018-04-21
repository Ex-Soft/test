define(["dojo/_base/declare"], function(declare){
	return declare(null, {
		constructor: function(name, age, residence){
			this.name = name;
			this.age = age;
			this.residence = residence;
		},
		getName: function(){
			return this.name;
		},
		setName: function(name){
			this.name = name;
		}
	});
});

