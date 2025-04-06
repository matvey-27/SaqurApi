using System.Security.Cryptography;

namespace SaqurApi;

public partial class Cryptor{
    public static string AesEncryptionTokenString(string data)
    {
        using Aes aes = Aes.Create();
        aes.KeySize = 256; 
        aes.GenerateKey();
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using var memoryStream = new MemoryStream();
        using var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
        using var writer = new StreamWriter(cryptoStream);
        
        writer.Write(data);
        writer.Flush();
        cryptoStream.FlushFinalBlock();
        
        return Convert.ToBase64String(memoryStream.ToArray());
    }
}