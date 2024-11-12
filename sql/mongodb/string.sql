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