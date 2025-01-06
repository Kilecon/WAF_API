using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Paranoia.Commands;
using WAF_API_Domain.Paranoia.Entities;

namespace WAF_API_Domain.Paranoia.Factory
{
    public interface IParanoiaFactory
    {
        /// <summary>
        /// The CreateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="CreateParanoiaCmd"/></param>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="ParanoiaAr"/></returns>
        ParanoiaAr CreateIntance(CreateParanoiaCmd cmd, string id);

        /// <summary>
        /// The UpdateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="UpdateParanoiaCmd"/></param>
        /// <returns>The <see cref="ParanoiaAr"/></returns>
        ParanoiaAr UpdateIntance(UpdateParanoiaCmd cmd);
    }
}
