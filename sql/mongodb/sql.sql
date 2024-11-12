/* https://www.mongodb.com/docs/manual/meta/aggregation-quick-reference/#std-label-aggregation-expressions */
/* https://www.mongodb.com/community/forums/t/equivalent-of-select-distinct-on-in-mongodb/103810/7 */

db.version();

db.getSiblingDB("testdb").getCollection("testarray").find({ _id: 1 }).pretty();

$match
{$and: [{ dealerTypes: { $ne: null } }, { dealerTypes: { $ne: [] } } ] }
{$and: [{ dealerTypes: { $exists: true } }, { dealerTypes: { $ne: [] } } ] }
{
	$and: [
		{ dealerTypes: { $ne: null } },
		{ dealerTypes: { $ne: [] } }
	]
}

$unwind
{
	path: '$dealerTypes',
	preserveNullAndEmptyArrays: true
}

$sort
{
  _id: 1
}

$project
{
	_id: 1,
	email: 1,
	dealerTypes: 1
}

$group
{
  _id: "$emailLower",
  count: { $count: {} }
}

db.users.find({'dealerTypes': {'$ne': null}}).pretty();
db.users.find({ _id: ObjectId('63e64f6d0e73688d98914d34') }).pretty();
db.users.updateOne({ _id: ObjectId('63e64f6d0e73688d98914d34') }, { $unset: { dealerTypes: "" } });
db.users.updateOne({ _id: ObjectId('63e62037476f8dc47caf3237') }, { $set: { email: "anonymous@mailinator.com" } });
db.users.updateOne({ _id: ObjectId('62c8c768357093822c5833a7') }, { $set: { email: "theindustrious@mailinator.com" } });
db.events.updateOne({ _id: ObjectId('64104f4696e234ea4a0b5e47') }, { $unset: { history: "" } });
db.events.updateOne({ _id: ObjectId('6422d984eefee624f7f669db') }, { $set: { title: 'Test event 2023032803', description: 'Test event 2023032803', sku: '2023032803' } });
db.products.updateOne({ _id: ObjectId('64104f4696e234ea4a0b5e47') }, { $unset: { history: "" } });

db.getSiblingDB("microservice").getCollection("notifications").updateOne({ _id: ObjectId('64393b79ec52ed4fc1faed94') }, { $set: { user: "pvmarketing@perfect-vision.com" } });

db.events.aggregate([{ $project: { _id: 0, categories: 1 } }]).pretty();
db.events.aggregate([{ $project: { _id: 0, categories: 1 } }, { $unwind: { path: '$categories' } }]).pretty();
db.events.aggregate([{ $project: { _id: 0, categories: 1 } }, { $unwind: { path: '$categories' } }, { $group: { _id: '$categories' } }]).pretty();
db.events.aggregate([{ $project: { _id: 0, categories: 1 } }, { $unwind: { path: '$categories' } }, { $group: { _id: '$categories' } }, { $sort: { _id: 1 } }]).pretty();
db.events.aggregate([ { $match: { sku: { $regex: /^lsp/i }, $or: [ { channels: { $exists: false } }, { channels: null }, { channels: [] } ] } }, { $count: "count(*)" } ]).pretty();
db.events.aggregate([ { $match: { sku: { $regex: /^lsp/i }, $or: [ { channels: { $exists: false } }, { channels: null }, { channels: [] } ] } }, { $count: "count(*)" } ]).pretty();

