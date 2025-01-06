using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.NeverHaveIEver.Commands;
using WAF_API_Domain.NeverHaveIEver.Entities;

namespace WAF_API_Domain.NeverHaveIEver.Factory
{
    public interface INeverHaveIEverFactory
    {
        /// <summary>
        /// The CreateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="CreateNeverHaveIEverCmd"/></param>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="NeverHaveIEverAr"/></returns>
        NeverHaveIEverAr CreateIntance(CreateNeverHaveIEverCmd cmd, string id);

        /// <summary>
        /// The UpdateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="UpdateNeverHaveIEverCmd"/></param>
        /// <returns>The <see cref="NeverHaveIEverAr"/></returns>
        NeverHaveIEverAr UpdateIntance(UpdateNeverHaveIEverCmd cmd);
    }
}
