using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Paranoia.Commands;
using WAF_API_Domain.Paranoia.Entities;
using WAF_API_Domain.ValueObject;
using WAF_API_Exceptions.ApplicationExceptions;

namespace WAF_API_Domain.Paranoia.Factory
{
    public class ParanoiaFactory : IParanoiaFactory
    {
        public ParanoiaAr CreateIntance(CreateParanoiaCmd cmd, string id)
        {
            try
            {
                return new ParanoiaAr(new Id(id), new QuestionEn(cmd.QuestionEn), new QuestionFr(cmd.QuestionFr));

            }
            catch (Exception)
            {
                throw new InvalidCastException($"\"{typeof(CreateParanoiaCmd)}\" Command is Invalid");
            }
        }

        public ParanoiaAr UpdateIntance(UpdateParanoiaCmd cmd)
        {
            try
            {
                return new ParanoiaAr(new Id(cmd.Id), new QuestionEn(cmd.QuestionEn), new QuestionFr(cmd.QuestionFr), new Notation(cmd.Rating));

            }
            catch (InvalidIdException)
            {
                throw new InvalidIdException();
            }
            catch (Exception)
            {
                throw new InvalidCastException($"\"{typeof(UpdateParanoiaCmd)}\" Command is Invalid");
            }
        }
    }
}
