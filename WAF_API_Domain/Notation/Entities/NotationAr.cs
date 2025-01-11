using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Notation.Dtos;
using WAF_API_Domain.Notation.ValueObject;
using WAF_API_Domain.ValueObject;

namespace WAF_API_Domain.Notation.Entities
{
    public class NotationAr
    {
        public Id Id { get; private set; }
        public LastUpdateUnixTimestamp LastUpdateUnixTimestamp { get; private set; }
        public Id QuestionId { get; private set; }
        public QuestionTypeName QuestionTypeName { get; private set; }
        public IsLiked IsLiked { get; private set; }
        public NotationAr(Id id, Id questionId, QuestionTypeName questionTypeName, IsLiked isLiked)
        {
            Id = id;
            QuestionId = questionId;
            QuestionTypeName = questionTypeName;
            IsLiked = isLiked;
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
        }

        public NotationDto ToDto()
        {
            return new NotationDto
            {
                Id = Id.Value,
                QuestionId = QuestionId.Value,
                QuestionTypeName = QuestionTypeName.Value,
                IsLiked = IsLiked.Value,
                LastUpdateUnixTimestamp = LastUpdateUnixTimestamp.Value
            };
        }
    }
}
