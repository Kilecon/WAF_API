namespace WAF_API_Domain
{
    public class ProposalBEn
    {
        public string Value { get; set; }
        
        public ProposalBEn(string Sentence)
        {
            // formatter la string
            Value = Sentence;
        }
    }    
}

