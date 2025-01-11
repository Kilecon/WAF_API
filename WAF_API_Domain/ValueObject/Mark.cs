namespace WAF_API_Domain.ValueObject
{
    public class Mark
    {
        public string? Value { get; private set; }
        public Mark()
        {
            Value = null;
        }
        public Mark(string? value)
        {
            // Sécuriser l'input
            Value = value;
        }
    }
}
