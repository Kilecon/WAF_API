﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Commands;

namespace WAF_API_Domain.Dare.Commands
{
    public class CreateDareCmd : Cmd
    {
        public string? QuestionEn { get; set; }
        public string? QuestionFr { get; set; }
        
        public string? DifficultyName { get; set; }
    }
}
