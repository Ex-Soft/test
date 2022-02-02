#define TEST_ATHENA

using Amazon.Athena;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestS3;

var services = new ServiceCollection();

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false)
    .Build();

services.AddSingleton<IConfiguration>(configuration);
services.AddDefaultAWSOptions(configuration.GetAWSOptions());
services.AddAWSService<IAmazonAthena>();

var serviceProvider = services.BuildServiceProvider();

#if TEST_ATHENA

var amazonAthenaClient = serviceProvider.GetRequiredService<IAmazonAthena>();

var athenaClient = new AthenaClient(amazonAthenaClient);
await athenaClient.Query();

#endif