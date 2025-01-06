using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Dare.Commands;
using WAF_API_Domain.Dare.Entities;

namespace WAF_API_Domain.Dare.Factory
{
    public interface IDareFactory
    {
        /// <summary>
        /// The CreateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="CreateDareCmd"/></param>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="DareAr"/></returns>
        DareAr CreateIntance(CreateDareCmd cmd, string id);

        /// <summary>
        /// The UpdateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="UpdateDareCmd"/></param>
        /// <returns>The <see cref="DareAr"/></returns>
        DareAr UpdateIntance(UpdateDareCmd cmd);
    }
}
