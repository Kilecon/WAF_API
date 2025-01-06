using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Paranoia.Dtos;
using WAF_API_Domain.ValueObject;

namespace WAF_API_Domain.Paranoia.Entities
{
    public class ParanoiaAr
    {
        public Id Id { get; private set; }
        public LastUpdateUnixTimestamp LastUpdateUnixTimestamp { get; private set; }
        public QuestionEn QuestionEn { get; private set; }
        public QuestionFr QuestionFr { get; private set; }
        public Notation Rating { get; private set; }
        public ParanoiaAr(Id id, QuestionEn questionEn, QuestionFr questionFr) 
        {
            Id = id;
            QuestionFr = questionFr;
            QuestionEn = questionEn;
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
            Rating = new Notation();
        }

        public ParanoiaAr(Id id, QuestionEn questionEn, QuestionFr questionFr, Notation rating)
        {
            Id = id;
            QuestionFr = questionFr;
            QuestionEn = questionEn;
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
            Rating = rating;
        }

        public ParanoiaDto ToDto()
        {
            return new ParanoiaDto()
            {
                Id = Id.Value,
                QuestionEn = QuestionEn.Value,
                QuestionFr = QuestionFr.Value,
                Rating = Rating.Value,
                LastUpdateUnixTimestamp = LastUpdateUnixTimestamp.Value
            };
        }
    }
}
