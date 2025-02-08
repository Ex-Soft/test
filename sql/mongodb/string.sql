db.teststring.insertOne({ _id: 1, str: "https://account.blob.core.windows.net/container/blob.png?sv=2020-08-04&ss=bfqt&srt=sco&sp=rwdlacupitfx&se=2025-02-02T15:30:33Z&st=2022-02-02T07:30:33Z&spr=https&sig=a3b%2BJkitsaUUGzm1fONLJJRw6GDntKcERFz0l5E7IyA%3D" });
db.teststring.insertOne({ _id: 2, str: "https://account.blob.core.windows.net/container/blob.jpg?sv=2020-08-04&ss=bfqt&srt=sco&sp=rwdlacupitfx&se=2025-02-02T15:30:33Z&st=2022-02-02T07:30:33Z&spr=https&sig=a3b%2BJkitsaUUGzm1fONLJJRw6GDntKcERFz0l5E7IyA%3D" });
db.teststring.insertOne({ _id: 3, str: "https://account.blob.core.windows.net/container/blob.pdf?sv=2020-08-04&ss=bfqt&srt=sco&sp=rwdlacupitfx&se=2025-02-02T15:30:33Z&st=2022-02-02T07:30:33Z&spr=https&sig=a3b%2BJkitsaUUGzm1fONLJJRw6GDntKcERFz0l5E7IyA%3D" });

db.teststring.updateOne({ _id: 1 }, { $set: { str: "https://account.blob.core.windows.net/container/blob.png?sv=2020-08-04&ss=bfqt&srt=sco&sp=rwdlacupitfx&se=2025-02-02T15:30:33Z&st=2022-02-02T07:30:33Z&spr=https&sig=a3b%2BJkitsaUUGzm1fONLJJRw6GDntKcERFz0l5E7IyA%3D" } });
db.teststring.updateOne({ _id: 2 }, { $set: { str: "https://account.blob.core.windows.net/container/blob.jpg?sv=2020-08-04&ss=bfqt&srt=sco&sp=rwdlacupitfx&se=2025-02-02T15:30:33Z&st=2022-02-02T07:30:33Z&spr=https&sig=a3b%2BJkitsaUUGzm1fONLJJRw6GDntKcERFz0l5E7IyA%3D" } });
db.teststring.updateOne({ _id: 3 }, { $set: { str: "https://account.blob.core.windows.net/container/blob.pdf?sv=2020-08-04&ss=bfqt&srt=sco&sp=rwdlacupitfx&se=2025-02-02T15:30:33Z&st=2022-02-02T07:30:33Z&spr=https&sig=a3b%2BJkitsaUUGzm1fONLJJRw6GDntKcERFz0l5E7IyA%3D" } });

/* v8.0 */
/* works!!! */
db.teststring.aggregate([
	{
		$match: { str: /\?.*?=2025-02-02T15:30:33Z.*/i }
	},
	{
		$addFields: {
			str: {
				$substrBytes: [
					"$str",
					0,
					{ $indexOfBytes: ["$str", "?"] }
				]
			}
		}
	},
	{
		$merge: {
			into: "teststring",
			whenMatched: "merge"
		}
	}
]);

/* v8 */
/* PlanExecutor error during aggregation :: caused by :: $replaceAll requires that 'find' be a string, found: /\?.*?=2025-02-02T15:30:33Z.*/i */
db.teststring.aggregate([
  {
    $addFields: {
      str: {
        $replaceAll: {
          input: "$str",
          find: /\?.*?=2025-02-02T15:30:33Z.*/i,
          replacement: ""
        }
      }
    }
  }
]);

/* v8 */
/* PlanExecutor error during aggregation :: caused by :: $replaceAll requires that 'find' be a string, found: /\?.*?=2025-02-02T15:30:33Z.*/i */
db.teststring.aggregate([
  {
    $set: {
      str: {
        $replaceAll: {
          input: "$str",
          find: /\?.*?=2025-02-02T15:30:33Z.*/i,
          replacement: ""
        }
      }
    }
  }
]);

/* v8 */ /* desn't work */
db.teststring.updateMany(
  { str: /\?.*?=2025-02-02T15:30:33Z.*/i },
  {
    $set: {
      str: {
        $replaceAll: {
          input: "$str",
          find: /\?.*?=2025-02-02T15:30:33Z.*/i,
          replacement: ""
        }
      }
    }
  }
);

$project
{
  emailLower: { $toLower: { $trim: { input: "$email" } } },
  _id: 0
}

{
  be: { $indexOfBytes: [ "abcd", "c" ] }, // 2
  substrbe: { $substrBytes: [ "abcd", 0, { $indexOfBytes: [ "abcd", "c" ] } ] }, // "ab"
  bu: { $indexOfBytes: [ "іїє", "ї" ] }, // 2
  substrbu: { $substrBytes: [ "іїє", 0, { $indexOfBytes: [ "іїє", "ї" ] } ] }, // "і"
  cpe: { $indexOfCP: [ "abcd", "c" ] }, // 2
  substrcpe: { $substrCP: [ "abcd", 0, { $indexOfCP: [ "abcd", "c" ] } ] }, // "ab"
  cpu: { $indexOfCP: [ "іїє", "ї" ] }, // 1
  substrcpu: { $substrCP: [ "іїє", 0, { $indexOfCP: [ "іїє", "ї" ] } ] }, // "і"
}

$match
{
  $expr: {
    $eq: [{ $strLenBytes: "$masterDealerId" }, 10]
  }
}