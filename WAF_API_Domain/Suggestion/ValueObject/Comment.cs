namespace WAF_API_Domain.ValueObject;

public class Comment
{
    public string Value { get; set; }
    
    public Comment(string Sentence)
    {   
        // formatter la string
        Value = Sentence;
    }
    
}