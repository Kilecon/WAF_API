namespace WAF_API_Domain.ValueObject
{
    public class DifficultyName
    {
        public string Value { get; set; }

        public DifficultyName(string Sentence)
        {
            // formatter la string
            Value = Sentence;
        }
    }
}