db.notifications.aggregate([ { $match: { $expr: { $and: [ { $lt: [{ $toDate: '$createdOn' }, new ISODate('2023-03-22T16:14:43.000Z')] }, { $gte: [{ $toDate: '$createdOn' }, new ISODate('2023-03-22T16:14:42.000Z')] } ] } } }, { $count: "count(*)" } ]);
db.getSiblingDB("microservice").getCollection("notifications").aggregate([ { $match: { $expr: { $eq: [{ $type: "$user" }, "array"]} } }, { $count: "count()" } ]).pretty();
db.notifications.aggregate([ { $match: { $expr: { $eq: [{ $type: "$user" }, "array"]} } }, { $count: "count()" } ]).pretty();
db.getSiblingDB("microservice").getCollection("notifications").aggregate([ { $match: { $expr: { $isArray: "$user" } } }, { $count: "count()" } ]).pretty();
db.notifications.aggregate([ { $match: { $expr: { $isArray: "$user" } } }, { $count: "count()" } ]).pretty();

{ agent: { $exists: 0 | false }}
{ agent: { $exists: 1 | true }}

{$or: [{ title: { $regex: 'atlanta', $options: 'i' } }, { description: { $regex: 'atlanta', $options: 'i' } }]}
{$and: [{ title: { $regex: 'atlanta', $options: 'i' } }, { endDate: { $gte: ISODate(2023, 2, 22) } }, { categories: { $regex: 'Home and Garden', $options: 'i' } } ]}
{$and: [{ title: { $regex: 'atlanta', $options: 'i' } }, { categories: { $regex: 'Home and Garden', $options: 'i' } } ]}
{ $expr: { $lte: [{ $strLenBytes: "$state" }, 2 ]} }
$match
{
  masterDealerId: "9999999996"
}

$lookup
{
  from: "dealers",
  localField: "masterDealerId",
  foreignField: "associatedMasterDealers.masterDealerId",
  as: "dealers"
}

{ associatedMasterDealers: { masterDealerId: "2805" } }

{$and: [{ name: { $exists: true } }, { name: { $ne: null } }, { name: { $ne: "" } } ] }


$match
{ email: "pvmarketing@perfect-vision.com" }
$lookup
{
  from: "dealers",
  localField: "_id",
  foreignField: "userId",
  as: "dealers"
}
$unwind
{
  path: "$dealers",
  preserveNullAndEmptyArrays: false
}
$unwind
{
  path: "$dealers.associatedMasterDealers"
}
$lookup
{
  from: "masterdealers",
  localField: "dealers.associatedMasterDealers.masterDealerId",
  foreignField: "masterDealerId",
  as: "masterDealer"
}

db.getSiblingDB("microservice").getCollection("users").aggregate([
                {
                  $project: {"users": "$$ROOT", "_id": 0}
                },
                {
                  $lookup: {
                    localField: "users._id",
                    from: "dealers",
                    foreignField: "userId",
                    as: "dealers"
                  }
                },
                {
                  $unwind: {
                    path: "$dealers",
                    preserveNullAndEmptyArrays: false
                  }
                },
                {
                  $lookup: {
                    localField: "dealers.associatedMasterDealers.masterDealerId",
                    from: "masterdealers",
                    foreignField: "masterDealerId",
                    as: "masterdealers"
                  }
                },
                {
                  $unwind: {
                    path: "$masterdealers",
                    preserveNullAndEmptyArrays: false
                  }
                },
                {
                  $match: {"users.email": {$eq: 'pvmarketing@perfect-vision.com'}}
                },
                {
                  $project: {"masterDealerId": "$masterdealers.masterDealerId", "name": "$masterdealers.name", "_id": 0}
                }
              ])

$match
{
  $and: [
    { name: { $exists: true } },
    { name: { $ne: null } },
    { name: { $ne: "" } },
  ]
}
$lookup
{
  from: "dealers",
  localField: "masterDealerId",
  foreignField: "associatedMasterDealers.masterDealerId",
  as: "dealers"
}


