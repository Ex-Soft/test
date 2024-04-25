function PersonByPrototype(first, last) {
	this.firstName = first;
	this.lastName = last;
}

PersonByPrototype.prototype.fullName = function() {
	return `${this.firstName} ${this.lastName}`;
};

class PersonByClass {
	constructor(first, last) {
		this.firstName = first;
		this.lastName = last;
	}

	get fullName() {
		return `${this.firstName} ${this.lastName}`;
	}
};

function onLoad() {
	if (window.console && console.clear)
		console.clear();

	if (window.console && console.log) {
		const personByPrototype = new PersonByPrototype("PersonFirstNameByPrototype", "PersonLastNameByPrototype");
		console.log("prototype.fullName = \"%s\" (typeof prototype.fullName = \"%s\")", personByPrototype.fullName(), typeof personByPrototype.fullName);
		const personByPrototypeCloneByObjectCreate = Object.create(personByPrototype);
		console.log("objectCreate.fullName = \"%s\" (typeof objectCreate.fullName = \"%s\")", personByPrototypeCloneByObjectCreate.fullName(), typeof personByPrototypeCloneByObjectCreate.fullName);
		const personByPrototypeCloneByStructuredClone = structuredClone(personByPrototype);
		console.log("typeof structuredClone.fullName = \"%s\"", typeof personByPrototypeCloneByStructuredClone.fullName); // undefined
		const personByPrototypeCloneByClone = {...personByPrototype};
		console.log("typeof clone.fullName = \"%s\"", typeof personByPrototypeCloneByClone.fullName); // undefined
		
		const personByClass = new PersonByClass("PersonFirstNameByClass", "PersonLastNameByClass");
		console.log("class.fullName = \"%s\" (typeof class.fullName = \"%s\")", personByClass.fullName, typeof personByClass.fullName);
		const personByClassCloneByObjectCreate = Object.create(personByClass);
		console.log("objectCreate.fullName = \"%s\" (typeof objectCreate.fullName = \"%s\")", personByClassCloneByObjectCreate.fullName, typeof personByClassCloneByObjectCreate.fullName);
		const personByClassCloneByStructuredClone = structuredClone(personByClass);
		console.log("typeof structuredClone.fullName = \"%s\"", typeof personByClassCloneByStructuredClone.fullName); // undefined
		const personByClassCloneByClone = {...personByClass};
		console.log("typeof clone.fullName = \"%s\"", typeof personByClassCloneByClone.fullName); // undefined
	}
}
