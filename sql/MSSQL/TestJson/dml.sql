use testdb;
go

declare @jsonData1 nvarchar(max) = N'[{ "email": "teammember1@mailinator.com", "password": "TeamMember1" }, { "email": "teammember2@mailinator.com", "password": "TeamMember2" }, { "email": "teammember3@mailinator.com", "password": "TeamMember3" }]';
select json_array(@jsonData1);
select json_query(@jsonData1, '$[0]');
select json_value(@jsonData1, '$[0].email');

select
	*
from openjson(@jsonData1) with
(
	email nvarchar(255) 'strict $.email',
	[password] nvarchar(255) '$.password' 
);

declare @jsonData2 nvarchar(max) = N'{ "email": "teammember1@mailinator.com", "password": "TeamMember1" }';
select json_value(@jsonData2, '$.email') as Email, json_value(@jsonData2, '$.password') as [Password];

select * from dbo.TestJson;

select json_array(JsonData) from dbo.TestJson where Id = 1;
select json_query(JsonData, '$[0]') from dbo.TestJson where Id = 1;
select json_value(JsonData, '$[0].email') from dbo.TestJson where Id = 1;

select json_value(JsonData, '$.email') as Email, json_value(JsonData, '$.password') as [Password] from dbo.TestJson where Id = 2;

DECLARE @varJData AS NVARCHAR(4000)
SET @varJData = 
N'{
	"OrderInfo":{
		"Tag":"#ONLORD_12546_45634",
		"HeaderInfo":{
			"CustomerNo":"CUS0001",
			"OrderDate":"04-Jun-2016",
			"OrderAmount":1200.00,
			"OrderStatus":"1",
			"Contact":["+0000 000 0000000000", 
			"info@abccompany.com", "finance@abccompany.com"]
		},
		"LineInfo":[
			{"ProductNo":"P00025", "Qty":3, "Price":200},
			{"ProductNo":"P12548", "Qty":2, "Price":300}
		]
	}
}'

SELECT JSON_VALUE(@varJData,'$.OrderInfo.Tag')
SELECT JSON_VALUE(@varJData,'$.OrderInfo.tag') /* This will returns NULL */
SELECT JSON_VALUE(@varJData,'$.OrderInfo.HeaderInfo.CustomerNo')
--SELECT JSON_VALUE(@varJData,'strict $.OrderInfo.tag') /* This will thorw an Error Property cannot be found on the specified JSON path. */
SELECT JSON_VALUE(@varJData,'$.OrderInfo.HeaderInfo.Contact[0]')
SELECT JSON_VALUE(@varJData, '$.OrderInfo.LineInfo[0].ProductNo')

SELECT JSON_QUERY(@varJData, '$.OrderInfo.HeaderInfo.Contact')
SELECT JSON_QUERY(@varJData, '$.OrderInfo.LineInfo')
SELECT JSON_QUERY(@varJData, '$.OrderInfo.LineInfo[1]')

select
	*
from
	dbo.TestJson
	cross apply openjson(cast(TestJson.JsonDataArray as nvarchar(max)))
	with
	(
		email nvarchar(255) '$.email',
		[password] nvarchar(255) '$.password'
	) as jsonValues;

;with admins (email, [password])
as
(
	select
		jsonValues.email,
		jsonValues.[password]
	from
		dbo.TestJson
		cross apply openjson(cast(TestJson.JsonDataArray as nvarchar(max)))
		with
		(
			email nvarchar(255) '$.email',
			[password] nvarchar(255) '$.password'
		) as jsonValues
)
select
	admins.*
from
	admins;