namespace WAF_API_Domain.Note.Factory
{
    using WAF_API_Domain.Note.Commands;
    using WAF_API_Domain.Note.Entities;

    /// <summary>
    /// Defines the <see cref="IChallengeFactory" />
    /// </summary>
    public interface IChallengeFactory
    {
        /// <summary>
        /// The CreateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="CreateChallengeCmd"/></param>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="ChallengeAr"/></returns>
        ChallengeAr CreateIntance(CreateChallengeCmd cmd, string id);

        /// <summary>
        /// The UpdateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="UpdateChallengeCmd"/></param>
        /// <returns>The <see cref="ChallengeAr"/></returns>
        ChallengeAr UpdateIntance(UpdateChallengeCmd cmd);
    }
}
