import { BlobServiceClient } from "@azure/storage-blob";
import * as fs from "fs";

async function main() {
    const account = "account";
    const sasToken = "";
    const connectionString = `https://${account}.blob.core.windows.net${!!sasToken ? `?${sasToken}`: ''}`;
    const blobServiceClient = new BlobServiceClient(connectionString);
    const containerName = "containerName";
    const blobName = "blobName";
    const containerClient = blobServiceClient.getContainerClient(containerName);
    const blobClient = containerClient.getBlobClient(blobName);

    if (fs.existsSync(blobName))
        fs.unlinkSync(blobName);

    await blobClient.downloadToFile(blobName);
  }
  
  main().catch((err) => {
    console.log(err);
    process.exit(1);
  });
  
  /*
  npm init -y
  npm install --save-dev typescript @types/node
  npx tsc --init --rootDir src --outDir out --sourceMap
  npm install @azure/storage-blob
  */
  