using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAF_API_Domain.Difficulty.Commands;
using WAF_API_Domain.Difficulty.Entities;
using WAF_API_Domain.Difficulty.Factory;
using WAF_API_Domain.ValueObject;
using WAF_API_Exceptions.ApplicationExceptions;

namespace WAF_API_Domain.Dare.Factory
{
    public class DifficultyFactory : IDifficultyFactory
    {
        public DifficultyAr CreateIntance(CreateDifficultyCmd cmd, string id)
        {
            try
            {
                return new DifficultyAr(new Id(id), new ValueObject.DifficultyName(cmd.DifficultyName));

            }
            catch (Exception)
            {
                throw new InvalidCastException($"\"{typeof(CreateDifficultyCmd)}\" Command is Invalid");
            }
        }

        public DifficultyAr UpdateIntance(UpdateDifficultyCmd cmd)
        {
            try
            {
                return new DifficultyAr(
                    new Id(cmd.Id), 
                    new ValueObject.DifficultyName(cmd.DifficultyName), 
                    new Mark(cmd.DifficultyNotation), 
                    new Mark(cmd.DareNotation), 
                    new Mark(cmd.TruthNotation), 
                    new Mark(cmd.NeverHaveIEverNotation),
                    new Mark(cmd.ParanoiaNotation),
                    new Mark(cmd.WouldYouRatherNotation));
            }
            catch (InvalidIdException)
            {
                throw new InvalidIdException();
            }
            catch (Exception)
            {
                throw new InvalidCastException($"\"{typeof(UpdateDifficultyCmd)}\" Command is Invalid");
            }
        }
    }
}
