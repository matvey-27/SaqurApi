using System.Security.Cryptography;

namespace SaqurApi;

public partial class Cryptor{
    static public string CreateAesKeyString()
    {
        byte[] key;

        using (Aes aesAlg = Aes.Create())
        {
            key = aesAlg.Key;
        }   

        return BytesHexToString(key);
    }
    static public string CreateAesIvString()
    {
        byte[] iv;

        using (Aes aesAlg = Aes.Create())
        {
            iv = aesAlg.IV;
        }   

        return BytesHexToString(iv);
    }
}