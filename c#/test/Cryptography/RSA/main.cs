#define TEST_VERIFY_SIGNATURE

using System;
using System.Security.Cryptography;
using System.Text;

namespace RSA
{
    class Program
    {
        static void Main(string[] args)
        {
            #if TEST_VERIFY_SIGNATURE
                string
                    inputString = "{\"ExpirationDate\":\"2017-04-04T18:37:50.2396443Z\",\"Id\":\"6703cd90-cc9b-4153-81bd-d5ee397bc085\",\"Key\":null,\"Name\":\"ST Чикаго Юнит. Базовая лицензия на 1 пользователя\",\"UserId\":7318349394477057,\"UserName\":\"STDev User 1\",\"ProductId\":\"3434333d-0eb2-4f01-9b0f-8a9e83c8c945\",\"Version\":{\"Major\":1,\"Minor\":0,\"Build\":0,\"Revision\":-1,\"MajorRevision\":-1,\"MinorRevision\":-1},\"CustomerId\":\"04a83e85-8714-44d6-b167-7f7b0d27d0c2\",\"CustomerName\":\"ST.development\",\"DistributorId\":null,\"DistributorName\":null}",
                    RSAKey = "<RSAKeyValue><Modulus>aH29MQQRYuZuAzBFCB/ZGfFBYjB7yTs4TTQxndQ6BuhHl0CpI0EU9MCjI6MrbIDGa07gJ5qr0f3CxRLIT3Pm0FctGh7x3j3WKPokZlgWwotWtLZvNEF/E+dgXwIMp8d88vdETorbh6zt2Gl7ATunbvsHzeQaKVmlea5d0kvOTMCFZfwadQQt+qSHHQDbtsjdu6xxAQCo/JCRnbKzXPAIbADWFVTzmMdwqMBQ6XHHlpft7dtmJpocCBawOPEPELA6ZrrmLscC+l7hSa6kg8zHi/ZomDf2C8q8TGJL3LAXDuleSiA/epOgLqDBVnIQRER7L4Km/pT9/ALkcTlGVahGWQ==</Modulus><Exponent>JQ==</Exponent></RSAKeyValue>",
                    signatureStr = "DoBt429dlJCL4UxMgoyQdFaHov+l3ifSqZgYxoq+7+OOApNaHhxqdaKdwVpA1VypiYbH2hcLMZsslMhudhpjtEC2RD7MD9IK8OeWEMZvl6Q0z9Q8/HBy8mePw0amWSXa794KCgZrtT4/K8AODXZv7sXSS+rwyCdPZ6a45JcsR2v6Jqhp3a1pYQhPcNs+3g51AI+/cpllqPeVIaXA6LPHnjU9dp8ate58vg0nnBDj0PW4i2Fh+tgMU8ALOXxNuVK6HPlc8lNLUuwEJKcaBiw1PDwPE4Ul4cZA5L3iiZxrAV+DdbNjesEJfCCruDbUbZcQUDwUs6sIzlZLsE4B2xVRrw==";

                var asymmetricAlgorithm = new RSACryptoServiceProvider();
                var hashAlgorithm = new SHA512Managed();
                var signatureDeformatter = new RSAPKCS1SignatureDeformatter();

                asymmetricAlgorithm.FromXmlString(RSAKey);
                signatureDeformatter.SetKey(asymmetricAlgorithm);
                signatureDeformatter.SetHashAlgorithm("SHA512");

                byte[]
                    hash = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString)),
                    signature = Convert.FromBase64String(signatureStr);

                var isOk = signatureDeformatter.VerifySignature(hash, signature);
            #endif
        }
    }
}
