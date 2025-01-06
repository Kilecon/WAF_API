using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.NeverHaveIEver.Commands;
using WAF_API_Domain.NeverHaveIEver.Dtos;

namespace WAF_API_Application.Services.NeverHaveIEverService
{
    public interface INeverHaveIEverService :  IService<NeverHaveIEverDto, CreateNeverHaveIEverCmd, UpdateNeverHaveIEverCmd>
    {
        Task UpdateAsync(UpdateNeverHaveIEverCmd note);

    }
}
