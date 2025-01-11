using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.WouldYouRather.Dtos;
using WAF_API_Domain.ValueObject;

namespace WAF_API_Domain.WouldYouRather.Entities
{
    public class WouldYouRatherAr
    {
        public Id Id { get; private set; }
        public LastUpdateUnixTimestamp LastUpdateUnixTimestamp { get; private set; }
        public QuestionEn QuestionEn { get; private set; }
        public QuestionFr QuestionFr { get; private set; }
        public ProposalAEn ProposalAEn { get; private set; }
        public ProposalAFr ProposalAFr { get; private set; }
        public ProposalBEn ProposalBEn { get; private set; }
        public ProposalBFr ProposalBFr { get; private set; }
        public Mark Notation { get; private set; }
        public DifficultyName DifficultyName { get; private set; }
        public WouldYouRatherAr(Id id, QuestionEn questionEn, QuestionFr questionFr, ProposalAEn proposalAEn, ProposalAFr proposalAFr, ProposalBEn proposalBEn, ProposalBFr proposalBFr, DifficultyName difficultyName)
        {
            Id = id;
            QuestionFr = questionFr;
            QuestionEn = questionEn;
            ProposalAFr = proposalAFr;
            ProposalAEn = proposalAEn;
            ProposalBFr = proposalBFr;
            ProposalBEn = proposalBEn;
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
            Notation = new Mark();
            DifficultyName = difficultyName;
        }

        public WouldYouRatherAr(Id id, QuestionEn questionEn, QuestionFr questionFr, ProposalAEn proposalAEn, ProposalAFr proposalAFr, ProposalBEn proposalBEn, ProposalBFr proposalBFr, Mark mark, DifficultyName difficultyName)
        {
            Id = id;
            QuestionFr = questionFr;
            QuestionEn = questionEn;
            ProposalAFr = proposalAFr;
            ProposalAEn = proposalAEn;
            ProposalBFr = proposalBFr;
            ProposalBEn = proposalBEn;
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
            Notation = mark;
            DifficultyName = difficultyName;
        }

        public WouldYouRatherDto ToDto()
        {
            return new WouldYouRatherDto
            {
                Id = Id.Value,
                QuestionEn = QuestionEn.Value,
                QuestionFr = QuestionFr.Value,
                ProposalAFr = ProposalAFr.Value,
                ProposalAEn = ProposalAEn.Value,
                ProposalBFr = ProposalBFr.Value,
                ProposalBEn = ProposalBEn.Value,
                Notation = Notation.Value,
                DifficultyName = DifficultyName.Value,
                LastUpdateUnixTimestamp = LastUpdateUnixTimestamp.Value
            };
        }
    }
}
