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

db.events.aggregate([{ $project: { _id: 0, categories: 1 } }]).pretty();
db.events.aggregate([{ $project: { _id: 0, categories: 1 } }, { $unwind: { path: '$categories' } }]).pretty();
db.events.aggregate([{ $project: { _id: 0, categories: 1 } }, { $unwind: { path: '$categories' } }, { $group: { _id: '$categories' } }]).pretty();
db.events.aggregate([{ $project: { _id: 0, categories: 1 } }, { $unwind: { path: '$categories' } }, { $group: { _id: '$categories' } }, { $sort: { _id: 1 } }]).pretty();

{ agent: { $exists: 0 | false }}
{ agent: { $exists: 1 | true }}

{$or: [{ title: { $regex: 'atlanta', $options: 'i' } }, { description: { $regex: 'atlanta', $options: 'i' } }]}
{$and: [{ title: { $regex: 'atlanta', $options: 'i' } }, { endDate: { $gte: ISODate(2023, 2, 22) } }, { categories: { $regex: 'Home and Garden', $options: 'i' } } ]}
{$and: [{ title: { $regex: 'atlanta', $options: 'i' } }, { categories: { $regex: 'Home and Garden', $options: 'i' } } ]}

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
