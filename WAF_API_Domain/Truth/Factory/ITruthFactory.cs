using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Truth.Commands;
using WAF_API_Domain.Truth.Entities;

namespace WAF_API_Domain.Truth.Factory
{
    public interface ITruthFactory
    {
        /// <summary>
        /// The CreateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="CreateTruthCmd"/></param>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="TruthAr"/></returns>
        TruthAr CreateIntance(CreateTruthCmd cmd, string id);

        /// <summary>
        /// The UpdateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="UpdateTruthCmd"/></param>
        /// <returns>The <see cref="TruthAr"/></returns>
        TruthAr UpdateIntance(UpdateTruthCmd cmd);
    }
}
