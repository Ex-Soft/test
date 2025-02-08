/* https://www.mongodb.com/docs/manual/tutorial/query-arrays/ */
/* https://www.singlestore.com/blog/ultimate-guide-to-mongodb-arrays/ */

$and: [{ categories: { $exists: true } }, { categories: { $ne: null } }, { categories: { $ne: [] } }, { categories: { $regex: /fiber/i } }]
{ $and: [{ groups: { $exists: true } }, { groups: { $ne: null } }, { groups: { $ne: [] } }, { $expr: { $gt: [{ $size: "$groups" }, 1] } } ] }

{ $and: [ { groups: { $exists: true } }, { groups: { $ne: null } }, { groups: { $ne: [] } }, { $not: { groups: { $size: 1 } } } ] }
{ $and: [ { groups: { $exists: true } }, { groups: { $ne: null } }, { groups: { $ne: [] } }, { 'groups.1': { $exists: true } } ] }
{ $and: [ { dealerTypes: { $exists: true } }, { dealerTypes: { $ne: null } }, { dealerTypes: { $ne: [] } } ] }

db.events.find({ sku: { $regex: /^lsp/i }, $or: [ { channels: { $exists: false } }, { channels: null }, { channels: [] } ] }).pretty();
db.events.updateMany({ _id: ObjectId("627cc36cc362dde1a71e076a") }, { $push: { channels: "lsp" } });
db.events.updateMany({ sku: { $regex: /^lsp/i }, $or: [ { channels: { $exists: false } }, { channels: null }, { channels: [] } ] }, { $push: { channels: "lsp" } });
db.events.updateOne({ _id: ObjectId('6422d984eefee624f7f669db') }, { $pull: { dealerTypes: { $in: [ 'preferred_dealer' ] } } });
db.dealers.updateOne({ _id: ObjectId("621be54f3f25ac2358b92e95") }, { $push: { associatedMasterDealers: { masterDealerId: "9999999999" } } });

{
  $or: [
    { sku: { $exists: false } },
    { sku: null },
    { $expr: { $ne: [{ $type: "$sku" }, "string"]} },
    { sku: "" }
  ]
}

use testdb;

db.testarray.insertOne({ _id: 1 });
db.testarray.insertOne({ _id: 2, items: null });
db.testarray.insertOne({ _id: 3, items: [] });
db.testarray.insertOne({ _id: 4, items: [ "1st" ] });
db.testarray.insertOne({ _id: 5, items: [ "2nd" ] });
db.testarray.insertOne({ _id: 6, items: [ "2nd", "1st" ] });
db.testarray.insertOne({ _id: 7, items: [ "3rd" ] });
db.testarray.insertOne({ _id: 8, items: [ "3rd", "1st" ] });
db.testarray.insertOne({ _id: 9, items: [ "3rd", "2nd" ] });
db.testarray.insertOne({ _id: 10, items: [ "3rd", "2nd", "1st" ] });
db.testarray.insertOne({ _id: 11, objects: null });
db.testarray.insertOne({ _id: 12, objects: [] });
db.testarray.insertOne({ _id: 13, objects: [{ price: "123.45" }] });
db.testarray.insertOne({ _id: 14, objects: [{ price: "$678.90" }] });
db.testarray.insertOne({ _id: 15, outerArray: null });
db.testarray.insertOne({ _id: 16, outerArray: [] });
db.testarray.insertOne({ _id: 17, outerArray: [{ innerArray: null }] });
db.testarray.insertOne({ _id: 18, outerArray: [{ innerArray: [] }] });
db.testarray.insertOne({ _id: 19, outerArray: [{ innerArray: [ 1, 2, 3, 4, 5 ] }] });
db.testarray.insertOne({ _id: 20, outerArray: [{ innerArray: [ 1, 2, 3, 4, 5 ] }, { innerArray: [ 10, 20, 30, 40, 50 ] }] });
db.testarray.insertOne({ _id: 21, dealer: null });
db.testarray.insertOne({ _id: 22, dealer: {} });
db.testarray.insertOne({ _id: 23, dealer: { associatedMasterDealers: null } });
db.testarray.insertOne({ _id: 24, dealer: { associatedMasterDealers: [] } });
db.testarray.insertOne({ _id: 25, dealer: { associatedMasterDealers: [ { masterDealerId: "2252" } ] } });
db.testarray.insertOne({ _id: 26, dealer: { associatedMasterDealers: [ { masterDealerId: "2252" }, { masterDealerId: "1234" } ] } });
db.testarray.insertOne({ _id: 27, dealer: { associatedMasterDealers: [ { masterDealerId: "1234" }, { masterDealerId: "5678" } ] } });
db.testarray.insertOne({ _id: 28, objects: [ { product: { sku: "1st" } }, { product: { sku: "2nd" } }, { product: { sku: "3rd" } } ] });
db.testarray.insertOne({ _id: 29, objects: [{ price: "123.45" }, { price: "678.90" }] });

