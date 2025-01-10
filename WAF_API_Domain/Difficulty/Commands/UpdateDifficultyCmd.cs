using WAF_API_Domain.Commands;

namespace WAF_API_Domain.Difficulty.Commands;

public class UpdateDifficultyCmd : IdCmd
{
    public string? DifficultyName { get; set; }
    public string? DifficultyNotation { get; set; }
    public string? DareNotation { get; set; }
    public string? TruthNotation { get; set; }
    public string? NeverHaveIEverNotation { get; set; }
    public string? ParanoiaNotation { get; set; }
    public string? WouldYouRatherNotation { get; set; }
}