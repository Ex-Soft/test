import { ServiceBusClient } from "@azure/service-bus";

async function main() {
  const connectionString =
    "Endpoint=sb://.servicebus.windows.net/;SharedAccessKeyName=;SharedAccessKey=";
  const topicName = "importevent";
  const subscriptionName = "importevent";

  const client = new ServiceBusClient(connectionString);

  const receiver = client.createReceiver(topicName, subscriptionName, {
    receiveMode: "peekLock",
  });

  const receivedMessages = await receiver.receiveMessages(1);
  for (const message of receivedMessages) {
    console.log("Received message:", message.body);
    await receiver.completeMessage(message);
  }

  await receiver.close();
  await client.close();
}

main().catch((err) => {
  console.log(err);
  process.exit(1);
});

/*
npm install @azure/service-bus
*/
