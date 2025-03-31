using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SaqurApi;

public class Token
{
    public string? token { get; set; }
    public string? ClientRsaOpenKey{ get; set; }

}