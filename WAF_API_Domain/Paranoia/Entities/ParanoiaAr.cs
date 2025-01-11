using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Paranoia.Dtos;
using WAF_API_Domain.Suggestion.Dtos;
using WAF_API_Domain.ValueObject;

namespace WAF_API_Domain.Paranoia.Entities
{
    public class ParanoiaAr
    {
        public Id Id { get; private set; }
        public LastUpdateUnixTimestamp LastUpdateUnixTimestamp { get; private set; }
        public QuestionEn QuestionEn { get; private set; }
        public QuestionFr QuestionFr { get; private set; }
        public Mark Notation{ get; private set; }
        
        public DifficultyName DifficultyName { get; set; }

        public ParanoiaAr(Id id, QuestionEn questionEn, QuestionFr questionFr, DifficultyName difficultyName) 
        {
            Id = id;
            QuestionFr = questionFr;
            QuestionEn = questionEn;
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
            Notation = new Mark();
            DifficultyName = difficultyName;
        }

        public ParanoiaAr(Id id, QuestionEn questionEn, QuestionFr questionFr, Mark mark, DifficultyName difficultyName)
        {
            Id = id;
            QuestionFr = questionFr;
            QuestionEn = questionEn;
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
            Notation = mark;
            DifficultyName = difficultyName;
        }

        public ParanoiaDto ToDto()
        {
            return new ParanoiaDto()
            {
                Id = Id.Value,
                QuestionEn = QuestionEn.Value,
                QuestionFr = QuestionFr.Value,
                Notation = Notation.Value,
                DifficultyName = DifficultyName.Value,
                LastUpdateUnixTimestamp = LastUpdateUnixTimestamp.Value
            };
        }
    }
}
