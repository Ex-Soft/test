using System.Security.Cryptography;

var rsaKey = RSA.Create();
var privateKey = rsaKey.ExportRSAPrivateKey();
File.WriteAllBytes("key", privateKey);