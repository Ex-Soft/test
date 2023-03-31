/* https://www.mongodb.com/docs/manual/meta/aggregation-quick-reference/#std-label-aggregation-expressions */

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

db.users.find({'dealerTypes': {'$ne': null}}).pretty();
db.users.find({ _id: ObjectId('63e64f6d0e73688d98914d34') }).pretty();
db.users.updateOne({ _id: ObjectId('63e64f6d0e73688d98914d34') }, { $unset: { dealerTypes: "" } });
db.users.updateOne({ _id: ObjectId('63e62037476f8dc47caf3237') }, { $set: { email: "anonymous@mailinator.com" } });
db.users.updateOne({ _id: ObjectId('62c8c768357093822c5833a7') }, { $set: { email: "theindustrious@mailinator.com" } });
db.events.updateOne({ _id: ObjectId('64104f4696e234ea4a0b5e47') }, { $unset: { history: "" } });
db.events.updateOne({ _id: ObjectId('6422d984eefee624f7f669db') }, { $set: { title: 'Test event 2023032803', description: 'Test event 2023032803', sku: '2023032803' } });
db.products.updateOne({ _id: ObjectId('64104f4696e234ea4a0b5e47') }, { $unset: { history: "" } });

db.events.aggregate([{ $project: { _id: 0, categories: 1 } }]).pretty();
db.events.aggregate([{ $project: { _id: 0, categories: 1 } }, { $unwind: { path: '$categories' } }]).pretty();
db.events.aggregate([{ $project: { _id: 0, categories: 1 } }, { $unwind: { path: '$categories' } }, { $group: { _id: '$categories' } }]).pretty();
db.events.aggregate([{ $project: { _id: 0, categories: 1 } }, { $unwind: { path: '$categories' } }, { $group: { _id: '$categories' } }, { $sort: { _id: 1 } }]).pretty();
db.events.aggregate([ { $match: { sku: { $regex: /^lsp/i }, $or: [ { channels: { $exists: false } }, { channels: null }, { channels: [] } ] } }, { $count: "count(*)" } ]).pretty();
db.events.aggregate([ { $match: { sku: { $regex: /^lsp/i }, $or: [ { channels: { $exists: false } }, { channels: null }, { channels: [] } ] } }, { $count: "count(*)" } ]).pretty();

db.notifications.aggregate([ { $match: { $expr: { $and: [ { $lt: [{ $toDate: '$createdOn' }, new ISODate('2023-03-22T16:14:43.000Z')] }, { $gte: [{ $toDate: '$createdOn' }, new ISODate('2023-03-22T16:14:42.000Z')] } ] } } }, { $count: "count(*)" } ]);

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