using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Paranoia.Dtos;


namespace WAF_API_Application.Services.ParanoiaService
{
    public interface IParanoiaRepository : IBaseRepository<ParanoiaDto>
    {
    }
}
