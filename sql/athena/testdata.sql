https://aws.amazon.com/blogs/big-data/create-tables-in-amazon-athena-from-nested-json-and-mappings-using-jsonserde/
https://aws.amazon.com/premiumsupport/knowledge-center/error-json-athena/

CREATE EXTERNAL TABLE IF NOT EXISTS `inozhenkotestathenadatabase`.`testdata` (
  `type` string,
  `id` string,
  `groupId` tinyint,
  `fDateTime` date,
  `fDateTimeStr` string,
  `fTimeStamp` timestamp,
  `fArrayOfInt` array<int>,
  `fObject` struct<`type`:string,`values`:array<struct<`type`:string,id:int,value:string>>>,
  `fArrayOfObject` array<struct<`type`:string,id:int,value:string>>
)
ROW FORMAT SERDE 'org.openx.data.jsonserde.JsonSerDe' 
WITH SERDEPROPERTIES (
  'serialization.format' = '1',
  'mapping.type' = '$type',
  'mapping.values' = '$values'
) LOCATION 's3://inozhenko-athena-test/'
TBLPROPERTIES ('has_encrypted_data'='false');

DROP TABLE `testdata`;

select
    *
from (
select
    "$path" as s3FileName,
    id,
    groupId,
    fDateTime,
    from_iso8601_timestamp(fDateTimeStr) as dateTime,
    fTimeStamp,
    fArrayOfInt,
    fObject,
    fArrayOfObject
from
    testdata
) tbl
where
    (dateTime = from_iso8601_timestamp('2022-01-05T00:00:00.000Z') and dateTime = from_iso8601_timestamp('2022-01-05T02:00:00.000+02:00'))
    or (fDateTime = cast(from_iso8601_timestamp('2022-01-05T00:00:00.000Z') as date) and fDateTime = cast(from_iso8601_timestamp('2022-01-05T02:00:00.000+02:00') as date) and fDateTime = cast('2022-01-05' as date))
    or (fTimeStamp = cast('2021-01-05 00:00:00.000' as timestamp));

select
    *
from (
select
    "$path" as s3FileName,
    id,
    groupId,
    fDateTime,
    from_iso8601_timestamp(fDateTimeStr) as dateTime,
    fTimeStamp,
    fArrayOfInt,
    fObject,
    fArrayOfObject
from
    testdata
) tbl
where
    fArrayOfInt[1]=1
    and fObject.type='objectType'
    and fArrayOfObject[1].type='objectType1';

select * from testdata where fArrayOfInt[1]=1 and fObject.type='objectType' and fArrayOfObject[1].id=1;

select
    "$path" as s3FileName,
    id,
    fObject.type,
    value.type,
    value.id,
    value.value
from
    testdata,
    unnest(fobject."values") as t(value)
where
    value.type = 'valueType3';


HIVE_BAD_DATA: Error parsing field value '2021-12-31T23:59:59+02:00' for field 4: Timestamp format must be yyyy-mm-dd hh:mm:ss[.fffffffff]
