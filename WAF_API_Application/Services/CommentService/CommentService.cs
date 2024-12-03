namespace WAF_API_Application.Services.RatingService
{
    using WAF_API_Domain.Rating.Commands;
    using WAF_API_Domain.Rating.Dtos;
    using WAF_API_Domain.Rating.Factory;
    using System.Threading.Tasks;
    using WAF_API_Application.Services;

    /// <summary>
    /// Defines the <see cref="RatingService" />
    /// </summary>
    public class RatingService : BaseService<RatingDto, CreateRatingCmd, UpdateRatingCmd>, IRatingService
    {
        /// <summary>
        /// Defines the _factory
        /// </summary>
        private IRatingFactory _factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="RatingService"/> class.
        /// </summary>
        /// <param name="factory">The factory<see cref="IRatingFactory"/></param>
        /// <param name="repo">The repo<see cref="IBaseRepository{RatingDto}"/></param>
        public RatingService(IRatingFactory factory, IBaseRepository<RatingDto> repo) : base(repo)
        {
            _factory = factory;
        }

        /// <summary>
        /// The CreateSpecificAsync
        /// </summary>
        /// <param name="cmd">The cmd<see cref="CreateRatingCmd"/></param>
        /// <param name="id">The id<see cref="string"/></param>
        /// <returns>The <see cref="Task{RatingDto}"/></returns>
        protected override Task<RatingDto> CreateSpecificAsync(CreateRatingCmd cmd, string id)
        {
            var note = _factory.CreateIntance(cmd, id);

            return Task.FromResult(note.ToDto());
        }

        /// <summary>
        /// The UpdateSpecificAsync
        /// </summary>
        /// <param name="cmd">The cmd<see cref="UpdateRatingCmd"/></param>
        /// <returns>The <see cref="Task{RatingDto}"/></returns>
        protected override Task<RatingDto> UpdateSpecificAsync(UpdateRatingCmd cmd)
        {
            var note = _factory.UpdateIntance(cmd);

            return Task.FromResult(note.ToDto());
        }
    }
}
