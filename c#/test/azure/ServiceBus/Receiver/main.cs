using Azure.Messaging.ServiceBus;

using static System.Console;

const string connectionString = "Endpoint=sb://.servicebus.windows.net/;SharedAccessKeyName=;SharedAccessKey=;EntityPath=importdealeradmin";
const string topicName = "importdealeradmin";
const string subscriptionName = "importdealeradmin";

ServiceBusClient client = new ServiceBusClient(connectionString);

ServiceBusReceiverOptions receiverOptions = new ServiceBusReceiverOptions { SubQueue = SubQueue.DeadLetter };
ServiceBusReceiver receiver = client.CreateReceiver(topicName, subscriptionName, receiverOptions);

var message = await receiver.PeekMessageAsync();

if (message?.Body != null)
{
    WriteLine($"Body: {message.Body}");
}