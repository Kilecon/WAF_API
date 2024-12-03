using WAF_API_Exceptions.DomainExceptions;

namespace WAF_API_Domain.Challenge.ValueObject
{
    public class Categories
    {
        public IEnumerable<string>? Value { get; private set; }

        public Categories(IEnumerable<string> values)
        {
            if (values == null)
            {
                throw new InvalidCommandException("Categories list seems Empty !");
            }

            Value = values
                .Where(value => !string.IsNullOrWhiteSpace(value))
                .Select(value =>
                {
                    if (!char.IsLetterOrDigit(value[0]))
                    {
                        throw new InvalidCommandException("Categories must start with a letter !");
                    }

                    return char.ToUpper(value[0]) + value.Substring(1);
                })
                .Distinct()
                .ToList();

            if (!Value.Any())
            {
                throw new InvalidCommandException();
            }
        }
    }
}