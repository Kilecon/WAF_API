using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.WouldYouRather.Entities;
using WAF_API_Domain.WouldYouRather.Commands;


namespace WAF_API_Domain.WouldYouRather.Factory
{
    public interface IWouldYouRatherFactory
    {
        /// <summary>
        /// The CreateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="CreateWouldYouRatherCmd"/></param>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="WouldYouRatherAr"/></returns>
        WouldYouRatherAr CreateIntance(CreateWouldYouRatherCmd cmd, string id);

        /// <summary>
        /// The UpdateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="UpdateWouldYouRatherCmd"/></param>
        /// <returns>The <see cref="WouldYouRatherAr"/></returns>
        WouldYouRatherAr UpdateIntance(UpdateWouldYouRatherCmd cmd);
    }
}
