using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Commands;

namespace WAF_API_Domain.WouldYouRather.Commands
{
    public class CreateWouldYouRatherCmd : Cmd
    {
        public string? QuestionEn { get; set; }
        public string? QuestionFr { get; set; }
        public string? ProposalAEn { get; set; }
        public string? ProposalAFr { get; set; }
        public string? ProposalBEn { get; set; }
        public string? ProposalBFr { get; set; }
    }
}
