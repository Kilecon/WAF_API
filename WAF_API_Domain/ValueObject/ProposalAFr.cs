namespace WAF_API_Domain.ValueObject
{
    public class ProposalAFr
    {
        public string Value { get; set; }
        
        public ProposalAFr(string Sentence)
        {
            // formatter la string
            Value = Sentence;
        }
    }
}
