using MongoDB.Bson.Serialization.Attributes;

public class Token
{
    [BsonId]
    public int id { get; set; }
    public string? token { get; set; }
    public string? ClientRsaOpenKey{ get; set; }

}