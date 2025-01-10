using WAF_API_Domain.Commands;

namespace WAF_API_Domain.Difficulty.Commands;

public class CreateDifficultyCmd : Cmd
{
        public string? DifficultyName { get; set; }

}