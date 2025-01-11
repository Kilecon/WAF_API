using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Models;

namespace WAF_API_Domain.Dare.Dtos
{
    public class DareDto : Dto
    {
        public string? QuestionEn { get; set; }
        public string? QuestionFr { get; set; }
        public string? Notation { get; set; }
        public string? DifficultyName { get; set; }
    }
}
