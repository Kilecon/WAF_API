namespace WAF_API_Domain.Commands
{
    /// <summary>
    /// Defines the <see cref="Cmd" />
    /// </summary>
    public abstract class Cmd
    {
    }

    /// <summary>
    /// Defines the <see cref="IdCmd" />
    /// </summary>
    public abstract class IdCmd : Cmd
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public string? Id { get; set; }
    }
}
