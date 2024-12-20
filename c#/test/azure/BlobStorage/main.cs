using Azure.Storage;
using Azure.Storage.Blobs;

const string accountName = "accountName";
const string accountKey = "accountKey";
StorageSharedKeyCredential? credential = !string.IsNullOrWhiteSpace(accountKey) ? new StorageSharedKeyCredential(accountName, accountKey) : null;
const string blobContainerName = "blobContainerName";
const string blobName = "blobName";

try
{
    BlobServiceClient blobServiceClient = credential != null ? new BlobServiceClient(new Uri($"https://{accountName}.blob.core.windows.net"), credential) : new BlobServiceClient(new Uri($"https://{accountName}.blob.core.windows.net"));
    BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(blobContainerName);
    var blobs = blobContainerClient.GetBlobs();

    foreach (var blob in blobs.Where(item => item.Properties.CreatedOn >= new DateTimeOffset(2023, 6, 1, 0, 0, 0, new TimeSpan(0))))
    {
        System.Console.WriteLine($"{blob.Name}");
        System.Diagnostics.Debug.WriteLine($"{blob.Name}");
    }

    BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);
    blobClient.DownloadTo(blobName);
}
catch (Exception e)
{
    System.Diagnostics.Debug.WriteLine(e);
}