namespace WAF_API_Domain.ValueObject
{
    public class DifficultyName
    {
        public string Value { get; set; }

        public DifficultyName(string sentence)
        {
            // Formatter la string
            Value = sentence;
        }
    }
}
