using WAF_API_Exceptions.DomainExceptions;

namespace WAF_API_Domain.Challenge.ValueObject
{
    public class Lang
    {
        public string? Value { get; private set; }

        public Lang(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length < 2 )
            {
                throw new InvalidCommandException("Missing lang parametter !");
            }

            Value = value.Substring(0, 2).ToUpper();
        }
    }
}