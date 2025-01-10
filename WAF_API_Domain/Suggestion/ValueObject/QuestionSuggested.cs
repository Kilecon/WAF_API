namespace WAF_API_Domain.ValueObject;

public class QuestionSuggested
{
    public string Value { get; set; }
    
    public QuestionSuggested(string Sentence)
    {   
        // formatter la string
        Value = Sentence;
    }
}