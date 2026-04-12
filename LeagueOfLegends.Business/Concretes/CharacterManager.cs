using LeagueOfLegends.Business.Abstractions;
using LeagueOfLegends.Character.Models;

namespace LeagueOfLegends.Business.Concretes
{
    /// <summary>
    /// Manages character menu interactions and result presentation.
    /// </summary>
    public class CharacterManager : ICharacterSelectionService, ICharacterResultService
    {
        private static readonly IReadOnlyDictionary<string, string> MenuItems = new Dictionary<string, string>
        {
            { "1", "Warrior" },
            { "2", "Wizard" },
            { "3", "Support" },
            { "4", "Exit" }
        };

        private readonly IGameConsole _console;
        private readonly ICharacterFormatter _characterFormatter;

        /// <summary>
        /// Initializes character interaction dependencies.
        /// </summary>
        /// <param name="console">Console abstraction for input/output.</param>
        /// <param name="characterFormatter">Formatter for result output.</param>
        public CharacterManager(IGameConsole console, ICharacterFormatter characterFormatter)
        {
            _console = console;
            _characterFormatter = characterFormatter;
        }

        /// <summary>
        /// Prints available character choices.
        /// </summary>
        public void DisplayCharacterMenu()
        {
            _console.WriteLine("Please select a character. Enter the number shown next to the character and press Enter.");

            foreach (KeyValuePair<string, string> menuItem in MenuItems)
            {
                _console.WriteLine($"{menuItem.Key} - {menuItem.Value}");
            }

            _console.WriteLine();
        }

        /// <summary>
        /// Reads and returns selected character input.
        /// </summary>
        /// <returns>User input value or empty string.</returns>
        public string GetCharacterInput()
        {
            string? input = _console.ReadLine();
            return input ?? string.Empty;
        }

        /// <summary>
        /// Shows a standard invalid selection message.
        /// </summary>
        public void ShowInvalidSelectionMessage()
        {
            _console.WriteLine("Invalid selection. Please enter one of the numeric values from the list.");
        }

        /// <summary>
        /// Displays the chosen menu item text.
        /// </summary>
        /// <param name="input">Validated user selection key.</param>
        public void ShowSelection(string input)
        {
            if (MenuItems.TryGetValue(input, out string? selection))
            {
                _console.WriteLine($"Your selection: {selection}");
                return;
            }

            _console.WriteLine("Your selection could not be resolved.");
        }

        /// <summary>
        /// Writes the final formatted character result to output.
        /// </summary>
        /// <param name="character">Character to display.</param>
        public void ShowResult(CharacterBase character)
        {
            string formattedCharacter = _characterFormatter.Format(character);

            _console.WriteLine("---");
            _console.WriteLine();
            _console.WriteLine(formattedCharacter);
            _console.WriteLine();
            _console.WriteLine("---");
        }
    }
}
