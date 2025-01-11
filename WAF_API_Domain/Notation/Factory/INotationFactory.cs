using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Dare.Entities;
using WAF_API_Domain.Notation.Commands;
using WAF_API_Domain.Notation.Entities;

namespace WAF_API_Domain.Notation.Factory
{
    public interface INotationFactory
    {
        public NotationAr CreateIntance(CreateNotationCmd cmd, string id);
        public NotationAr UpdateIntance(UpdateNotationCmd cmd);
    }
}
