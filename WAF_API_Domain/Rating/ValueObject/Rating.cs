using WAF_API_Exceptions.DomainExceptions;

namespace WAF_API_Domain.Rating.ValueObject
{
    public class Rating
    {
        public decimal Value { get; private set; }

        public Rating(decimal value)
        {
            if (value < 0 || value > 5)
            {
                throw new InvalidCommandException("Invalid Rating Value ! Rating must be between 0 and 5.");
            }

            Value = Math.Round(value, 2);
        }
    }
}