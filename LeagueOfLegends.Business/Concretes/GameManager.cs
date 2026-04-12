using LeagueOfLegends.Business.Abstractions;
using LeagueOfLegends.Character.Models;

namespace LeagueOfLegends.Business.Concretes
{
    /// <summary>
    /// Orchestrates character selection, equipment selection, and final output flow.
    /// </summary>
    public class GameManager : IGameService
    {
        private static readonly int[] CharacterOptions = { 1, 2, 3, 4 };
        private static readonly int[] EquipmentOptions = { 1, 2 };

        private readonly ICharacterSelectionService _characterSelectionService;
        private readonly ICharacterResultService _characterResultService;
        private readonly IEquipmentSelectionService _equipmentSelectionService;
        private readonly ICharacterFactory _characterFactory;
        private readonly ICharacterEquipmentService _characterEquipmentService;
        private readonly ISelectionValidator _selectionValidator;
        private readonly IGameConsole _console;

        /// <summary>
        /// Creates a game manager with all required domain services.
        /// </summary>
        /// <param name="characterFactory">Factory used to instantiate characters.</param>
        /// <param name="characterSelectionService">Character selection interaction service.</param>
        /// <param name="characterResultService">Result display service.</param>
        /// <param name="equipmentSelectionService">Equipment selection interaction service.</param>
        /// <param name="characterEquipmentService">Equipment application service.</param>
        /// <param name="selectionValidator">Input validation service.</param>
        /// <param name="console">Console abstraction for output styling.</param>
        public GameManager(
            ICharacterFactory characterFactory,
            ICharacterSelectionService characterSelectionService,
            ICharacterResultService characterResultService,
            IEquipmentSelectionService equipmentSelectionService,
            ICharacterEquipmentService characterEquipmentService,
            ISelectionValidator selectionValidator,
            IGameConsole console)
        {
            _characterFactory = characterFactory;
            _characterSelectionService = characterSelectionService;
            _characterResultService = characterResultService;
            _equipmentSelectionService = equipmentSelectionService;
            _characterEquipmentService = characterEquipmentService;
            _selectionValidator = selectionValidator;
            _console = console;
        }

        /// <summary>
        /// Prints game welcome message.
        /// </summary>
        public void Intro()
        {
            _console.SetForegroundColor(ConsoleColor.Green);
            _console.WriteLine("Welcome to League of Legends.");
            _console.ResetColor();
            _console.WriteLine();
        }

        /// <summary>
        /// Executes the main game workflow until a final character result is produced or user exits.
        /// </summary>
        public void Run()
        {
            CharacterType? selectedCharacter = PromptCharacter();

            if (!selectedCharacter.HasValue)
            {
                return;
            }

            CharacterBase character = _characterFactory.CreateCharacter(selectedCharacter.Value);

            if (_characterEquipmentService.RequiresHealthEquipment(character.CharacterType))
            {
                HealthEquipment healthEquipment = (HealthEquipment)PromptHealthEquipment();
                _characterEquipmentService.ApplyHealthEquipment(character, healthEquipment);
            }

            if (_characterEquipmentService.RequiresAttackEquipment(character.CharacterType))
            {
                AttackEquipment attackEquipment = (AttackEquipment)PromptAttackEquipment();
                _characterEquipmentService.ApplyAttackEquipment(character, attackEquipment);
            }

            _characterResultService.ShowResult(character);
        }

        /// <summary>
        /// Prompts user until a valid character selection is received or exit is selected.
        /// </summary>
        /// <returns>Selected character type, or <see langword="null"/> when exiting.</returns>
        private CharacterType? PromptCharacter()
        {
            while (true)
            {
                _characterSelectionService.DisplayCharacterMenu();

                string input = _characterSelectionService.GetCharacterInput();

                if (!_selectionValidator.TryValidate(input, CharacterOptions, out int selected))
                {
                    _characterSelectionService.ShowInvalidSelectionMessage();
                    continue;
                }

                if (selected == 4)
                {
                    return null;
                }

                _characterSelectionService.ShowSelection(input);
                return (CharacterType)selected;
            }
        }

        /// <summary>
        /// Prompts user until valid health equipment input is received.
        /// </summary>
        /// <returns>Selected health equipment numeric value.</returns>
        private int PromptHealthEquipment()
        {
            while (true)
            {
                _equipmentSelectionService.DisplayHealthEquipmentMenu();
                string input = _equipmentSelectionService.GetHealthEquipmentInput();

                if (_selectionValidator.TryValidate(input, EquipmentOptions, out int selected))
                {
                    return selected;
                }

                ShowInvalidEquipmentSelectionMessage();
            }
        }

        /// <summary>
        /// Prompts user until valid attack equipment input is received.
        /// </summary>
        /// <returns>Selected attack equipment numeric value.</returns>
        private int PromptAttackEquipment()
        {
            while (true)
            {
                _equipmentSelectionService.DisplayAttackEquipmentMenu();
                string input = _equipmentSelectionService.GetAttackEquipmentInput();

                if (_selectionValidator.TryValidate(input, EquipmentOptions, out int selected))
                {
                    return selected;
                }

                ShowInvalidEquipmentSelectionMessage();
            }
        }

        /// <summary>
        /// Shows a standard message for invalid equipment selection attempts.
        /// </summary>
        private void ShowInvalidEquipmentSelectionMessage()
        {
            _console.WriteLine("Invalid equipment selection. Please enter one of the listed numeric values.");
            _console.WriteLine();
        }
    }
}
