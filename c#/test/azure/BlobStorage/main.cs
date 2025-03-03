using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

const string connectionString = "connectionString";
const string accountName = "accountName";
const string accountKey = "accountKey";
StorageSharedKeyCredential? credential = !string.IsNullOrWhiteSpace(accountKey) ? new StorageSharedKeyCredential(accountName, accountKey) : null;
const string blobContainerName = "blobContainerName";

string blobName;

string currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

if (currentDirectory.IndexOf("bin") != -1)
    currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

try
{
    BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
    BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(blobContainerName);
    string fileName = Path.Combine(currentDirectory, "TestImage.jpg");
    blobName = $"{Guid.NewGuid()}@{Path.GetFileName(fileName)}";

    if (File.Exists(fileName))
    {
        BlobClient blobClient = containerClient.GetBlobClient(blobName);

        using (FileStream fileStream = File.OpenRead(fileName))
        {
            var uploadResponse = await blobClient.UploadAsync(fileStream, new BlobHttpHeaders
            {
                ContentType = "image/jpeg"
            });

            Console.WriteLine($"File {blobName} uploaded successfully to blob storage. ({uploadResponse.Value.BlobSequenceNumber})");
        }
    }
}
catch (Exception e)
{
    System.Diagnostics.Debug.WriteLine(e);
}

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

    blobName = "blobName";
    BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);
    blobClient.DownloadTo(blobName);
}
catch (Exception e)
{
    System.Diagnostics.Debug.WriteLine(e);
}