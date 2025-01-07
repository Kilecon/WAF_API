using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Dare.Commands;
using WAF_API_Domain.Dare.Entities;
using WAF_API_Domain.Ranking.Commands;
using WAF_API_Domain.Ranking.Entities;
using WAF_API_Domain.Ranking.ValueObject;
using WAF_API_Domain.ValueObject;
using WAF_API_Exceptions.ApplicationExceptions;

namespace WAF_API_Domain.Ranking.Factory
{
    public class RankingFactory : IRankingFactory
    {
        public RankingAr CreateIntance(CreateRankingCmd cmd, string id)
        {
            try
            {
                return new RankingAr(new Id(id), new Id(cmd.QuestionId), new QuestionTypeName(cmd.QuestionTypeName),
                    new IsLiked(cmd.IsLiked));

            }
            catch (Exception)
            {
                throw new InvalidCastException($"\"{typeof(CreateRankingCmd)}\" Command is Invalid");
            }
        }

        public RankingAr UpdateIntance(UpdateRankingCmd cmd)
        {
            try
            {
                return new RankingAr(new Id(cmd.Id), new Id(cmd.QuestionId) ,
                    new QuestionTypeName(cmd.QuestionTypeName), new IsLiked(cmd.IsLiked));

            }
            catch (InvalidIdException)
            {
                throw new InvalidIdException();
            }
            catch (Exception)
            {
                throw new InvalidCastException($"\"{typeof(UpdateRankingCmd)}\" Command is Invalid");
            }
        }
    }
}
