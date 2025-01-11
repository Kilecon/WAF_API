using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Paranoia.Commands;
using WAF_API_Domain.Paranoia.Dtos;

namespace WAF_API_Application.Services.ParanoiaService
{
    public interface IParanoiaService : IService<ParanoiaDto, CreateParanoiaCmd, UpdateParanoiaCmd>
    {
        Task UpdateAsync(UpdateParanoiaCmd note);

    }
}
