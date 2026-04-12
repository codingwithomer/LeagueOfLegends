using LeagueOfLegends.Business.Abstractions;

namespace LeagueOfLegends.Business.Concretes
{
    /// <summary>
    /// Handles health and attack equipment menu interactions.
    /// </summary>
    public class HealthEquipmentManager : IEquipmentSelectionService
    {
        private readonly IGameConsole _console;

        /// <summary>
        /// Initializes equipment interaction manager.
        /// </summary>
        /// <param name="console">Console abstraction for input/output.</param>
        public HealthEquipmentManager(IGameConsole console)
        {
            _console = console;
        }

        /// <summary>
        /// Prints health equipment options.
        /// </summary>
        public void DisplayHealthEquipmentMenu()
        {
            _console.WriteLine("Please select a health equipment. Enter the number and press Enter.");
            _console.WriteLine("1 - Blue Spell");
            _console.WriteLine("2 - Green Spell");
            _console.WriteLine();
        }

        /// <summary>
        /// Reads selected health equipment option.
        /// </summary>
        /// <returns>User input value or empty string.</returns>
        public string GetHealthEquipmentInput()
        {
            string? input = _console.ReadLine();
            _console.Clear();
            return input ?? string.Empty;
        }

        /// <summary>
        /// Prints attack equipment options.
        /// </summary>
        public void DisplayAttackEquipmentMenu()
        {
            _console.WriteLine("Please select an attack equipment. Enter the number and press Enter.");
            _console.WriteLine("1 - Sword");
            _console.WriteLine("2 - Weapon");
            _console.WriteLine();
        }

        /// <summary>
        /// Reads selected attack equipment option.
        /// </summary>
        /// <returns>User input value or empty string.</returns>
        public string GetAttackEquipmentInput()
        {
            string? input = _console.ReadLine();
            _console.Clear();
            return input ?? string.Empty;
        }
    }
}
