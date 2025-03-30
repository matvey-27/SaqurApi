using MongoDB.Bson.Serialization.Attributes;

public class User
{
    [BsonId]
    public int id { get; set; }
    public string? login { get; set; }
    public string? password { get; set; }
    public List<Token>? tokenList { get; set; }

}