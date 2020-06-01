//#define BINARY_FILE
//#define FROM_FILE
//#define TO_FILE

using System;
using System.IO;

namespace TestBase64
{
	class Program
	{
		static void Main(string[] args)
		{
		    byte[]
		        encbuff = null,
                decbuff = null;

		    string
		        strBase64 = null,
                strIn = null,
                strOutUTF = null;

            string
                currentDirectory = Directory.GetCurrentDirectory(),
                inputFileName,
                outputFileName;

            currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

            #if FROM_FILE
                inputFileName = currentDirectory + "inbody.eml";

		        if (File.Exists(inputFileName))
		        {
		            strBase64 = File.ReadAllText(inputFileName).Replace("\r\n","");
                    decbuff = Convert.FromBase64String(strBase64);
		            strOutUTF = System.Text.Encoding.UTF8.GetString(decbuff);
                    Console.WriteLine(strOutUTF);
		        }
            #endif

            #if BINARY_FILE
                //inputFileName = currentDirectory + "clear_icon.png";
                inputFileName = currentDirectory + "more.png";

		        if (File.Exists(inputFileName))
		        {
		            encbuff = File.ReadAllBytes(inputFileName);
		            strBase64 = Convert.ToBase64String(encbuff);
                    strIn = "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";

                    Console.WriteLine("{1}= \"{0}\" {1}= \"{2}\" {1}=", strBase64, strBase64 != strIn ? "!" : "=", strIn);

                    decbuff = Convert.FromBase64String(strBase64);

		            string
                        outputFileName = Path.Combine(Path.GetDirectoryName(inputFileName), Path.GetFileNameWithoutExtension(inputFileName)+"_out"+Path.GetExtension(inputFileName));

                    if(File.Exists(outputFileName))
                        File.Delete(outputFileName);

                    File.WriteAllBytes(outputFileName, decbuff);
		        }
            #endif

		    string
		        str = "{\"sub\":\"some_id\",\"granny\":\"cookie\",\"nbf\":1591013209,\"exp\":1591016809,\"iss\":\"http://localhost:56218/\",\"aud\":\"http://localhost:56218/\"}";

            encbuff = System.Text.Encoding.UTF8.GetBytes(str);
			strBase64 = Convert.ToBase64String(encbuff);

            strIn = "eyJzdWIiOiJzb21lX2lkIiwiZ3Jhbm55IjoiY29va2llIiwibmJmIjoxNTkxMDEzMjA5LCJleHAiOjE1OTEwMTY4MDksImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTYyMTgvIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo1NjIxOC8ifQ==";

            Console.WriteLine("\"{0}\" {1}= \"{2}\"", strBase64, strBase64 != strIn ? "!" : "=", strIn);

            decbuff = Convert.FromBase64String(strIn);
            strOutUTF = System.Text.Encoding.UTF8.GetString(decbuff);
            decbuff = Convert.FromBase64String(strBase64);
            strOutUTF = System.Text.Encoding.UTF8.GetString(decbuff);

            var charArray = strIn.ToCharArray();

		    //decbuff = Convert.FromBase64String(strIn);
		    decbuff = Convert.FromBase64CharArray(charArray, 0, charArray.Length);

            #if TO_FILE
                outputFileName = Path.Combine(currentDirectory, "fromBase64.out");

                if (File.Exists(outputFileName))
                    File.Delete(outputFileName);

                File.WriteAllBytes(outputFileName, decbuff);
            #endif

		    strOutUTF = System.Text.Encoding.UTF8.GetString(decbuff);

			string
				strOut1251 = System.Text.Encoding.GetEncoding(1251).GetString(decbuff),
				strOutUnicode = System.Text.Encoding.Unicode.GetString(decbuff);
		}
	}
}
