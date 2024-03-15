// https://learn.microsoft.com/en-us/azure/communication-services/quickstarts/email/send-email-smtp/send-email-smtp?pivots=smtp-method-smtpclient
// https://learn.microsoft.com/en-us/azure/communication-services/quickstarts/email/send-email-smtp/smtp-authentication?source=recommendations
// https://learn.microsoft.com/en-us/azure/communication-services/quickstarts/email/send-email?tabs=windows%2Cconnection-string&pivots=programming-language-csharp

using Azure.Communication.Email;

using static System.Console;

const string connectionString = "endpoint=https://.unitedstates.communication.azure.com/;accesskey=";

try
{
    EmailClient emailClient = new EmailClient(connectionString);

    WriteLine("Sending email...");

    EmailSendOperation emailSendOperation = emailClient.Send(
        Azure.WaitUntil.Completed,
        "donotreply@xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.azurecomm.net",
        "victim@mailinator.com",
        "Test",
        "Html content");

    EmailSendResult statusMonitor = emailSendOperation.Value;

    WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

    string operationId = emailSendOperation.Id;
    WriteLine($"Email operation id = {operationId}");
}
catch (Exception eException)
{
    WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
}
