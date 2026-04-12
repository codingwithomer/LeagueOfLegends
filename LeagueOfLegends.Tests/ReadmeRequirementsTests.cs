using LeagueOfLegends.Business.Abstractions;
using LeagueOfLegends.Business.Concretes;
using LeagueOfLegends.Character.Factory;
using LeagueOfLegends.Character.Models;
using LeagueOfLegends.Common.Validators.Concretes;

namespace LeagueOfLegends.Tests;

/// <summary>
/// Verifies that runtime outcomes match documented README scenarios.
/// </summary>
public class ReadmeRequirementsTests
{
    /// <summary>
    /// Executes game flow and validates resulting character values against README examples.
    /// </summary>
    /// <param name="characterSelection">Character menu input.</param>
    /// <param name="healthEquipmentSelection">Health equipment input when applicable.</param>
    /// <param name="attackEquipmentSelection">Attack equipment input when applicable.</param>
    /// <param name="expectedType">Expected final character type.</param>
    /// <param name="expectedName">Expected final character name.</param>
    /// <param name="expectedHealth">Expected final health value.</param>
    /// <param name="expectedAttack">Expected final attack value.</param>
    [Theory]
    [InlineData("1", "1", "2", CharacterType.Warrior, "Ashe", 105, 80)]
    [InlineData("2", "1", null, CharacterType.Wizard, "Annie", 150, 20)]
    [InlineData("3", null, "2", CharacterType.Support, "Alistar", 100, 50)]
    public void Run_ShouldProduceReadmeSampleCharacterValues(
        string characterSelection,
        string? healthEquipmentSelection,
        string? attackEquipmentSelection,
        CharacterType expectedType,
        string expectedName,
        int expectedHealth,
        int expectedAttack)
    {
        var characterSelectionService = new CharacterSelectionStub(characterSelection);
        var characterResultService = new CharacterResultSpy();
        var equipmentSelectionService = new EquipmentSelectionStub(healthEquipmentSelection, attackEquipmentSelection);

        IGameService sut = new GameManager(
            new CharacterFactory(),
            characterSelectionService,
            characterResultService,
            equipmentSelectionService,
            new CharacterEquipmentService(),
            new SelectionValidator(),
            new NoOpGameConsole());

        sut.Run();

        CharacterBase? result = characterResultService.ResultCharacter;

        Assert.NotNull(result);
        Assert.Equal(expectedName, result.Name);
        Assert.Equal(expectedHealth, result.HealthPoint);
        Assert.Equal(expectedAttack, result.AttackPower);
        Assert.Equal(expectedType, result.CharacterType);
        Assert.True(characterSelectionService.MenuDisplayCount >= 1);
    }

    /// <summary>
    /// Stub for deterministic character selection behavior in tests.
    /// </summary>
    private sealed class CharacterSelectionStub : ICharacterSelectionService
    {
        private readonly string _selection;

        /// <summary>
        /// Creates a stub with fixed selection value.
        /// </summary>
        /// <param name="selection">Character selection input to return.</param>
        public CharacterSelectionStub(string selection)
        {
            _selection = selection;
        }

        /// <summary>
        /// Gets how many times the character menu was requested.
        /// </summary>
        public int MenuDisplayCount { get; private set; }

        /// <summary>
        /// Gets how many times invalid selection message was requested.
        /// </summary>
        public int InvalidSelectionMessageCount { get; private set; }

        /// <summary>
        /// Gets the last shown selection input.
        /// </summary>
        public string? LastSelectionInput { get; private set; }

        /// <summary>
        /// Increments menu display call count.
        /// </summary>
        public void DisplayCharacterMenu()
        {
            MenuDisplayCount++;
        }

        /// <summary>
        /// Returns the configured character selection value.
        /// </summary>
        /// <returns>Configured selection value.</returns>
        public string GetCharacterInput()
        {
            return _selection;
        }

        /// <summary>
        /// Increments invalid selection notification count.
        /// </summary>
        public void ShowInvalidSelectionMessage()
        {
            InvalidSelectionMessageCount++;
        }

