initCustomComponent: function() {
	this.getCustomCmp("TextBox1").addListener("focus", this.onTextBox1_Focus, this);
	this.getCustomCmp("Date1").addListener("focus", this.onDate1_Focus, this);
},

onTextBox1_Focus: function() {
	if(window.console && console.log)
		console.log("onTextBox1_Focus()");
},

onDate1_Focus: function() {
	if(window.console && console.log)
		console.log("onDate1_Focus()");
},

handlerSave: function() {
	if(window.console && console.log)
		console.log("handlerSave()");
}