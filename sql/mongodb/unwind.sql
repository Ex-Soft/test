use testdb;

db.testunwind.insertOne({ _id: 1 });
db.testunwind.insertOne({ _id: 2, order: null });
db.testunwind.insertOne({ _id: 3, order: { number: 1, items: null } });
db.testunwind.insertOne({ _id: 4, order: { number: 2, items: [] } });
db.testunwind.insertOne({ _id: 5, order: { number: 3, items: [ { name: "3.1" } ] } });
db.testunwind.insertOne({ _id: 6, order: { number: 4, items: [ { name: "4.1" }, { name: "4.2" } ] } });
db.testunwind.insertOne({ _id: 7, order: { number: 5, items: [ { name: "5.1" }, { name: "5.2" }, { name: "5.3" } ] } });

db.testunwind.aggregate([ { $unwind: { path: "$order.items", includeArrayIndex: "order.items.idx", preserveNullAndEmptyArrays: true }} ]).pretty();
[
  { _id: 1, order: { items: { idx: null } } },
  { _id: 2, order: { items: { idx: null } } },
  { _id: 3, order: { number: 1, items: { idx: null } } },
  { _id: 4, order: { number: 2, items: { idx: null } } },
  {
    _id: 5,
    order: { number: 3, items: { name: '3.1', idx: Long("0") } }
  },
  {
    _id: 6,
    order: { number: 4, items: { name: '4.1', idx: Long("0") } }
  },
  {
    _id: 6,
    order: { number: 4, items: { name: '4.2', idx: Long("1") } }
  },
  {
    _id: 7,
    order: { number: 5, items: { name: '5.1', idx: Long("0") } }
  },
  {
    _id: 7,
    order: { number: 5, items: { name: '5.2', idx: Long("1") } }
  },
  {
    _id: 7,
    order: { number: 5, items: { name: '5.3', idx: Long("2") } }
  }
]

db.testunwind.aggregate([ { $unwind: { path: "$order.items", includeArrayIndex: "order.items.idx" }} ]).pretty();
[
  {
    _id: 5,
    order: { number: 3, items: { name: '3.1', idx: Long("0") } }
  },
  {
    _id: 6,
    order: { number: 4, items: { name: '4.1', idx: Long("0") } }
  },
  {
    _id: 6,
    order: { number: 4, items: { name: '4.2', idx: Long("1") } }
  },
  {
    _id: 7,
    order: { number: 5, items: { name: '5.1', idx: Long("0") } }
  },
  {
    _id: 7,
    order: { number: 5, items: { name: '5.2', idx: Long("1") } }
  },
  {
    _id: 7,
    order: { number: 5, items: { name: '5.3', idx: Long("2") } }
  }
]
