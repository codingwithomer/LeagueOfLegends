namespace LeagueOfLegends.Business.Abstractions
{
    /// <summary>
    /// Abstracts console operations to keep business logic testable.
    /// </summary>
    public interface IGameConsole
    {
        /// <summary>
        /// Reads one line of user input.
        /// </summary>
        /// <returns>Entered text or <see langword="null"/>.</returns>
        string? ReadLine();

        /// <summary>
        /// Writes one line to output.
        /// </summary>
        /// <param name="value">Text to print.</param>
        void WriteLine(string value = "");

        /// <summary>
        /// Clears output window.
        /// </summary>
        void Clear();

        /// <summary>
        /// Sets current foreground color.
        /// </summary>
        /// <param name="color">Color value.</param>
        void SetForegroundColor(ConsoleColor color);

        /// <summary>
        /// Resets foreground color to default.
        /// </summary>
        void ResetColor();
    }
}
