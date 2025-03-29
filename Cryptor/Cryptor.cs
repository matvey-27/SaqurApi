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