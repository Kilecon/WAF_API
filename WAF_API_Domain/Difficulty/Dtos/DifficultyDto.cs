using WAF_API_Domain.Models;

namespace WAF_API_Domain.Difficulty.Dtos;

public class DifficultyDto : Dto
{
    public string? DifficultyName { get; set; }
    public string? DifficultyNotation { get; set; }
    public string? DareNotation { get; set; }
    public string? TruthNotation { get; set; }
    public string? NeverHaveIEverNotation { get; set; }
    public string? ParanoiaNotation { get; set; }
    public string? WouldYouRatherNotation { get; set; }
    
}