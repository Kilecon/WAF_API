using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Dare.Commands;
using WAF_API_Domain.Dare.Entities;
using WAF_API_Domain.ValueObject;
using WAF_API_Exceptions.ApplicationExceptions;

namespace WAF_API_Domain.Dare.Factory
{
    public class DareFactory : IDareFactory
    {
        public DareAr CreateIntance(CreateDareCmd cmd, string id)
        {
            try
            {
                return new DareAr(new Id(id), new QuestionEn(cmd.QuestionEn), new QuestionFr(cmd.QuestionFr), new ValueObject.DifficultyName(cmd.DifficultyName));

            }
            catch (Exception)
            {
                throw new InvalidCastException($"\"{typeof(CreateDareCmd)}\" Command is Invalid");
            }
        }

        public DareAr UpdateIntance(UpdateDareCmd cmd)
        {
            try
            {
                return new DareAr(new Id(cmd.Id), new QuestionEn(cmd.QuestionEn), new QuestionFr(cmd.QuestionFr), new Mark(cmd.Notation), new ValueObject.DifficultyName(cmd.DifficultyName));

            }
            catch (InvalidIdException)
            {
                throw new InvalidIdException();
            }
            catch (Exception)
            {
                throw new InvalidCastException($"\"{typeof(UpdateDareCmd)}\" Command is Invalid");
            }
        }
    }
}
