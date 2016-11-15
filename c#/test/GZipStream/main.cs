using System;
using System.IO;
using System.IO.Compression;

namespace TestGZipStream
{
	class Program
	{
		static void Main(string[] args)
		{
			byte[]
				buff;

			string
				InputFileName = "test.html",//"readme.txt",
				OutputFileName = "readme.gz";

			if (File.Exists(OutputFileName))
				File.Delete(OutputFileName);

			using (FileStream iFile = new FileStream(InputFileName, FileMode.Open))
			{
				buff = new byte[iFile.Length];
				iFile.Read(buff, 0, (int)iFile.Length);
				using (FileStream oFile = new FileStream(OutputFileName, FileMode.Create))
				{
					using (GZipStream tmpGZipStream = new GZipStream(oFile, CompressionMode.Compress, false))
					{
						tmpGZipStream.Write(buff, 0, buff.Length);
					}
				}
			}

			InputFileName = OutputFileName;
			OutputFileName = "readme.gz.txt";
			if (File.Exists(OutputFileName))
				File.Delete(OutputFileName);

			using (FileStream iFile = new FileStream(InputFileName, FileMode.Open))
			{
				using (FileStream oFile = new FileStream(OutputFileName, FileMode.Create))
				{
					using (GZipStream tmpGZipStream = new GZipStream(iFile, CompressionMode.Decompress))
					{
						buff = new byte[iFile.Length];

						int
							numRead;

						while ((numRead = tmpGZipStream.Read(buff, 0, buff.Length)) != 0)
						{
							oFile.Write(buff, 0, numRead);
						}
					}
				}
			}
		}
	}
}
