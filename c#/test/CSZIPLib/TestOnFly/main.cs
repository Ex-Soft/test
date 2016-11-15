// https://github.com/icsharpcode/SharpZipLib/wiki/Zip-Samples

//#define CREATE_ZIP
//#define FROM_TO_MEMORY_STREAM_OR_ARRAY
#define UNPACK_AND_REPACK

using System;
using System.IO;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

namespace TestOnFly
{
    class Program
    {
        static void Main(string[] args)
        {
            string
                currentDirectory = Directory.GetCurrentDirectory();

            currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

            #if UNPACK_AND_REPACK

            string
                zipFileIn = currentDirectory + "images.zip",
                zipFileOut = currentDirectory + "images_out.zip";

            DoRebuildFile(zipFileIn, "123", zipFileOut);

            #endif
        }

        #if UNPACK_AND_REPACK

        static ZipOutputStream _zipOut;
        static byte[] _buffer = new byte[4096];

        // This example illustrates reading an input disk file (or any input stream),
        // extracting the individual files, including from embedded zipfiles,
        // and writing them to a new zipfile with an output memorystream or disk file.
        //
        static void DoRebuildFile(string zipFileIn, string password, string zipFileOut)
        {
            Stream inStream = File.OpenRead(zipFileIn);

            MemoryStream outputMemStream = new MemoryStream();
            _zipOut = new ZipOutputStream(outputMemStream);
            _zipOut.IsStreamOwner = false;  // False stops the Close also Closing the underlying stream.

            // To output to a disk file, replace the above with
            //
            //   FileStream fsOut = File.Create(newZipFileName);
            //   _zipOut = new ZipOutputStream(fsOut);
            //   _zipOut.IsStreamOwner = true;  // Makes the Close also Close the underlying stream.

            _zipOut.SetLevel(9);
            _zipOut.Password = password;        // optional

            RecursiveExtractRebuild(inStream);
            inStream.Close();

            // Must finish the ZipOutputStream to finalise output before using outputMemStream.
            _zipOut.Close();

            outputMemStream.Position = 0;

            // At this point the underlying output memory stream (outputMemStream) contains the zip.
            // If outputting to a web response, see the "Create a Zip as a browser download attachment in IIS" example above.
            // See the "Create a Zip to a memory stream or byte array" example for other output options.

            if(File.Exists(zipFileOut))
                File.Delete(zipFileOut);

            File.WriteAllBytes(zipFileOut, outputMemStream.ToArray());
        }

