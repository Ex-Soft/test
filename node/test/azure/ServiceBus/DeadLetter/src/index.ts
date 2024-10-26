import {
  delay,
  ServiceBusClient,
  ServiceBusReceivedMessage,
  ProcessErrorArgs,
} from "@azure/service-bus";

const connectionString = "Endpoint=sb://.servicebus.windows.net/;SharedAccessKeyName=;SharedAccessKey=";
const topicName = "importdealeradmin";
const subscriptionName = "importdealeradmin";

async function receiveMessages() {
  const client = new ServiceBusClient(connectionString);

  const receiver = client.createReceiver(topicName, subscriptionName, {
    receiveMode: "peekLock",
    subQueueType: "deadLetter",
  });

  const receivedMessages = await receiver.receiveMessages(1);
  for (const message of receivedMessages) {
    if (
      message?.enqueuedTimeUtc?.getFullYear() === 2022 &&
      message?.enqueuedTimeUtc?.getMonth() === 2 &&
      message?.enqueuedTimeUtc?.getDate() === 1
    ) {
      console.log("Received message:", message.body);
    }

    // await receiver.completeMessage(message);
  }

  await receiver.close();
  await client.close();
}

async function subscribe() {
  const client = new ServiceBusClient(connectionString);

  const receiver = client.createReceiver(topicName, subscriptionName, {
    receiveMode: "peekLock",
    subQueueType: "deadLetter",
  });

  const messageHandler = async (messageReceived: ServiceBusReceivedMessage) => {
    // console.log("Received message:", messageReceived.body);
    console.log(
      '%o "%s" "%s" "%s"',
      messageReceived?.enqueuedTimeUtc,
      messageReceived?.body?.email,
      messageReceived?.body?.firstName,
      messageReceived?.body?.lastName
    );

    if (
      messageReceived?.enqueuedTimeUtc?.getFullYear() === 2022 &&
      messageReceived?.enqueuedTimeUtc?.getMonth() === 2 &&
      messageReceived?.enqueuedTimeUtc?.getDate() === 1
      // && /\d+/i.test(messageReceived?.body?.firstName)
    ) {
      console.log("Received message:", messageReceived.body);
    }
  };

  const errorHandler = async (error: ProcessErrorArgs) => {
    console.log(error);
  };

  receiver.subscribe({
    processMessage: messageHandler,
    processError: errorHandler,
  });

  await delay(60000);

  await receiver.close();
  await client.close();
}

/*
receiveMessages().catch((err) => {
  console.log(err);
  process.exit(1);
});
*/

subscribe().catch((err) => {
  console.log(err);
  process.exit(1);
});

/*
npm install @azure/service-bus
*/
