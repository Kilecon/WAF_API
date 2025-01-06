using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.NeverHaveIEver.Commands;
using WAF_API_Domain.NeverHaveIEver.Entities;
using WAF_API_Domain.ValueObject;
using WAF_API_Exceptions.ApplicationExceptions;

namespace WAF_API_Domain.NeverHaveIEver.Factory
{
    public class NeverHaveIEverFactory : INeverHaveIEverFactory
    {
        public NeverHaveIEverAr CreateIntance(CreateNeverHaveIEverCmd cmd, string id)
        {
            try
            {
                return new NeverHaveIEverAr(new Id(id), new QuestionEn(cmd.QuestionEn), new QuestionFr(cmd.QuestionFr));

            }
            catch (Exception)
            {
                throw new InvalidCastException($"\"{typeof(CreateNeverHaveIEverCmd)}\" Command is Invalid");
            }
        }

        public NeverHaveIEverAr UpdateIntance(UpdateNeverHaveIEverCmd cmd)
        {
            try
            {
                return new NeverHaveIEverAr(new Id(cmd.Id), new QuestionEn(cmd.QuestionEn), new QuestionFr(cmd.QuestionFr), new Notation(cmd.Rating));

            }
            catch (InvalidIdException)
            {
                throw new InvalidIdException();
            }
            catch (Exception)
            {
                throw new InvalidCastException($"\"{typeof(UpdateNeverHaveIEverCmd)}\" Command is Invalid");
            }
        }
    }
}