        static void RecursiveExtractRebuild(Stream str)
        {

            ZipFile zipFile = new ZipFile(str);
            zipFile.IsStreamOwner = false;

            foreach (ZipEntry zipEntry in zipFile)
            {
                if (!zipEntry.IsFile)
                    continue;
                String entryFileName = zipEntry.Name; // or Path.GetFileName(zipEntry.Name) to omit folder
                // Specify any other filtering here.

                Stream zipStream = zipFile.GetInputStream(zipEntry);
                // Zips-within-zips are extracted. If you don't want this and wish to keep embedded zips as-is, just delete these 3 lines. 
                if (entryFileName.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                {
                    RecursiveExtractRebuild(zipStream);
                }
                else
                {
                    ZipEntry newEntry = new ZipEntry(entryFileName);
                    newEntry.DateTime = zipEntry.DateTime;
                    newEntry.Size = zipEntry.Size;
                    // Setting the Size will allow the zip to be unpacked by XP's built-in extractor and other older code.

                    _zipOut.PutNextEntry(newEntry);

                    StreamUtils.Copy(zipStream, _zipOut, _buffer);
                    _zipOut.CloseEntry();
                }
            }
        }

        #endif

        #if FROM_TO_MEMORY_STREAM_OR_ARRAY

        // Compresses the supplied memory stream, naming it as zipEntryName, into a zip,
        // which is returned as a memory stream or a byte array.
        //
        static MemoryStream CreateToMemoryStream(MemoryStream memStreamIn, string zipEntryName)
        {

            MemoryStream outputMemStream = new MemoryStream();
            ZipOutputStream zipStream = new ZipOutputStream(outputMemStream);

            zipStream.SetLevel(3); //0-9, 9 being the highest level of compression

            ZipEntry newEntry = new ZipEntry(zipEntryName);
            newEntry.DateTime = DateTime.Now;

            zipStream.PutNextEntry(newEntry);

            StreamUtils.Copy(memStreamIn, zipStream, new byte[4096]);
            zipStream.CloseEntry();

            zipStream.IsStreamOwner = false;    // False stops the Close also Closing the underlying stream.
            zipStream.Close();          // Must finish the ZipOutputStream before using outputMemStream.

            outputMemStream.Position = 0;
            return outputMemStream;

            // Alternative outputs:
            // ToArray is the cleaner and easiest to use correctly with the penalty of duplicating allocated memory.
            //byte[] byteArrayOut = outputMemStream.ToArray();

            // GetBuffer returns a raw buffer raw and so you need to account for the true length yourself.
            //byte[] byteArrayOut = outputMemStream.GetBuffer();
            //long len = outputMemStream.Length;
        }

        #endif

        #if CREATE_ZIP

        // Compresses the files in the nominated folder, and creates a zip file on disk named as outPathname.
        //
        public void CreateSample(string outPathname, string password, string folderName)
        {

            FileStream fsOut = File.Create(outPathname);
            ZipOutputStream zipStream = new ZipOutputStream(fsOut);

            zipStream.SetLevel(3); //0-9, 9 being the highest level of compression

            zipStream.Password = password;  // optional. Null is the same as not setting. Required if using AES.

            // This setting will strip the leading part of the folder path in the entries, to
            // make the entries relative to the starting folder.
            // To include the full path for each entry up to the drive root, assign folderOffset = 0.
            int folderOffset = folderName.Length + (folderName.EndsWith("\\") ? 0 : 1);

            CompressFolder(folderName, zipStream, folderOffset);

            zipStream.IsStreamOwner = true; // Makes the Close also Close the underlying stream
            zipStream.Close();
        }

        // Recurses down the folder structure
        //
        private void CompressFolder(string path, ZipOutputStream zipStream, int folderOffset)
        {

            string[] files = Directory.GetFiles(path);

            foreach (string filename in files)
            {

                FileInfo fi = new FileInfo(filename);

                string entryName = filename.Substring(folderOffset); // Makes the name in zip based on the folder
                entryName = ZipEntry.CleanName(entryName); // Removes drive from name and fixes slash direction
                ZipEntry newEntry = new ZipEntry(entryName);
                newEntry.DateTime = fi.LastWriteTime; // Note the zip format stores 2 second granularity

                // Specifying the AESKeySize triggers AES encryption. Allowable values are 0 (off), 128 or 256.
                // A password on the ZipOutputStream is required if using AES.
                //   newEntry.AESKeySize = 256;

                // To permit the zip to be unpacked by built-in extractor in WinXP and Server2003, WinZip 8, Java, and other older code,
                // you need to do one of the following: Specify UseZip64.Off, or set the Size.
                // If the file may be bigger than 4GB, or you do not need WinXP built-in compatibility, you do not need either,
                // but the zip will be in Zip64 format which not all utilities can understand.
                //   zipStream.UseZip64 = UseZip64.Off;
                newEntry.Size = fi.Length;

                zipStream.PutNextEntry(newEntry);

                // Zip the file in buffered chunks
                // the "using" will close the stream even if an exception occurs
                byte[] buffer = new byte[4096];
                using (FileStream streamReader = File.OpenRead(filename))
                {
                    StreamUtils.Copy(streamReader, zipStream, buffer);
                }
                zipStream.CloseEntry();
            }
            string[] folders = Directory.GetDirectories(path);
            foreach (string folder in folders)
            {
                CompressFolder(folder, zipStream, folderOffset);
            }
        }

        #endif
    }
}
