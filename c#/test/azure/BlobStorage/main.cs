using Azure.Storage;
using Azure.Storage.Blobs;

const string accountName = "accountName";
const string accountKey = "accountKey";
StorageSharedKeyCredential credential = new StorageSharedKeyCredential(accountName, accountKey);
const string blobContainerName = "blobContainerName";

try
{
    BlobServiceClient client = new(new Uri($"https://{accountName}.blob.core.windows.net"), credential);
    BlobContainerClient blobContainerClient = client.GetBlobContainerClient(blobContainerName);
    var blobs = blobContainerClient.GetBlobs();

    foreach (var blob in blobs.Where(item => item.Properties.CreatedOn >= new DateTimeOffset(2023, 6, 1, 0, 0, 0, new TimeSpan(0))))
    {
        System.Console.WriteLine($"{blob.Name}");
        System.Diagnostics.Debug.WriteLine($"{blob.Name}");
    }
}
catch (Exception e)
{
    System.Diagnostics.Debug.WriteLine(e);
}