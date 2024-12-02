namespace WAF_API_Domain.Note.Factory
{
    using WAF_API_Domain.Note.Commands;
    using WAF_API_Domain.Note.Entities;
    using WAF_API_Domain.Note.ValueObject;
    using WAF_API_Domain.ValueObject;
    using WAF_API_Exceptions.ApplicationExceptions;
    using System;

    /// <summary>
    /// Defines the <see cref="ChallengeFactory" />
    /// </summary>
    public class ChallengeFactory : IChallengeFactory
    {
        /// <summary>
        /// The CreateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="CreateChallengeCmd"/></param>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="ChallengeAr"/></returns>
        public ChallengeAr CreateIntance(CreateChallengeCmd cmd, string id)
        {
            try
            {
                return new ChallengeAr(new Id(id), new Title(cmd.Title), new Description(cmd.Description));

            }
            catch (Exception)
            {
                throw new InvalidCastException($"\"{typeof(CreateChallengeCmd)}\" Command is Invalid");
            }
        }

        /// <summary>
        /// The UpdateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="UpdateChallengeCmd"/></param>
        /// <returns>The <see cref="ChallengeAr"/></returns>
        public ChallengeAr UpdateIntance(UpdateChallengeCmd cmd)
        {
            try
            {
                return new ChallengeAr(new Id(cmd.Id), new Title(cmd.Title), new Description(cmd.Description), new IsChecked(cmd.IsChecked));

            }
            catch (InvalidIdException)
            {
                throw new InvalidIdException();
            }
            catch (Exception)
            {
                throw new InvalidCastException($"\"{typeof(UpdateChallengeCmd)}\" Command is Invalid");
            }
        }
    }
}
