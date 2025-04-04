using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SaqurApi.Model;

public class Token
{
    public string? token { get; set; }
    public string? clientRsaOpenKey{ get; set; }

}