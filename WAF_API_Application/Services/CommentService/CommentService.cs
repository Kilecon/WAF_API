namespace WAF_API_Application.Services.CommentService
{
    using WAF_API_Domain.Comment.Commands;
    using WAF_API_Domain.Comment.Dtos;
    using WAF_API_Domain.Comment.Factory;
    using System.Threading.Tasks;
    using WAF_API_Application.Services;

    /// <summary>
    /// Defines the <see cref="CommentService" />
    /// </summary>
    public class CommentService : BaseService<CommentDto, CreateCommentCmd, UpdateCommentCmd>, ICommentService
    {
        /// <summary>
        /// Defines the _factory
        /// </summary>
        private ICommentFactory _factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentService"/> class.
        /// </summary>
        /// <param name="factory">The factory<see cref="ICommentFactory"/></param>
        /// <param name="repo">The repo<see cref="IBaseRepository{CommentDto}"/></param>
        public CommentService(ICommentFactory factory, IBaseRepository<CommentDto> repo) : base(repo)
        {
            _factory = factory;
        }

        /// <summary>
        /// The CreateSpecificAsync
        /// </summary>
        /// <param name="cmd">The cmd<see cref="CreateCommentCmd"/></param>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="Task{CommentDto}"/></returns>
        protected override Task<CommentDto> CreateSpecificAsync(CreateCommentCmd cmd, string id)
        {
            var note = _factory.CreateIntance(cmd, id);

            return Task.FromResult(note.ToDto());
        }

        /// <summary>
        /// The UpdateSpecificAsync
        /// </summary>
        /// <param name="cmd">The cmd<see cref="UpdateCommentCmd"/></param>
        /// <returns>The <see cref="Task{CommentDto}"/></returns>
        protected override Task<CommentDto> UpdateSpecificAsync(UpdateCommentCmd cmd)
        {
            var note = _factory.UpdateIntance(cmd);

            return Task.FromResult(note.ToDto());
        }
    }
}
