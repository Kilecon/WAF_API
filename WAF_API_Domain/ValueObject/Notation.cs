using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAF_API_Domain.ValueObject
{
    public class Notation
    {
        public string? Value { get; private set; }
        public Notation()
        {
            Value = null;
        }
        public Notation(string? value)
        {
            // Sécuriser l'input
            Value = value;
        }
    }
}
