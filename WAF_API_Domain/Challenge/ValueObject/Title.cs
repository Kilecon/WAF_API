using WAF_API_Exceptions.DomainExceptions;

namespace WAF_API_Domain.Note.ValueObject
{
    /// <summary>
    /// Defines the <see cref="Sentence" />
    /// </summary>
    public class Sentence
    {
        public string? Value { get; private set; }

        public Sentence(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidCommandException("Sentence seems Empty !");
            }

            Value = char.ToUpper(value[0]) + value.Substring(1);

            int lastCharIndex = Value.Length - 1;
            char lastChar = Value[lastCharIndex];

            if (lastChar == '!' || lastChar == '?')
            {
                if (lastCharIndex > 0 && !char.IsDigit(Value[lastCharIndex - 1]) && Value[lastCharIndex - 1] != ' ')
                {
                    Value = Value.Substring(0, lastCharIndex) + " " + lastChar;
                }
                return;
            }
            if (!Value.EndsWith("."))
            {
                Value += ".";
            }
        }
    }
}
