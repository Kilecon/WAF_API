using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Truth.Commands;
using WAF_API_Domain.Truth.Dtos;

namespace WAF_API_Application.Services.TruthService
{
    public interface ITruthService : IService<TruthDto, CreateTruthCmd, UpdateTruthCmd>
    {
        Task UpdateAsync(UpdateTruthCmd note);
    }
}