        /// <summary>
        /// Captures the last selected input value.
        /// </summary>
        /// <param name="input">Selected character input.</param>
        public void ShowSelection(string input)
        {
            LastSelectionInput = input;
        }
    }

    /// <summary>
    /// Spy that stores the final character result passed by the system under test.
    /// </summary>
    private sealed class CharacterResultSpy : ICharacterResultService
    {
        /// <summary>
        /// Gets the last captured result character.
        /// </summary>
        public CharacterBase? ResultCharacter { get; private set; }

        /// <summary>
        /// Captures the result character.
        /// </summary>
        /// <param name="character">Result character instance.</param>
        public void ShowResult(CharacterBase character)
        {
            ResultCharacter = character;
        }
    }

    /// <summary>
    /// Stub for deterministic equipment selections in tests.
    /// </summary>
    private sealed class EquipmentSelectionStub : IEquipmentSelectionService
    {
        private readonly Queue<string> _healthSelections = new();
        private readonly Queue<string> _attackSelections = new();

        /// <summary>
        /// Initializes equipment selection queues for health and attack flows.
        /// </summary>
        /// <param name="healthEquipmentSelection">Health equipment value to enqueue.</param>
        /// <param name="attackEquipmentSelection">Attack equipment value to enqueue.</param>
        public EquipmentSelectionStub(string? healthEquipmentSelection, string? attackEquipmentSelection)
        {
            if (!string.IsNullOrWhiteSpace(healthEquipmentSelection))
            {
                _healthSelections.Enqueue(healthEquipmentSelection);
            }

            if (!string.IsNullOrWhiteSpace(attackEquipmentSelection))
            {
                _attackSelections.Enqueue(attackEquipmentSelection);
            }
        }

        /// <summary>
        /// Gets number of health menu display calls.
        /// </summary>
        public int HealthMenuDisplayCount { get; private set; }

        /// <summary>
        /// Gets number of attack menu display calls.
        /// </summary>
        public int AttackMenuDisplayCount { get; private set; }

        /// <summary>
        /// Increments health menu display call count.
        /// </summary>
        public void DisplayHealthEquipmentMenu()
        {
            HealthMenuDisplayCount++;
        }

        /// <summary>
        /// Returns next queued health equipment input.
        /// </summary>
        /// <returns>Queued value or empty string when queue is exhausted.</returns>
        public string GetHealthEquipmentInput()
        {
            return _healthSelections.Count > 0 ? _healthSelections.Dequeue() : string.Empty;
        }

        /// <summary>
        /// Increments attack menu display call count.
        /// </summary>
        public void DisplayAttackEquipmentMenu()
        {
            AttackMenuDisplayCount++;
        }

        /// <summary>
        /// Returns next queued attack equipment input.
        /// </summary>
        /// <returns>Queued value or empty string when queue is exhausted.</returns>
        public string GetAttackEquipmentInput()
        {
            return _attackSelections.Count > 0 ? _attackSelections.Dequeue() : string.Empty;
        }
    }

    /// <summary>
    /// No-op console implementation for isolated tests.
    /// </summary>
    private sealed class NoOpGameConsole : IGameConsole
    {
        /// <summary>
        /// Returns an empty input value.
        /// </summary>
        /// <returns>An empty string.</returns>
        public string? ReadLine()
        {
            return string.Empty;
        }

        /// <summary>
        /// No-op write operation.
        /// </summary>
        /// <param name="value">Ignored text value.</param>
        public void WriteLine(string value = "")
        {
        }

        /// <summary>
        /// No-op clear operation.
        /// </summary>
        public void Clear()
        {
        }

        /// <summary>
        /// No-op color set operation.
        /// </summary>
        /// <param name="color">Ignored console color.</param>
        public void SetForegroundColor(ConsoleColor color)
        {
        }

        /// <summary>
        /// No-op color reset operation.
        /// </summary>
        public void ResetColor()
        {
        }
    }
}
