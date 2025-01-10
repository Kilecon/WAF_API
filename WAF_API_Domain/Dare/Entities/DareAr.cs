using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Dare.Dtos;
using WAF_API_Domain.ValueObject;

namespace WAF_API_Domain.Dare.Entities
{
    public class DareAr
    {
        public Id Id { get; private set; }
        public LastUpdateUnixTimestamp LastUpdateUnixTimestamp { get; private set; }
        public QuestionEn QuestionEn { get; private set; }
        public QuestionFr QuestionFr { get; private set; }
        public Notation Rating { get; private set; }
        public DifficultyName DifficultyName { get; private set; }
        public DareAr(Id id, QuestionEn questionEn, QuestionFr questionFr, DifficultyName difficulty) 
        {
            Id = id;
            QuestionFr = questionFr;
            QuestionEn = questionEn;
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
            Rating = new Notation();
            DifficultyName = difficulty;
        }

        public DareAr(Id id, QuestionEn questionEn, QuestionFr questionFr, Notation rating, DifficultyName difficulty)
        {
            Id = id;
            QuestionFr = questionFr;
            QuestionEn = questionEn;
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
            Rating = rating;
            DifficultyName = difficulty;
        }

        public DareDto ToDto()
        {
            return new DareDto
            {
                Id = Id.Value,
                QuestionEn = QuestionEn.Value,
                QuestionFr = QuestionFr.Value,
                Rating = Rating.Value,
                DifficultyName = DifficultyName.Value,
                LastUpdateUnixTimestamp = LastUpdateUnixTimestamp.Value
            };
        }
    }
}