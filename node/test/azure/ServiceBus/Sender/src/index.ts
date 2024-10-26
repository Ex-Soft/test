import { ServiceBusClient } from "@azure/service-bus";

async function main() {
  const connectionString =
    "Endpoint=sb://.servicebus.windows.net/;SharedAccessKeyName=;SharedAccessKey=";
  const topicName = "importevent";

  const client = new ServiceBusClient(connectionString);

  const sender = client.createSender(topicName);
  await sender.sendMessages({ body: "Hello, topic!" });
  await sender.close();

  await client.close();
}

main().catch((err) => {
  console.log(err);
  process.exit(1);
});

/*
npm install @azure/service-bus
*/
