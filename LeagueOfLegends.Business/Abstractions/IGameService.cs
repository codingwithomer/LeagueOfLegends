namespace LeagueOfLegends.Business.Abstractions
{
    /// <summary>
    /// Coordinates the end-to-end game flow.
    /// </summary>
    public interface IGameService
    {
        /// <summary>
        /// Prints the intro message.
        /// </summary>
        void Intro();

        /// <summary>
        /// Executes the main game interaction flow.
        /// </summary>
        void Run();
    }
}