$match
{
  $or:[
    {"items.product.title": {$regex: "1073", $options: "i"}},
    {"customer.user": {$regex: "1073", $options: "i"}},
    {"customer.billingAddress.firstName": {$regex: "1073", $options: "i"}},
    {"customer.billingAddress.lastName": {$regex: "1073", $options: "i"}},
    {"customer.shippingAddress.firstName": {$regex: "1073", $options: "i"}},
    {"customer.shippingAddress.lastName": {$regex: "1073", $options: "i"}},
    {"items.product.description": {$regex: "1073", $options: "i"}},
    {"items.product.sku": {$regex: "1073", $options: "i"}},
    {"items.messages.message": {$regex: "1073", $options: "i"}},
    {number: 1073}
  ],
  status: {$nin: [5,4]}
}
$lookup
{
  from: "users",
  localField: "customer.user",
  foreignField: "email",
  as: "customer.userInfo"
}
$unwind
{
  path: "$customer.userInfo",
  preserveNullAndEmptyArrays: true
}
$count
"_id"

$group
{
  _id: { "title": "$title" },
  count: { $sum: 1 }
}
$match
{
  count: { $gt: 1 } // $expr: { $gt: ["$count", 1] }
}
$project
{
  _id: 0,
  title: "$_id.title",
  count: "$count"
}

$match
{
  status:1,
  channels:{$regex:/lsp/i},
  $expr: {$eq: [{$type: "$categories"}, "array"]},
  $and: [{ categories: { $exists: true } }, { categories: { $ne: null } }, { categories: { $ne: [] } }, { categories: { $regex: /fiber/i } }]
}
$unwind
{
  path: "$categories",
}
$match
{
  categories: {$regex: /fiber/i}
}
$count
"count(/fiber/i)"

$match
{
  $or: [
    { email: { $regex: /amanda/i } }/*,
    { firstName: { $regex: /amanda/i } },
    { lastName: { $regex: /amanda/i } }*/
  ]
}
$lookup
{
  from: 'dealers',
  localField: '_id',
  foreignField: 'userId',
  as: 'dealer'
}
$unwind
{
  path: '$dealer'
}
$lookup
{
  from: 'masterdealers',
  localField: 'dealer.associatedMasterDealers.masterDealerId',
  foreignField: 'masterDealerId',
  as: 'dealer.associatedMasterDealers.masterDealer'
}

{
	$expr: {
		$and: [
			{$gte: [{$toDate: "$createdOn"}, new ISODate('2023-03-01')]},
			{$lte: [{$toDate: "$createdOn"}, new ISODate('2023-04-01')]}
		]
	}
}

use testdb;

db.testupdate.insertOne({ _id: 1, pString: "123.45" });
db.testupdate.insertOne({ _id: 2, pString: "$123.45" });
db.testupdate.aggregate([{ $match: { pString: { $regex: /^\$\d+/ } } }]).pretty();
db.testupdate.updateMany({ pString: { $regex: /^\$\d+/ } }, [ { $set: { pString: { $replaceAll: { input: "$pString", find: { $literal: "$" }, replacement: "" } } } } ], { multi: true });
db.getSiblingDB("testdb").getCollection("testupdate").insertMany([ { _id: 3, pString: "123.45" }, { _id: 4, pString: "$123.45" } ]);

