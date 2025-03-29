// https://learn.microsoft.com/ru-ru/dotnet/api/system.convert.tobase64string?view=net-8.0
using System.Security.Cryptography;

class Cryptor{
    public byte[] ServerRsaOpenKey = new byte[256];
    private byte[] ServerRsaPrivateKey = new byte[256];
    private byte[] DataBaseAesKey = new byte[32];
    private byte[] DataBaseAesIv = new byte[16];
    public Cryptor(byte[] ServerRsaOpenKey, byte[] ServerRsaPrivateKey, byte[] DataBaseAesKey, byte[] DataBaseAesIv){
        this.ServerRsaOpenKey = ServerRsaOpenKey;
        this.ServerRsaPrivateKey = ServerRsaPrivateKey;
        this.DataBaseAesKey = DataBaseAesKey;
        this.DataBaseAesIv = DataBaseAesIv;
    }
    public string AesEncryptionString(string data)
    {
        using Aes aes = Aes.Create();
        aes.Key = DataBaseAesKey;
        aes.IV = DataBaseAesIv;

        using var memoryStream = new MemoryStream();
        using var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
        using var writer = new StreamWriter(cryptoStream);
        
        writer.Write(data);
        writer.Flush();
        cryptoStream.FlushFinalBlock();
        
        return Convert.ToBase64String(memoryStream.ToArray());
    }
    public string AesDecryptionString(string encryptedData)
    {
        byte[] cipherBytes = Convert.FromBase64String(encryptedData);
        
        using Aes aesAlg = Aes.Create();
        aesAlg.Key = DataBaseAesKey;
        aesAlg.IV = DataBaseAesIv;

        using MemoryStream msDecrypt = new MemoryStream(cipherBytes);
        using CryptoStream csDecrypt = new CryptoStream(msDecrypt, aesAlg.CreateDecryptor(), CryptoStreamMode.Read);
        using StreamReader srDecrypt = new StreamReader(csDecrypt);
        
        return srDecrypt.ReadToEnd();
    }
    public static (string KeyBase64, string IVBase64) GeneratedAes256KeyBase64String()
    {
        using var aes = Aes.Create();
        aes.KeySize = 256; 
        aes.GenerateKey();
        aes.GenerateIV();
        
        return (
            Convert.ToBase64String(aes.Key),
            Convert.ToBase64String(aes.IV)
        );
    }
    public static (string PublicKeyPem, string PrivateKeyPem) GenerateRsa2048Keys()
    {
        var rsa = RSA.Create(2048);
        return (
            Convert.ToBase64String(rsa.ExportRSAPublicKey()),
            Convert.ToBase64String(rsa.ExportRSAPrivateKey())
        );
    }

}