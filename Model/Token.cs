using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

public class Token
{
    public string? token { get; set; }
    public string? ClientRsaOpenKey{ get; set; }

}