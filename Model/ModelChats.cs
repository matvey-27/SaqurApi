namespace SaqurApi.Model;

public class ModelChats
{
    public int id { get; set; }
    public string? type { get; set; }
    public string? nameChat { get; set; }
    public List<object>? users { get; set; }
    public List<object>? messeges { get; set; }
}
