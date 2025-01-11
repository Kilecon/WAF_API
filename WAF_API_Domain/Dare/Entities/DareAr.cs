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
        public Mark Notation { get; private set; }
        public DifficultyName DifficultyName { get; private set; }

        public DareAr(Id id, QuestionEn questionEn, QuestionFr questionFr, DifficultyName difficultyName)
        {
            Id = id;
            QuestionFr = questionFr;
            QuestionEn = questionEn;
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
            Notation = new Mark();
            DifficultyName = difficultyName;
        }

        public DareAr(Id id, QuestionEn questionEn, QuestionFr questionFr, Mark mark, DifficultyName difficultyName)
        {
            Id = id;
            QuestionFr = questionFr;
            QuestionEn = questionEn;
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
            Notation = mark;
            DifficultyName = difficultyName;
        }

        public DareDto ToDto()
        {
            return new DareDto
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
