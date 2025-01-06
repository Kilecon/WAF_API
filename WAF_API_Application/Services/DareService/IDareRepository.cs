using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Dare.Dtos;

namespace WAF_API_Application.Services.DareService
{
    public interface IDareRepository : IBaseRepository<DareDto>
    {
    }
}
