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
