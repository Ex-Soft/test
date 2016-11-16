/* http://www.codeproject.com/Articles/1125457/Native-JSON-Support-in-SQL-Server */

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