import { BlobServiceClient } from "@azure/storage-blob";
import * as fs from "fs";
import * as fsp from "fs/promises";

async function download(accountName: string, sasToken?: string) {
  const connectionString = `https://${accountName}.blob.core.windows.net${!!sasToken ? `?${sasToken}` : ""}`;
  const blobServiceClient = new BlobServiceClient(connectionString);
  const containerName = "containerName";
  const blobName = "blobName";
  const containerClient = blobServiceClient.getContainerClient(containerName);
  const blobClient = containerClient.getBlobClient(blobName);

  if (fs.existsSync(blobName))
    fs.unlinkSync(blobName);

  await blobClient.downloadToFile(blobName);
}

async function upload(accountName: string, sasToken?: string) {
  const fileName = "fileName";
  const connectionString = `https://${accountName}.blob.core.windows.net${!!sasToken ? `?${sasToken}` : ""}`;
  const blobServiceClient = new BlobServiceClient(connectionString);
  const containerName = "containerName";
  const blobName = `TestImage${new Date().valueOf()}.jpg`;
  const containerClient = blobServiceClient.getContainerClient(containerName);
  const blockBlobClient = containerClient.getBlockBlobClient(blobName);

  if (fs.existsSync(fileName)) {
    const fileContent = await fsp.readFile(fileName);
    const uploadResponse = await blockBlobClient.upload(fileContent, fileContent.length, {
      // metadata: {
      //   "custom-metadata": fileName,
      // },
      blobHTTPHeaders: {
        blobContentType: "image/jpeg",
      },
    });

    console.log(`Upload completed.  Blob URL: ${blockBlobClient.url}`);
    console.log(`Response:`, uploadResponse);
  }
}

/* async function listContainers(accountName: string, sasToken: string): Promise<string[]> {
  try {
    const sharedKeyCredential = new StorageSharedKeyCredential(accountName, sasToken);
    const blobServiceClient = new BlobServiceClient(`https://${accountName}.blob.core.windows.net`, sharedKeyCredential);

    const containerNames: string[] = [];
    let i = 1;
    let listContainersResponse;

    do {
      listContainersResponse = await blobServiceClient.listContainers({
        include: ["metadata"],
        maxPageSize: 100,
      });

      for await (const container of listContainersResponse.byPage()) {
        containerNames.push(container.name);
        console.log(`Container ${i++}: ${container.name}`);
      }

    } while (listContainersResponse.continuationToken);

    return containerNames;

  } catch (error) {
    console.error("Error listing containers:", error);
    throw error;
  }
} */

async function main() {
  const accountName = "accountName";
  const sasToken = "sasToken";
  
  // await listContainers(accountName, sasToken);
  await download(accountName, sasToken);
  await upload(accountName, sasToken);
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
