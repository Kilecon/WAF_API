namespace WAF_API_Domain.ValueObject;

public class QuestionLang
{
    public string Value { get; set; }
    
    public QuestionLang(string Sentence)
    {   
        // formatter la string
        Value = Sentence;
    }
    
}