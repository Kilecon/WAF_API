using WAF_API_Domain.Difficulty.Commands;
using WAF_API_Domain.Difficulty.Entities;

namespace WAF_API_Domain.Difficulty.Factory
{
    public interface IDifficultyFactory
{
    /// <summary>
        /// The CreateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="CreateDifficultyCmd"/></param>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="DifficultyAr"/></returns>
        DifficultyAr CreateIntance(CreateDifficultyCmd cmd, string id);

        /// <summary>
        /// The UpdateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="UpdateDifficultyCmd"/></param>
        /// <returns>The <see cref="DifficultyAr"/></returns>
        DifficultyAr UpdateIntance(UpdateDifficultyCmd cmd);
    }
}


