using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

// az storage account show-connection-string --name StorageAccount --resource-group ResourceGroup

string connectionString = "DefaultEndpointsProtocol=https;EndpointSuffix=core.windows.net;AccountName=;AccountKey=;FileEndpoint=https://.file.core.windows.net/";
string shareName = "";

ShareClient share = new ShareClient(connectionString, shareName);

var remaining = new Queue<ShareDirectoryClient>();
remaining.Enqueue(share.GetRootDirectoryClient());
while (remaining.Count > 0)
{
    // Get all of the next directory's files and subdirectories
    ShareDirectoryClient dir = remaining.Dequeue();
    foreach (ShareFileItem item in dir.GetFilesAndDirectories())
    {
        // Print the name of the item
        Console.WriteLine(item.Name);

        // Keep walking down directories
        if (item.IsDirectory)
        {
            remaining.Enqueue(dir.GetSubdirectoryClient(item.Name));
        }
        else
        {
            Console.WriteLine(item.Name);
        }
    }
}