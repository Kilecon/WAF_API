using WAF_API_Domain.Models;

namespace WAF_API_Domain.Rating.Dtos;

public class RatingDto : Dto
{
    public string? SentenceId { get; set; }
    public decimal Rating { get; set; }
}
