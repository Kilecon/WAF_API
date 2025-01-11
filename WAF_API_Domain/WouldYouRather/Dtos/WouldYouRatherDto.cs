using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Models;

namespace WAF_API_Domain.WouldYouRather.Dtos
{
    public class WouldYouRatherDto : Dto
    {
        public string? QuestionEn { get; set; }
        public string? QuestionFr { get; set; }
        public string? ProposalAEn { get; set; }
        public string? ProposalAFr { get; set; }
        public string? ProposalBEn { get; set; }
        public string? ProposalBFr { get; set; }
        public string? Notation { get; set; }
        public string? DifficultyName { get; set; }

    }
}
