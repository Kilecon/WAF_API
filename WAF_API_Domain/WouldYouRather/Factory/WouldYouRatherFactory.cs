using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.WouldYouRather.Commands;
using WAF_API_Domain.WouldYouRather.Entities;
using WAF_API_Domain.ValueObject;
using WAF_API_Exceptions.ApplicationExceptions;

namespace WAF_API_Domain.WouldYouRather.Factory
{           
    public class WouldYouRatherFactory : IWouldYouRatherFactory
    {
        public WouldYouRatherAr CreateIntance(CreateWouldYouRatherCmd cmd, string id)
        {
            try
            {
                return new WouldYouRatherAr(new Id(id), new QuestionEn(cmd.QuestionEn), new QuestionFr(cmd.QuestionFr), new ProposalAEn(cmd.ProposalAEn), new ProposalAFr(cmd.ProposalAFr), new ProposalBEn(cmd.ProposalBEn), new ProposalBFr(cmd.ProposalBFr), new DifficultyName(cmd.DifficultyName));

            }
            catch (Exception)
            {
                throw new InvalidCastException($"\"{typeof(CreateWouldYouRatherCmd)}\" Command is Invalid");
            }
        }

        public WouldYouRatherAr UpdateIntance(UpdateWouldYouRatherCmd cmd)
        {
            try
            {
                return new WouldYouRatherAr(new Id(cmd.Id), new QuestionEn(cmd.QuestionEn), new QuestionFr(cmd.QuestionFr), new ProposalAEn(cmd.ProposalAEn), new ProposalAFr(cmd.ProposalAFr), new ProposalBEn(cmd.ProposalBEn), new ProposalBFr(cmd.ProposalBFr), new Mark(cmd.Notation), new DifficultyName(cmd.DifficultyName));

            }
            catch (InvalidIdException)
            {
                throw new InvalidIdException();
            }
            catch (Exception)
            {
                throw new InvalidCastException($"\"{typeof(UpdateWouldYouRatherCmd)}\" Command is Invalid");
            }
        }
    }
}
