// http://aes.online-domain-tools.com/
#define TEST_1 // http://msdn.microsoft.com/en-us/library/system.security.cryptography.rijndael%28v=vs.110%29.aspx

using System;
using System.IO;
using System.Security.Cryptography;

namespace TestRijndael
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string
                    original = "Here is some data to encrypt!",
                    roundtrip = null;

                #if TEST_1
                    // Create a new instance of the Rijndael 
                    // class.  This generates a new key and initialization  
                    // vector (IV). 
                    using (Rijndael myRijndael = Rijndael.Create())
                    {
                        byte[]
                            iv = new byte[32],
                            ivInit = { 0x41, 0x53, 0x53, 0x4F, 0x46, 0x4D, 0x59, 0x42, 0x46, 0x61, 0x63, 0x73 };

                        for (var i = 0; i < ivInit.Length; ++i)
                            iv[i] = ivInit[i];

                        myRijndael.BlockSize = 256;
                        myRijndael.Key = new byte[] { 0x46, 0x34, 0x3a, 0x5f, 0x39, 0x4e, 0x36, 0x55, 0x37, 0x6a, 0x38, 0x44, 0x32, 0x51, 0x70, 0x62 };
                        myRijndael.IV = iv;

                        // Encrypt the string to an array of bytes. 
                        byte[] encrypted = EncryptStringToBytes(original, myRijndael.Key, myRijndael.IV);

                        // Decrypt the bytes to a string. 
                        roundtrip = DecryptStringFromBytes(encrypted, myRijndael.Key, myRijndael.IV);
                    }
                #endif

                //Display the original data and the decrypted data.
                Console.WriteLine("Original:   {0}", original);
                Console.WriteLine("Round Trip: {0}", roundtrip);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        #if TEST_1
            static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
            {
                // Check arguments. 
                if (plainText == null || plainText.Length <= 0)
                    throw new ArgumentNullException("plainText");
                if (Key == null || Key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (IV == null || IV.Length <= 0)
                    throw new ArgumentNullException("Key");
                byte[] encrypted;
                // Create an Rijndael object 
                // with the specified key and IV. 
                using (Rijndael rijAlg = Rijndael.Create())
                {
                    rijAlg.BlockSize = 256;
                    rijAlg.Key = Key;
                    rijAlg.IV = IV;

                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                    // Create the streams used for encryption. 
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                //Write all data to the stream.
                                swEncrypt.Write(plainText);
                            }
                            encrypted = msEncrypt.ToArray();
                        }
                    }
                }

                // Return the encrypted bytes from the memory stream. 
                return encrypted;
            }

            static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
            {
                // Check arguments. 
                if (cipherText == null || cipherText.Length <= 0)
                    throw new ArgumentNullException("cipherText");
                if (Key == null || Key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (IV == null || IV.Length <= 0)
                    throw new ArgumentNullException("Key");

                // Declare the string used to hold 
                // the decrypted text. 
                string plaintext = null;

                // Create an Rijndael object 
                // with the specified key and IV. 
                using (Rijndael rijAlg = Rijndael.Create())
                {
                    rijAlg.BlockSize = 256;
                    rijAlg.Key = Key;
                    rijAlg.IV = IV;

                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                    // Create the streams used for decryption. 
                    using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                // Read the decrypted bytes from the decrypting stream 
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }

                return plaintext;
            }
        #endif
    }
}
