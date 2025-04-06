namespace SaqurApi;

public partial class Cryptor{
    public static byte[] StringHexToBytes(string hexStr)
    {
        hexStr = hexStr.Replace("-", "");
        byte[] raw = new byte[hexStr.Length / 2];
        for (int i = 0; i < raw.Length; i++)
        {
            raw[i] = Convert.ToByte(hexStr.Substring(i * 2, 2), 16);
        }
        return raw;
    }

    public static string BytesHexToString(byte[] bytes)
    {
        return BitConverter.ToString(bytes);
    }
    
}