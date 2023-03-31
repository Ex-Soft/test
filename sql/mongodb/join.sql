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