db.testarray.find({ "objects.price": /123.45/i }).pretty();
db.testarray.find({ "objects.price": { $in: [ /123.45/i ] } }).pretty();
db.testarray.find({ "objects": { $elemMatch: { price: /123.45/i } } }).pretty();
db.testarray.find({ "objects": { $elemMatch: { price: { $in: [ /123.45/i ] } } } }).pretty();

db.testarray.find({ _id: 10 });
db.testarray.updateMany({ _id: 10 }, { $pull: { items: "2nd" } });
db.testarray.updateMany({ _id: 10 }, { $pull: { items: { $in: [ "1st", "3rd" ] } } });
db.testarray.updateMany({ _id: 10 }, { $push: { items: { $each: [ "3rd", "2nd", "1st" ] } } });

db.testarray.updateMany({ _id: 28 }, { $pull: { objects: { "product.sku": { $regex: "2Nd", $options: "i" } } } });
db.testarray.updateMany({ _id: 28 }, { $push: { objects: { product: { sku: "2nd" } } } });

db.testarray.updateMany({ $and: [ { items: { $exists: true } }, { items: { $ne: null } }, { $expr: { $eq: [{ $type: "$items" }, "array"]} }, { items: { $ne: [] } }, { $expr: { $ne: [{ $size: "$items" }, 0] } } ] }, { $push: { values: { $each: [ 13, 42 ] } } });
db.testarray.updateMany({ $and: [ { $expr: { $isArray: "$items" } }, { items: { $ne: [] } } ], $expr: { $eq: [ { $mod: [ "$_id", 2 ] }, 0 ] } }, { $push: { values: { $each: [ 1, 9, 25, 99 ] } } });
db.testarray.updateMany({ $and: [ { $expr: { $isArray: "$items" } }, { items: { $ne: [] } } ], $expr: { $eq: [ { $mod: [ "$_id", 2 ] }, 1 ] } }, { $push: { values: { $each: [ 2, 18, 50, 33 ] } } });

db.testarray.find({ $and: [ { items: { $exists: true } }, { items: { $ne: null } }, { items: { $eq: [] } }, { $expr: { $eq: [{ $size: "$items" }, 0] } } ] }).pretty();

db.testarray.find({ values: { $gt: 25 } }).pretty(); // 4, 5, 6, 7, 8, 9, 10
db.testarray.find({ values: { $gte: 99 } }).pretty(); // 4, 6, 8, 10

{ $expr: { $isArray: "$items" } }
{ $expr: { $eq: [{ $type: "$items" }, "array"] } }

{ items: "1st" } // 4, 6, 8, 10
{ items: /1sT/i } // 4, 6, 8, 10
{ items: [ "1st", "2nd" ] } // No result
{ items: [ "2nd", "1st" ] } // 6
{ items: { $all: [ "1st", "2nd" ] } } // 6, 10
{ items: { $in: [ "1st", "2nd" ] } } // 4, 5, 6, 8, 9, 10
{ items: { $in: [ /1sT/i, /2Nd/i ] } } // 4, 5, 6, 8, 9, 10

db.testarray.updateOne({ _id: 9 }, { $set: { tags: [ "1st", "2nd", "3rd" ] } });
db.testarray.updateOne({ _id: 10 }, { $set: { tags: [ "4th", "5th", "6th" ] } });

{ tags: { $regex: "Nd", $options: "i" } } // 9
{ tags: { $regex: "tH", $options: "i" } } // 10

db.testarray.updateMany({ "objects.price": { $regex: /[^\d.]/ } }, { $set: { "objects.$.price": "678.90" } });
db.testarray.updateMany({ "objects.price": { $regex: /[^\d.]/ } }, { $unset: { "options": "" } });
db.testarray.updateOne({ _id: 14 }, { $set: { objects: [{ price: "$678.90" }] } });
db.testarray.updateMany({ "objects.price": { $regex: /[^\d.]/ } }, { $set: { "objects.$.price": { $replaceAll: { input: "objects.$.price", find: { $literal: "$" }, replacement: "" } } } });

{
  $and: [
    { outerArray: { $exists: true } },
    { outerArray: { $ne: null } },
    { $expr: { $eq: [{ $type: "$outerArray" }, "array"]} },
    { $expr: { $isArray: "$outerArray"} },
    { outerArray: { $ne: [] } },
    { $expr: { $ne: [{ $size: "$outerArray" }, 0] } },
    { outerArray: { $elemMatch: { innerArray: { $exists: true } } } },
    { outerArray: { $elemMatch: { innerArray: { $ne: null } } } },
	//{ outerArray: { $elemMatch: { $eq: [{ $type: "$innerArray" }, "array"]} } },
	//{ outerArray: { $elemMatch: { $isArray: "$innerArray"} } },
    { outerArray: { $elemMatch: { innerArray: { $ne: [] } } } },
    { outerArray: { $elemMatch: { innerArray: 3 } } },
    { "outerArray.innerArray": { $elemMatch: { $eq: 3 } } }
  ]
}