db.events.aggregate([{$match:{price:{$regex:/,/}}},{$addFields:{literal:{$subtruct:[{$strLenBytes:"$price"},1]}}]).pretty();

db.getSiblingDB("thedirectvmarketingzone").getCollection("orders").aggregate([{$addFields:{"date":{$toDate:{$arrayElemAt:[{$split:['$createdOn','+']},0]}}}},{$unwind:{path:"$items"}},{$match:{"date":{$gte:ISODate('2023-01-01T00:00:00.000+00:00'),$gte:ISODate('2023-03-31T00:00:00.000+00:00')},"items.product.type":2,"payments.0.amount":{$exists:true},"items.product.selectedVariant":{$exists:false}}}]).pretty();

db.getSiblingDB("thedirectvmarketingzone").getCollection("notifications").getIndexes();
{ $expr: { $ne: [{ $type: "$user" }, "string"] } }

db.getSiblingDB("thedirectvmarketingzone").getCollection("notifications").insertMany([{subject:"Test 2023060501",message:"Test 2023060501",type:3,status:1,relation:"",createdBy:"pvmarketing@perfect-vision.com",createdOn:"2023-06-05T07:46:47.309Z",user:"6.1@test.com"},{subject:"Test 2023060502",message:"Test 2023060502",type:3,status:1,relation:"",createdBy:"pvmarketing@perfect-vision.com",createdOn:"2023-06-05T07:46:47.309Z",user:"6.1@test.com"}]);
db.getSiblingDB("thedirectvmarketingzone").getCollection("notifications").deleteMany({createdOn: /2023-06-05/i});

{$expr: {$gte: [{$toDate: "$createdOn"}, new ISODate('2023-06-15')]}}

db.getSiblingDB("testdb").getCollection("items").updateOne({ _id: 1 }, { $set: { sku: "111" } });
db.getSiblingDB("testdb").getCollection("items").updateOne({ _id: 2 }, { $set: { sku: "222" } });
db.getSiblingDB("testdb").getCollection("items").updateOne({ _id: 3 }, { $set: { sku: "333" } });
db.getSiblingDB("testdb").getCollection("items").aggregate([{$match:{sku:/^(?!222$)/}}]).pretty();

db.getSiblingDB("testdb").getCollection("items").aggregate([{$match:{orderId:1,$or:[{number:1},{number:3}]}}]).pretty();

// toArray()
db.getSiblingDB("testdb").getCollection("items").aggregate([ { $project: { _id: 0, sku: "$sku" } }, { $group: { _id: "", skus: { $push: "$sku" } } } ]).pretty();

// select distinct
db.getSiblingDB("testdb").getCollection("items").aggregate([ { $project: { _id: 0, orderId: "$orderId" } }, { $group: { _id: "$orderId" } } ]).pretty();

db.getSiblingDB("testdb").getCollection("masterdealers").insertMany([{_id: 1, masterDealerId: "1", name: "Master dealer #1"}, {_id: 2, masterDealerId: "2", name: "Master dealer #2"}, {_id: 3, masterDealerId: "3", name: "Master dealer #3"}]);
db.getSiblingDB("testdb").getCollection("users").insertMany([{_id: 1, name: "User #1", email: "user1@mailinator.com"}, {_id: 2, name: "User #2", email: "user2@mailinator.com"}, {_id: 3, name: "User #3", email: "user3@mailinator.com"}]);
db.getSiblingDB("testdb").getCollection("users").insertOne({_id: 4, name: "User #4", email: "user4@mailinator.com"});
db.getSiblingDB("testdb").getCollection("dealers").insertMany([{_id: 1, associatedMasterDealers: [ { masterDealerId: "1" } ], userId: [ 1 ]}, {_id: 2, associatedMasterDealers: [ { masterDealerId: "2" } ], userId: [ 2 ]}, {_id: 3, associatedMasterDealers: [ { masterDealerId: "3" } ], userId: [ 3 ]}]);
db.getSiblingDB("testdb").getCollection("dealers").updateOne({_id: 1}, {$push: {userId: 4}});
db.getSiblingDB("testdb").getCollection("imports").insertOne({_id: 1, users: [ "user1@mailinator.com", "UsEr4@MaIlInAtOr.CoM" ] });

users -> masterdealers
$lookup
{
  from: "dealers",
  localField: "_id",
  foreignField: "userId",
  as: "dealers"
}
$lookup
{
  from: "masterdealers",
  localField: "dealers.associatedMasterDealers.masterDealerId",
  foreignField: "masterDealerId",
  as: "dealers.associatedMasterDealers.masterDealer"
}

$lookup
{
  from: "dealers",
  localField: "_id",
  foreignField: "userId",
  as: "dealers"
}
$unwind
{
  path: "$dealers",
  preserveNullAndEmptyArrays: true
}
$lookup
{
  from: "masterdealers",
  localField: "dealers.associatedMasterDealers.masterDealerId",
  foreignField: "masterDealerId",
  as: "dealers.associatedMasterDealers.masterDealer"
}

masterdealers -> users
$lookup
{
  from: "dealers",
  localField: "masterDealerId",
  foreignField: "associatedMasterDealers.masterDealerId",
  as: "dealers"
}
$lookup
{
  from: "users",
  localField: "dealers.userId",
  foreignField: "_id",
  as: "dealers.users"
}

$lookup
{
  from: "dealers",
  localField: "masterDealerId",
  foreignField: "associatedMasterDealers.masterDealerId",
  as: "dealers"
}
$unwind
{
  path: "$dealers",
  preserveNullAndEmptyArrays: true
}
$lookup
{
  from: "users",
  localField: "dealers.userId",
  foreignField: "_id",
  as: "dealers.users"
}

db.getSiblingDB("thedirectvmarketingzone").getCollection("products").aggregate([{$match: {createdOn: {$gt: new ISODate("2023-01-01")}}}, {$unwind: {path: "$variants", preserveNullAndEmptyArrays: true}}, {$match: {$and: [{"variants.inDesignFile": {$exists: true}}, {"variants.inDesignFile": {$ne: null}}, {"variants.inDesignFile": {$ne: ""}}]}}, {$sort: {createdOn: 1}}, {$project: {_id: 0, createdOn: 1, inDesignFile: "$variants.inDesignFile"}}]).pretty();
db.getSiblingDB("thedirectvmarketingzone").getCollection("products").aggregate([{$match: { $expr: { $and: [ { type: 1 }, { vendor: 1 }, { status: 1 }, { $isArray: "$variants" }, { $gt: [ { $size: "$variants" }, 0 ] } ] } } }, {$unwind: { path: "$variants", preserveNullAndEmptyArrays: true }}, {$match: {$expr: {$and: [{ $isArray: "$variants.media" }, { $gt: [ { $size: "$variants.media" }, 0 ] }]}}}, {$project: {_id: 0, sku: 1, title: 1, url: {$arrayElemAt: ["$variants.media", 0]}}}, {$project: {title: 1, sku: 1, url: { $substrBytes: [ "$url", 0, { $indexOfBytes: [ "$url", "?" ] } ] } }}]);


$match
{
  $expr: {
    $and: [
      { $eq: [{ $type: "$items" }, "array"] },
      { $not: { $in: ["3rd", "$items"] } }
    ]
  }
}

$lookup
{
  from: "imports",
  localField: "email",
  foreignField: "users",
  as: "imports"
}
$match
{
  imports: []
}

db.getSiblingDB("testdb").getCollection("src").insertMany([ { _id: 1, value: "src #1" }, { _id: 2, value: "src #2" }, { _id: 3, value: "src #3" }, { _id: 4, value: "src #4" } ]);
db.getSiblingDB("testdb").getCollection("dest").insertMany([ { _id: 1, value: "dest #1" } ]);

db.getSiblingDB("testdb").getCollection("src").aggregate([ { $match: { _id: { $in: [ 2, 4 ] } } }, { $out: { db: "testdb", coll: "dest" } } ]);
db.getSiblingDB("testdb").getCollection("dest").find(); /* 2, 4 */

db.getSiblingDB("testdb").getCollection("src").aggregate([ { $match: { _id: { $in: [ 1, 2, 3 ] } } }, { $merge: { into: { db: "testdb", coll: "dest" }, on: "_id", whenMatched: "merge", whenNotMatched: "insert" } } ]);
db.getSiblingDB("testdb").getCollection("dest").find(); /* 1, 2, 3 */

$addFields
{
  _idStr: { $toString: "$_id" }
}

{
  "_id": {
    "$oid": "671b4440ccb3ae6a987b5554"
  }
}

{_id: {$oid: "609d0993906429612483cfb1"}, name: "Jane Doe"}