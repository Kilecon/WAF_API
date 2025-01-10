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
                return new DareAr(new Id(id), new QuestionEn(cmd.QuestionEn), new QuestionFr(cmd.QuestionFr), new DifficultyName(cmd.Difficulty));

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
                return new DareAr(new Id(cmd.Id), new QuestionEn(cmd.QuestionEn), new QuestionFr(cmd.QuestionFr), new Notation(cmd.Rating), new DifficultyName(cmd.Difficulty));

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
