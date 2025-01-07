using System;
using System.Collections.Generic;
using System.Linq;
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
        public Notation Rating { get; private set; }
        public WouldYouRatherAr(Id id, QuestionEn questionEn, QuestionFr questionFr, ProposalAEn proposalAEn, ProposalAFr proposalAFr, ProposalBEn proposalBEn, ProposalBFr proposalBFr)
        {
            Id = id;
            QuestionFr = questionFr;
            QuestionEn = questionEn;
            ProposalAFr = proposalAFr;
            ProposalAEn = proposalAEn;
            ProposalBFr = proposalBFr;
            ProposalBEn = proposalBEn;
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
            Rating = new Notation();
        }

        public WouldYouRatherAr(Id id, QuestionEn questionEn, QuestionFr questionFr, ProposalAEn proposalAEn, ProposalAFr proposalAFr, ProposalBEn proposalBEn, ProposalBFr proposalBFr, Notation rating)
        {
            Id = id;
            QuestionFr = questionFr;
            QuestionEn = questionEn;
            ProposalAFr = proposalAFr;
            ProposalAEn = proposalAEn;
            ProposalBFr = proposalBFr;
            ProposalBEn = proposalBEn;
            LastUpdateUnixTimestamp = new LastUpdateUnixTimestamp();
            Rating = rating;
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
                Rating = Rating.Value,
                LastUpdateUnixTimestamp = LastUpdateUnixTimestamp.Value
            };
        }
    }
}
