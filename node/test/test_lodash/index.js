const _ = require("lodash");

let arr1 = [ { pNumber: 1 }, { pNumber: 1 } ]
let arr2 = _.uniq(arr1);
console.log(arr2);
arr2 = _.uniqWith(arr1, _.isEqual);
console.log(arr2);

let o1 = { pNumber: 1, pArrayOfString: [ "1st", "2nd", "3rd" ] };
let o2 = { pNumber: 1, pArrayOfString: [ "1st", "2nd", "3rd" ] };
console.log(_.isEqual(o1, o2));
o2 = { pNumber: 2, pArrayOfString: [ "1st", "2nd", "3rd" ] };
console.log(_.isEqual(o1, o2));
o2 = { pNumber: 1, pArrayOfString: [ "3rd", "2nd", "1st" ] };
console.log(_.isEqualWith(o1, o2, (value, other, indexOrKey, parent, otherParent, stack) => {
	return value.pNumber === other.pNumber
		&& !_.xor(value.pArrayOfString, other.pArrayOfString).length;
}));
let arr = _.xor(o1.pArrayOfString, o2.pArrayOfString);
console.log(arr);

let obj = { cpp: [{ java: { python: 2012 } }] };

console.log(obj.cpp[0].java.python);

_.set(obj, "cpp[0].java.python", 2020);

console.log(obj.cpp[0].java.python);

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

const personByPrototype = new PersonByPrototype("PersonFirstNameByPrototype", "PersonLastNameByPrototype");
console.log("prototype.fullName = \"%s\" (typeof prototype.fullName = \"%s\")", personByPrototype.fullName(), typeof personByPrototype.fullName);
const personByPrototypeCloneByObjectCreate = Object.create(personByPrototype);
console.log("objectCreate.fullName = \"%s\" (typeof objectCreate.fullName = \"%s\")", personByPrototypeCloneByObjectCreate.fullName(), typeof personByPrototypeCloneByObjectCreate.fullName);
const personByPrototypeCloneByStructuredClone = structuredClone(personByPrototype);
console.log("typeof structuredClone.fullName = \"%s\"", typeof personByPrototypeCloneByStructuredClone.fullName); // undefined
const personByPrototypeCloneByClone = {...personByPrototype};
console.log("typeof clone.fullName = \"%s\"", typeof personByPrototypeCloneByClone.fullName);  // undefined
const personByPrototypeCloneByLodash = _.cloneDeep(personByPrototype);
console.log("_.cloneDeep.fullName = \"%s\" (typeof _.cloneDeep.fullName = \"%s\")", personByPrototypeCloneByLodash.fullName(), typeof personByPrototypeCloneByLodash.fullName);

const personByClass = new PersonByClass("PersonFirstNameByClass", "PersonLastNameByClass");
console.log("class.fullName = \"%s\" (typeof class.fullName = \"%s\")", personByClass.fullName, typeof personByClass.fullName);
const personByClassCloneByObjectCreate = Object.create(personByClass);
console.log("objectCreate.fullName = \"%s\" (typeof objectCreate.fullName = \"%s\")", personByClassCloneByObjectCreate.fullName, typeof personByClassCloneByObjectCreate.fullName);
const personByClassCloneByStructuredClone = structuredClone(personByClass);
console.log("typeof structuredClone.fullName = \"%s\"", typeof personByClassCloneByStructuredClone.fullName); // undefined
const personByClassCloneByClone = {...personByClass};
console.log("typeof clone.fullName = \"%s\"", typeof personByClassCloneByClone.fullName); // undefined
const personByClassCloneByLodash = _.cloneDeep(personByClass);
console.log("_.cloneDeep.fullName = \"%s\" (typeof _.cloneDeep.fullName = \"%s\")", personByClassCloneByLodash.fullName, typeof personByClassCloneByLodash.fullName);
