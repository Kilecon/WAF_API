using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Dare.Commands;
using WAF_API_Domain.Dare.Entities;
using WAF_API_Domain.Notation.Commands;
using WAF_API_Domain.Notation.Entities;
using WAF_API_Domain.Notation.ValueObject;
using WAF_API_Domain.ValueObject;
using WAF_API_Exceptions.ApplicationExceptions;

namespace WAF_API_Domain.Notation.Factory
{
    public class NotationFactory : INotationFactory
    {
        public NotationAr CreateIntance(CreateNotationCmd cmd, string id)
        {
            try
            {
                return new NotationAr(new Id(id), new Id(cmd.QuestionId), new QuestionTypeName(cmd.QuestionTypeName),
                    new IsLiked(cmd.IsLiked));

            }
            catch (Exception)
            {
                throw new InvalidCastException($"\"{typeof(CreateNotationCmd)}\" Command is Invalid");
            }
        }

        public NotationAr UpdateIntance(UpdateNotationCmd cmd)
        {
            try
            {
                return new NotationAr(new Id(cmd.Id), new Id(cmd.QuestionId) ,
                    new QuestionTypeName(cmd.QuestionTypeName), new IsLiked(cmd.IsLiked));

            }
            catch (InvalidIdException)
            {
                throw new InvalidIdException();
            }
            catch (Exception)
            {
                throw new InvalidCastException($"\"{typeof(UpdateNotationCmd)}\" Command is Invalid");
            }
        }
    }
}
