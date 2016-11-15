using System;
using System.Security.Cryptography;
using System.Text;

namespace TestMD5
{
	class Program
	{
		static void Main(string[] args)
		{
			string
				inp="qwerty",
				out1 = GetMD5Hash(inp),
				out2 = getMd5Hash(inp);

			Console.WriteLine(verifyMd5Hash(inp, out1));
			Console.WriteLine(verifyMd5Hash(inp, out2));
		}

		static string GetMD5Hash(string input)
		{
			MD5CryptoServiceProvider
				x = new System.Security.Cryptography.MD5CryptoServiceProvider();

			byte[]
				bs = System.Text.Encoding.UTF8.GetBytes(input);

			bs = x.ComputeHash(bs);

			StringBuilder
				s = new System.Text.StringBuilder();

			foreach (byte b in bs)
			{
				s.Append(b.ToString("x2").ToLower());
			}

			string
				password = s.ToString();

			return password;
		}

		static string getMd5Hash(string input)
		{
			MD5
				md5Hasher = MD5.Create();

			byte[]
				data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            if (md5Hasher is IDisposable)
                md5Hasher.Dispose();

            string md5String = Encoding.Default.GetString(data);

            StringBuilder
				sBuilder = new StringBuilder();

			for (int i = 0; i < data.Length; i++)
			{
				sBuilder.Append(data[i].ToString("x2"));
			}

			return sBuilder.ToString();
		}

		static bool verifyMd5Hash(string input, string hash)
		{
			string
				hashOfInput = getMd5Hash(input);

			StringComparer
				comparer = StringComparer.OrdinalIgnoreCase;

			return comparer.Compare(hashOfInput, hash) == 0;
		}
	}
}
