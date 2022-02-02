using Amazon.Athena;
using AthenaNetCore.BusinessLogic.Extentions;

namespace TestS3
{
    public class AthenaClient
    {
        const int CLIENT_EXECUTION_TIMEOUT = 100000;
        const string ATHENA_OUTPUT_BUCKET = "s3://inozhenko-athena-test/";
        const string ATHENA_SAMPLE_QUERY = "select * from testdata where fDateTime between cast('2021-12-29' as date) and cast('2021-12-30' as date) or fTimeStamp = cast('2021-12-31 23:59:59.123' as timestamp) or groupId = 3 or id = '04e6c0bb-0214-4e2a-8ff4-55b06a20afae' order by groupId, value;";
        const long SLEEP_AMOUNT_IN_MS = 1000;
        const string ATHENA_DEFAULT_DATABASE = "inozhenkotestathenadatabase";

        private IAmazonAthena _athenaClient;

        public AthenaClient(IAmazonAthena athenaClient)
        {
            _athenaClient = athenaClient;
        }

        public async Task Query()
        {
            var result = await _athenaClient.QueryAsync<EventItem>(ATHENA_SAMPLE_QUERY);
        }
    }
}
