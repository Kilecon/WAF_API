namespace WAF_API_Domain.Rating.Factory
{
    using WAF_API_Domain.Rating.Commands;
    using WAF_API_Domain.Rating.Entities;
    using WAF_API_Domain.Rating.ValueObject;
    using WAF_API_Domain.ValueObject;
    using WAF_API_Exceptions.ApplicationExceptions;
    using WAF_API_Exceptions.DomainExceptions;
    using System;

    /// <summary>
    /// Defines the <see cref="RatingFactory" />
    /// </summary>
    public class RatingFactory : IRatingFactory
    {
        /// <summary>
        /// The CreateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="CreateRatingCmd"/></param>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="RatingAr"/></returns>
        public RatingAr CreateIntance(CreateRatingCmd cmd, string id)
        {
            try
            {
                return new RatingAr(new Id(id), new Id(cmd.SentenceId), new Rating(cmd.Rating));

            }
            catch (Exception)
            {
                throw new InvalidCommandException($"\"{typeof(CreateRatingCmd).Name}\" Command is Invalid");
            }
        }

        /// <summary>
        /// The UpdateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="UpdateRatingCmd"/></param>
        /// <returns>The <see cref="RatingAr"/></returns>
        public RatingAr UpdateIntance(UpdateRatingCmd cmd)
        {
            try
            {
                return new RatingAr(new Id(cmd.Id), new Id(cmd.SentenceId), new Rating(cmd.Rating));

            }
            catch (InvalidIdException)
            {
                throw new InvalidIdException();
            }
            catch (Exception)
            {
                throw new InvalidCommandException($"\"{typeof(UpdateRatingCmd).Name}\" Command is Invalid");
            }
        }
    }
}
