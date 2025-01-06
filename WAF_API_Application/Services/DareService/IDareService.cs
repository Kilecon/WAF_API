using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Dare.Commands;
using WAF_API_Domain.Dare.Dtos;

namespace WAF_API_Application.Services.DareService
{
    public interface IDareService : IService<DareDto, CreateDareCmd, UpdateDareCmd>
    {
        Task UpdateAsync(UpdateDareCmd note);
    }
}
