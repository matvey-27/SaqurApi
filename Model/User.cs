public class User
{
    public int id { get; set; }
    public string? login { get; set; }
    public string? password { get; set; }
    public List<Token>? tokenList { get; set; }

}