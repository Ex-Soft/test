use testdb;

db.testdate.insertOne({ _id: 1 });
db.testdate.insertOne({ _id: 2, dateStr: null, dateISOStr: null, dateISODate: null });
db.testdate.insertOne({ _id: 3, dateStr: "2023-03-28T16:13:13.123+03:00", dateISOStr: "2023-03-28T13:13:13.123Z", dateISODate: ISODate("2023-03-28T13:13:13.123Z") });
db.testdate.insertOne({ _id: 4, dateStr: "2023-03-29T16:13:13.123+03:00", dateISOStr: "2023-03-29T13:13:13.123Z", dateISODate: ISODate("2023-03-29T13:13:13.123Z") });
db.testdate.insertOne({ _id: 5, dateStr: "2023-03-30T16:13:13.123+03:00", dateISOStr: "2023-03-30T13:13:13.123Z", dateISODate: ISODate("2023-03-30T13:13:13.123Z") });

db.testdate.updateOne({ _id: 3}, { $set: { dateStr: "2023-03-28T16:13:13.123+03:00", dateISOStr: "2023-03-28T13:13:13.123Z", dateISODate: ISODate("2023-03-28T13:13:13.123Z") } });
db.testdate.updateOne({ _id: 4}, { $set: { dateStr: "2023-03-29T16:13:13.123+03:00", dateISOStr: "2023-03-29T13:13:13.123Z", dateISODate: ISODate("2023-03-29T13:13:13.123Z") } });

db.testdate.find({ $expr: { $and: [ { $gte: [{ $toDate: '$dateStr' }, new ISODate('2023-03-28T13:13:13.123Z')] }, { $lt: [{ $toDate: '$dateStr' }, new ISODate('2023-03-30T13:13:13.123Z')] } ] } }).pretty(); // 3, 4
db.testdate.find({ $expr: { $and: [ { $gte: [{ $toDate: '$dateStr' }, new ISODate('2023-03-28T13:13:13.124Z')] }, { $lt: [{ $toDate: '$dateStr' }, new ISODate('2023-03-30T13:13:13.123Z')] } ] } }).pretty(); // 4
db.testdate.find({ dateStr: { $gte: new ISODate('2023-03-28T13:13:13.123Z'), $lt: new ISODate('2023-03-30T13:13:13.123Z') } }).pretty(); // empty
db.testdate.find({ dateStr: { $gte: ISODate('2023-03-28T13:13:13.123Z'), $lt: ISODate('2023-03-30T13:13:13.123Z') } }).pretty(); // empty
db.testdate.find({ dateStr: { $gte: '2023-03-28T13:13:13.123Z', $lt: '2023-03-30T13:13:13.123Z' } }).pretty(); // 3, 4

db.testdate.find({ $expr: { $and: [ { $gte: [{ $toDate: '$dateISOStr' }, new ISODate('2023-03-28T13:13:13.123Z')] }, { $lt: [{ $toDate: '$dateISOStr' }, new ISODate('2023-03-30T13:13:13.123Z')] } ] } }).pretty();

db.testdate.find({ dateISODate: { $gte: new ISODate('2023-03-28T13:13:13.123Z'), $lt: new ISODate('2023-03-30T13:13:13.123Z') } }).pretty();

$match
{
  createdOn: { $gt: ISODate("2023-01-01")}
}