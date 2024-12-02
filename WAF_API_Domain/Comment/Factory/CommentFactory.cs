namespace WAF_API_Domain.Comment.Factory
{
    using WAF_API_Domain.Comment.Commands;
    using WAF_API_Domain.Comment.Entities;
    using WAF_API_Domain.Comment.ValueObject;
    using WAF_API_Domain.ValueObject;
    using WAF_API_Exceptions.ApplicationExceptions;
    using WAF_API_Exceptions.DomainExceptions;
    using System;

    /// <summary>
    /// Defines the <see cref="CommentFactory" />
    /// </summary>
    public class CommentFactory : ICommentFactory
    {
        /// <summary>
        /// The CreateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="CreateCommentCmd"/></param>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="CommentAr"/></returns>
        public CommentAr CreateIntance(CreateCommentCmd cmd, string id)
        {
            try
            {
                return new CommentAr(new Id(id), new Title(cmd.Title), new Description(cmd.Description));

            }
            catch (Exception)
            {
                throw new InvalidCommandException($"\"{typeof(CreateCommentCmd).Name}\" Command is Invalid");
            }
        }

        /// <summary>
        /// The UpdateIntance
        /// </summary>
        /// <param name="cmd">The cmd<see cref="UpdateCommentCmd"/></param>
        /// <returns>The <see cref="CommentAr"/></returns>
        public CommentAr UpdateIntance(UpdateCommentCmd cmd)
        {
            try
            {
                return new CommentAr(new Id(cmd.Id), new Title(cmd.Title), new Description(cmd.Description));

            }
            catch (InvalidIdException)
            {
                throw new InvalidIdException();
            }
            catch (Exception)
            {
                throw new InvalidCommandException($"\"{typeof(UpdateCommentCmd).Name}\" Command is Invalid");
            }
        }
    }
}
