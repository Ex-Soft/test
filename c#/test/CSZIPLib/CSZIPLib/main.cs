using System;
using System.IO;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;

namespace CSZIPLib
{
	class CSZIPLib
	{
		[STAThread]
		public static void Main(string[] args)
		{
			string
				DirToZIP="e:\\cd",
				ZipFileName="e:\\TestCSZIPLib.zip";

			if(File.Exists(ZipFileName))
				File.Delete(ZipFileName);

			string[]
				filenames=Directory.GetFiles(DirToZIP);

			bool
				PackWithDirectories=true;

			Crc32
				crc=new Crc32();

			ZipOutputStream
				os=new ZipOutputStream(File.Create(ZipFileName));

			os.SetLevel(9);

			FileStream
				fs;

			byte[]
				buffer;

			ZipEntry
				entry;

			foreach(string file in filenames)
			{
				fs=File.OpenRead(file);
				buffer=new byte[fs.Length];
				fs.Read(buffer,0,buffer.Length);
				entry=new ZipEntry(PackWithDirectories ? file : Path.GetFileName(file));
				entry.DateTime=File.GetLastWriteTime(file);
				entry.Size=fs.Length;
				entry.ExternalFileAttributes=(int)File.GetAttributes(file);
				fs.Close();

				crc.Reset();
				crc.Update(buffer);
				entry.Crc=crc.Value;

				os.PutNextEntry(entry);
				os.Write(buffer,0,buffer.Length);
			}

			os.Finish();
			os.Close();

			ZipInputStream
				s=new ZipInputStream(File.OpenRead(ZipFileName));

			string
				directoryName,
				fileName,
				DirFromZip="e:\\temp\\TestCSZIPLib\\";

			int
				pos,
				size=2048;

			FileStream
				streamWriter;

			byte[]
				data=new byte[size];

			while((entry=s.GetNextEntry())!=null)
			{
				directoryName=Path.GetDirectoryName(entry.Name);
				if((pos=directoryName.IndexOf(Path.VolumeSeparatorChar))>=0)
					directoryName=directoryName.Remove(0,pos+1);
				if(directoryName.StartsWith(Path.DirectorySeparatorChar.ToString()))
					directoryName=directoryName.Remove(0,1);
				fileName=Path.GetFileName(entry.Name);
				if(!Directory.Exists(DirFromZip+directoryName))
					Directory.CreateDirectory(DirFromZip+directoryName);

				if(fileName!=string.Empty)
				{
					streamWriter=File.Create(DirFromZip+directoryName+Path.DirectorySeparatorChar+fileName);
					while((size=s.Read(data,0,data.Length))>0)
						streamWriter.Write(data,0,size);
					streamWriter.Close();
					File.SetLastWriteTime(DirFromZip+directoryName+Path.DirectorySeparatorChar+fileName,entry.DateTime);
				}
			}
			s.Close();

			Extract(ZipFileName,null,true);
		}

		public static void Extract(string aZipFileName, string aDestDir, bool WithFullPath)
		{
			ZipInputStream
				s=null;

			FileStream
				streamWriter=null;

			try
			{
				try
				{
					if(aDestDir==null || aDestDir==string.Empty)
						aDestDir=Directory.GetCurrentDirectory();
					if(aDestDir.EndsWith(Path.DirectorySeparatorChar.ToString()))
						aDestDir=aDestDir.Remove(aDestDir.Length-1,1);
					if(!Directory.Exists(aDestDir))
						Directory.CreateDirectory(aDestDir);
					aDestDir+=Path.DirectorySeparatorChar;

					s=new ZipInputStream(File.OpenRead(aZipFileName));

					ZipEntry
						entry;

					string
						directoryName,
						fileName;

					int
						pos,
						size=8192;

					byte[]
						data=null;
					
					while(data==null && size!=0)
					{
						try
						{
							data=new byte[size];
						}
						catch(OutOfMemoryException)
						{
							size>>=1;
						}
					}
					if(data==null && size==0)
						throw(new Exception("Insufficient memory")); 

					while((entry=s.GetNextEntry())!=null)
					{
						if(WithFullPath)
						{
							directoryName=Path.GetDirectoryName(entry.Name);
							if((pos=directoryName.IndexOf(Path.VolumeSeparatorChar))>=0)
								directoryName=directoryName.Remove(0,pos+1);
							if(directoryName.StartsWith(Path.DirectorySeparatorChar.ToString()))
								directoryName=directoryName.Remove(0,1);
							if(!Directory.Exists(aDestDir+directoryName))
								Directory.CreateDirectory(aDestDir+directoryName);
							directoryName+=Path.DirectorySeparatorChar;
						}
						else
							directoryName=string.Empty;

						if((fileName=Path.GetFileName(entry.Name))!=string.Empty)
						{
							streamWriter=File.Create(aDestDir+directoryName+fileName);
							while((size=s.Read(data,0,data.Length))>0)
								streamWriter.Write(data,0,size);
							streamWriter.Close();
							streamWriter=null;
							File.SetLastWriteTime(aDestDir+directoryName+fileName,entry.DateTime);
							File.SetAttributes(aDestDir+directoryName+fileName,(FileAttributes)entry.ExternalFileAttributes);
						}
					}
				}
				catch(Exception eException)
				{
					throw(new Exception(eException.GetType().FullName+Environment.NewLine+"Message: "+eException.Message+Environment.NewLine+"StackTrace:"+Environment.NewLine+eException.StackTrace));
				}
			}
			finally
			{
				if(streamWriter!=null)
					streamWriter.Close();
				if(s!=null)
					s.Close();
			}
		}
	}
}