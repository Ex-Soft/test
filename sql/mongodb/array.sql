/* https://www.mongodb.com/docs/manual/tutorial/query-arrays/ */

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

db.testarray.updateMany({ $and: [ { items: { $exists: true } }, { items: { $ne: null } }, { $expr: { $eq: [{ $type: "$items" }, "array"]} }, { items: { $ne: [] } }, { $expr: { $ne: [{ $size: "$items" }, 0] } } ] }, { $push: { values: { $each: [ 13, 42 ] } } });
db.testarray.updateMany({ $and: [ { $expr: { $isArray: "$items" } }, { items: { $ne: [] } } ], $expr: { $eq: [ { $mod: [ "$_id", 2 ] }, 0 ] } }, { $push: { values: { $each: [ 1, 9, 25, 99 ] } } });
db.testarray.updateMany({ $and: [ { $expr: { $isArray: "$items" } }, { items: { $ne: [] } } ], $expr: { $eq: [ { $mod: [ "$_id", 2 ] }, 1 ] } }, { $push: { values: { $each: [ 2, 18, 50, 33 ] } } });

db.testarray.find({ $and: [ { items: { $exists: true } }, { items: { $ne: null } }, { items: { $eq: [] } }, { $expr: { $eq: [{ $size: "$items" }, 0] } } ] }).pretty();

db.testarray.find({ values: { $gt: 25 } }).pretty(); // 4, 5, 6, 7, 8, 9, 10
db.testarray.find({ values: { $gte: 99 } }).pretty(); // 4, 6, 8, 10

{ $expr: { $isArray: "$items" } }
{ $expr: { $eq: [{ $type: "$items" }, "array"] } }

{ items: "1st" } // 4, 6, 8, 10
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
