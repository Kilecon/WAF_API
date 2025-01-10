using System.ComponentModel.Design;
using System.Threading.Tasks;
using WAF_API_Domain.Difficulty.Commands;
using WAF_API_Domain.Difficulty.Dtos;

namespace WAF_API_Application.Services.Difficulty;

public interface IDifficultyService : IService<DifficultyDto, CreateDifficultyCmd, UpdateDifficultyCmd>
{ 
    Task UpdateAsync(UpdateDifficultyCmd note);

}