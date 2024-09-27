use testdb;

db.orders.insertOne({ _id: 1, number: 1 });
db.orders.insertOne({ _id: 2, number: 2 });

db.items.insertOne({ _id: 1, orderId: 1, number: 1 });
db.items.insertOne({ _id: 2, orderId: 1, number: 2 });
db.items.insertOne({ _id: 3, orderId: 1, number: 3 });

// join
db.orders.aggregate([ { $lookup: { from: "items", localField: "_id", foreignField: "orderId", as: "items" } }, { $unwind: { path: "$items" } } ]).pretty();
[
  { _id: 1, number: 1, items: { _id: 1, orderId: 1, number: 1 } },
  { _id: 1, number: 1, items: { _id: 2, orderId: 1, number: 2 } },
  { _id: 1, number: 1, items: { _id: 3, orderId: 1, number: 3 } }
]

// left join
db.orders.aggregate([ { $lookup: { from: "items", localField: "_id", foreignField: "orderId", as: "items" } }, { $unwind: { path: "$items", preserveNullAndEmptyArrays: true } } ]).pretty();
[
  { _id: 1, number: 1, items: { _id: 1, orderId: 1, number: 1 } },
  { _id: 1, number: 1, items: { _id: 2, orderId: 1, number: 2 } },
  { _id: 1, number: 1, items: { _id: 3, orderId: 1, number: 3 } },
  { _id: 2, number: 2 }
]

db.dealers.insertOne({ _id: 1, associatedMasterDealers: [ { masterDealerId: 1 } ] });
db.dealers.insertOne({ _id: 2, associatedMasterDealers: [ { masterDealerId: 1 }, { masterDealerId: 2 } ] });
db.masterdealers.insertOne({ _id: 1, masterDealerId: 1, name: "1" });
db.masterdealers.insertOne({ _id: 2, masterDealerId: 2, name: "2" });
db.masterdealers.insertOne({ _id: 3, masterDealerId: 3, name: "3" });
db.dealers.aggregate([ { $lookup: { from: "masterdealers", localField: "associatedMasterDealers.masterDealerId", foreignField: "masterDealerId", as: "associatedMasterDealers.masterDealer" } } ]).pretty();
[
  { _id: 1, associatedMasterDealers: [
                                       { masterDealerId: 1, masterDealer: [ { _id: 1, masterDealerId: 1, name: '1' } ] }
                                     ]
  },
  { _id: 2, associatedMasterDealers: [
                                       { masterDealerId: 1, masterDealer: [ { _id: 1, masterDealerId: 1, name: '1' }, { _id: 2, masterDealerId: 2, name: '2' } ] },
                                       { masterDealerId: 2, masterDealer: [ { _id: 1, masterDealerId: 1, name: '1' }, { _id: 2, masterDealerId: 2, name: '2' } ] }
                                     ]
  }
]

db.dealers.aggregate([ { $lookup: { from: "masterdealers", localField: "associatedMasterDealers.masterDealerId", foreignField: "masterDealerId", as: "masterDealer" } } ]).pretty();
[
  { _id: 1, associatedMasterDealers: [ { masterDealerId: 1 } ], masterDealer: [ { _id: 1, masterDealerId: 1, name: '1' } ] },
  { _id: 2, associatedMasterDealers: [ { masterDealerId: 1 }, { masterDealerId: 2 } ], masterDealer: [ { _id: 1, masterDealerId: 1, name: '1' }, { _id: 2, masterDealerId: 2, name: '2' } ] }
]

db.master.insertOne({ _id: 1, details: [ 1, 3 ] });
db.master.insertOne({ _id: 2, details: [ 2, 4 ] });
db.details.insertOne({ _id: 1, name: "1" });
db.details.insertOne({ _id: 2, name: "2" });
db.details.insertOne({ _id: 3, name: "3" });
db.details.insertOne({ _id: 4, name: "4" });
db.details.insertOne({ _id: 5, name: "5" });
db.master.aggregate([ { $lookup: { from: "details", localField: "details", foreignField: "_id", as: "details" } } ]).pretty();
[
  { _id: 1, details: [ { _id: 1, name: '1' }, { _id: 3, name: '3' } ] },
  { _id: 2, details: [ { _id: 2, name: '2' }, { _id: 4, name: '4' } ] }
]