// http://aes.online-domain-tools.com/
#define TEST_1 // http://msdn.microsoft.com/en-us/library/system.security.cryptography.aescryptoserviceprovider%28v=vs.110%29.aspx
//#define TEST_2 // http://programmers-en.high-way.info/cs/aes.html

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Aes
{
    class Program
    {
        #if TEST_2
            // 128bit(16byte)IV and Key
            const string AesIV = @"!QAZ2WSX#EDC4RFV";
            const string AesKey = @"5TGB&YHN7UJM(IK<";
        #endif

        static void Main(string[] args)
        {
            try
            {
                string
                    original = "Here is some data to encrypt!",
                    roundtrip = null;

                #if TEST_1
                    // Create a new instance of the AesCryptoServiceProvider 
                    // class.  This generates a new key and initialization  
                    // vector (IV). 
                    using (AesCryptoServiceProvider myAes = new AesCryptoServiceProvider())
                    {
                        // Encrypt the string to an array of bytes. 
                        byte[] encrypted = EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);

                        // Decrypt the bytes to a string. 
                        roundtrip = DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);
                    }
                #endif

                #if TEST_2
                    var tmpString = Encrypt(original);
                    roundtrip = Decrypt(tmpString);
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
            static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
            {
                // Check arguments. 
                if (plainText == null || plainText.Length <= 0)
                    throw new ArgumentNullException("plainText");
                if (Key == null || Key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (IV == null || IV.Length <= 0)
                    throw new ArgumentNullException("Key");
                byte[] encrypted;
                // Create an AesCryptoServiceProvider object 
                // with the specified key and IV. 
                using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;

                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

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

            static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
            {
                // Check arguments. 
                if (cipherText == null || cipherText.Length <= 0)
                    throw new ArgumentNullException("cipherText");
                if (Key == null || Key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (IV == null || IV.Length <= 0)
                    throw new ArgumentNullException("IV");

                // Declare the string used to hold 
                // the decrypted text. 
                string plaintext = null;

                // Create an AesCryptoServiceProvider object 
                // with the specified key and IV. 
                using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;

                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

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

        #if TEST_2
            /// <summary>
            /// AES Encryption
            /// </summary>
            static string Encrypt(string text)
            {
                // AesCryptoServiceProvider
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                aes.BlockSize = 128;
                aes.KeySize = 128;
                aes.IV = Encoding.UTF8.GetBytes(AesIV);
                aes.Key = Encoding.UTF8.GetBytes(AesKey);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                // Convert string to byte array
                byte[] src = Encoding.Unicode.GetBytes(text);

                // encryption
                using (ICryptoTransform encrypt = aes.CreateEncryptor())
                {
                    byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);

                    // Convert byte array to Base64 strings
                    return Convert.ToBase64String(dest);
                }
            }

            /// <summary>
            /// AES decryption
            /// </summary>
            static string Decrypt(string text)
            {
                // AesCryptoServiceProvider
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                aes.BlockSize = 128;
                aes.KeySize = 128;
                aes.IV = Encoding.UTF8.GetBytes(AesIV);
                aes.Key = Encoding.UTF8.GetBytes(AesKey);
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                // Convert Base64 strings to byte array
                byte[] src = System.Convert.FromBase64String(text);

                // decryption
                using (ICryptoTransform decrypt = aes.CreateDecryptor())
                {
                    byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                    return Encoding.Unicode.GetString(dest);
                }
            }
        #endif
    }
}
