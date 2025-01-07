namespace WAF_API_Domain.ValueObject
{
    public class ProposalAEn
    {
        public string Value { get; set; }

        public ProposalAEn(string Sentence)
        {
            // formatter la string
            Value = Sentence;
        }
    }
}

