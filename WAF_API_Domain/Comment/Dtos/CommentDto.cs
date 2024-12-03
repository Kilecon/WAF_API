﻿using WAF_API_Domain.Models;

namespace WAF_API_Domain.Comment.Dtos;

public class CommentDto : Dto
{
    public string? Sentence { get; set; }
    public string? Description { get; set; }
}
