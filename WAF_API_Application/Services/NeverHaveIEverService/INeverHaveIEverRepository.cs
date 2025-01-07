using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.NeverHaveIEver.Dtos;
using WAF_API_Domain.WouldYouRather.Dtos;

namespace WAF_API_Application.Services.NeverHaveIEverService
{
    public interface INeverHaveIEverRepository : IBaseRepository<NeverHaveIEverDto>
    {
    }
}
