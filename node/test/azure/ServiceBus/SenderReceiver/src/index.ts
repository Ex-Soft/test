import { ServiceBusClient } from "@azure/service-bus";

async function main() {
  const connectionString = "Endpoint=sb://.servicebus.windows.net/;SharedAccessKeyName=;SharedAccessKey=";
  const topicName = "importproduct";
  const subscriptionName = "importproduct";

  const client = new ServiceBusClient(connectionString);

  const sender = client.createSender(topicName);
  await sender.sendMessages({ body: "Hello, topic!" });
  await sender.close();

  const receiver = client.createReceiver(topicName, subscriptionName, {
    receiveMode: "receiveAndDelete" /* "peekLock" */,
  });

  const receivedMessages = await receiver.receiveMessages(1);
  for (const message of receivedMessages) {
    console.log("Received message:", message.body);
    //await receiver.completeMessage(message);
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
