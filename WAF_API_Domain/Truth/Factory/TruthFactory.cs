using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Truth.Commands;
using WAF_API_Domain.Truth.Entities;
using WAF_API_Domain.ValueObject;
using WAF_API_Exceptions.ApplicationExceptions;

namespace WAF_API_Domain.Truth.Factory
{
    public class TruthFactory : ITruthFactory
    {
        public TruthAr CreateIntance(CreateTruthCmd cmd, string id)
        {
            try
            {
                return new TruthAr(new Id(id), new QuestionEn(cmd.QuestionEn), new QuestionFr(cmd.QuestionFr));

            }
            catch (Exception)
            {
                throw new InvalidCastException($"\"{typeof(CreateTruthCmd)}\" Command is Invalid");
            }
        }

        public TruthAr UpdateIntance(UpdateTruthCmd cmd)
        {
            try
            {
                return new TruthAr(new Id(cmd.Id), new QuestionEn(cmd.QuestionEn), new QuestionFr(cmd.QuestionFr), new Notation(cmd.Rating));

            }
            catch (InvalidIdException)
            {
                throw new InvalidIdException();
            }
            catch (Exception)
            {
                throw new InvalidCastException($"\"{typeof(UpdateTruthCmd)}\" Command is Invalid");
            }
        }
    }
}
