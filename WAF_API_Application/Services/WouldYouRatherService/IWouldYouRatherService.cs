using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.WouldYouRather.Commands;
using WAF_API_Domain.WouldYouRather.Dtos;

namespace WAF_API_Application.Services.WouldYouRatherService
{
    public interface IWouldYouRatherService : IService<WouldYouRatherDto, CreateWouldYouRatherCmd, UpdateWouldYouRatherCmd>
    {
        Task UpdateAsync(UpdateWouldYouRatherCmd note);
    }
}