db.testarray.findOneAndUpdate({ _id: 21 }, { $push: { items: "1st" } }, { upsert: true });
db.testarray.findOneAndUpdate({ _id: 21 }, { $push: { items: "2nd" } }, { upsert: true });
db.testarray.findOneAndUpdate({ _id: 21 }, { $push: { items: "3rd" } }, { upsert: true });

db.testarray.findOneAndUpdate({ _id: 21 }, { $pull: { items: "2nd" } }); [ "1st", "3rd" ]
db.testarray.findOneAndUpdate({ _id: 21 }, { $pull: { items: { $ne: "2nd" } } });

db.testarray.findOneAndUpdate({ _id: 21 }, { $unset: { "items.1": 1 } }); [ "1st", null, "3rd" ]

db.testarray.find({ _id: 21 }).pretty();
db.getSiblingDB("testdb").getCollection("testarray").find({ _id: 21 }).pretty();

db.getSiblingDB("testdb").getCollection("testarray").find({ items: { $elemMatch: { $regex: /1St/i } } }).pretty();
db.getSiblingDB("testdb").getCollection("testarray").find({ items: { $not: { $elemMatch: { $regex: /1St/i } } } }).pretty();
db.getSiblingDB("testdb").getCollection("testarray").find({
  $and: [
    { items: { $exists: true } },
    { items: { $ne: null } },
    { $expr: { $isArray: "$items" } },
    { $expr: { $eq: [{ $type: "$items" }, "array"] } },
    { items: { $ne: [] } },
    { $expr: { $gt: [{ $size: "$items" }, 1] } },
    { items: { $elemMatch: { $regex: /1St/i } } }
  ]
}).pretty();

$match
{
  $and: [
    { items: { $exists: true } },
    { items: { $ne: null } },
    { $expr: { $isArray: "$items" } },
    { $expr: { $eq: [{ $type: "$items" }, "array"] } },
    { items: { $ne: [] } },
    { $expr: { $gt: [{ $size: "$items" }, 2] } },
    { items: { $elemMatch: { $regex: /1St/i } } }
  ]
}

{ payments: { $elemMatch: { $gt: [ { $toDecimal: "$amount" }, 0 ] } } }

{
  $and: [
    { payments: { $exists: true } },
    { payments: { $ne: null } },
    { $expr: { $isArray: "$payments" } },
    { $expr: { $eq: [{ $type: "$payments" }, "array"] } },
    { payments: { $ne: [] } },
    { $expr: { $gt: [{ $size: "$payments" }, 2] } }
  ]
}

db.testarray.aggregate({ $match: { "objects.price": /678/i } }).pretty();
db.testarray.aggregate({ $match: { objects: { $elemMatch: { price: /678/i } } } }).pretty();
db.testarray.aggregate({ $match: { objects: { $not: { $elemMatch: { price: /678/i } } } } }).pretty();

db.testarray.insertOne({ _id: 99 });
db.testarray.find({ _id: 99 }).pretty();
db.testarray.updateMany({ _id: 99 }, { $push: { items: "1st" } }, { $upsert: true });
db.testarray.updateMany({ _id: 99 }, { $push: { items: "2nd" } }, { $upsert: true });
db.testarray.updateMany({ _id: 99 }, { $push: { items: "3rd" } }, { $upsert: true });
db.testarray.deleteMany({ _id: 99 });

db.testarray.aggregate([
{
	$project: {
		_id: 1,
		second: {
			$arrayElemAt: [ "$outerArray", 1 ]
		}
	}
}]).pretty();

db.testarray.aggregate([
{
	$project: {
		_id: 1,
		second: {
			$arrayElemAt: [ "$outerArray", 1 ]
		}
	}
}]).pretty();

db.testarray.aggregate([
{
	$match: {
		_id: 20
	}
},
{
	$project: {
		_id: 1,
		second: {
			$arrayElemAt: [ "$outerArray", 1 ]
		},
		secondFourth: {
			$arrayElemAt: [
				{ $arrayElemAt: [ "$outerArray.innerArray", 1 ] },
				3
			]
		}
	}
}]).pretty();

db.testarray.aggregate([
{
	$match: {
		"dealer.associatedMasterDealers": {
			$elemMatch: {
				masterDealerId: { $in: [ /2252/i ] }
			}
		}
	}
}
]).pretty();

db.testarray.aggregate([
{
	$match: {
		"dealer.associatedMasterDealers": {
			$not: {
				$elemMatch: {
					masterDealerId: { $in: [ /2252/i ] }
				}
			}
		}
	}
}
]).pretty();