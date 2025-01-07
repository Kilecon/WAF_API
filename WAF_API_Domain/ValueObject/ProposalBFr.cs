namespace WAF_API_Domain.ValueObject
{
    public class ProposalBFr
    {
        public string Value { get; set; }
    
        public ProposalBFr(string Sentence)
        {   
            // formatter la string
            Value = Sentence;
        }
    }
}

