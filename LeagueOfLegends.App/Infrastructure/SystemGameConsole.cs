using LeagueOfLegends.Business.Abstractions;

namespace LeagueOfLegends.App.Infrastructure
{
    /// <summary>
    /// Concrete console adapter for runtime input/output operations.
    /// </summary>
    public class SystemGameConsole : IGameConsole
    {
        /// <summary>
        /// Reads one line from standard input.
        /// </summary>
        /// <returns>Entered text or <see langword="null"/>.</returns>
        public string? ReadLine()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Writes a line to standard output.
        /// </summary>
        /// <param name="value">Text value to print.</param>
        public void WriteLine(string value = "")
        {
            Console.WriteLine(value);
        }

        /// <summary>
        /// Clears the console screen.
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// Sets the current foreground color.
        /// </summary>
        /// <param name="color">Color to apply.</param>
        public void SetForegroundColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        /// <summary>
        /// Restores the console foreground color to default.
        /// </summary>
        public void ResetColor()
        {
            Console.ResetColor();
        }
    }
}
