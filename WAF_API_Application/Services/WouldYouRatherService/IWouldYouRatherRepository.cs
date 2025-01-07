using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.WouldYouRather.Dtos;

namespace WAF_API_Application.Services.WouldYouRatherService
{
    public interface IWouldYouRatherRepository : IBaseRepository<WouldYouRatherDto>
    {
    }
}
