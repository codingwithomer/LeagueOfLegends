using LeagueOfLegends.Business.Concretes;
using LeagueOfLegends.Character.Factory;
using LeagueOfLegends.Character.Models;
using LeagueOfLegends.Common.Validators.Concretes;

namespace LeagueOfLegends.Tests;

/// <summary>
/// Verifies current expected behavior of core domain services.
/// </summary>
public class CurrentBehaviorTests
{
    /// <summary>
    /// Ensures factory returns the correct concrete type for each character enum.
    /// </summary>
    /// <param name="characterType">Requested character type.</param>
    /// <param name="expectedType">Expected concrete class type.</param>
    [Theory]
    [InlineData(CharacterType.Warrior, typeof(Warrior))]
    [InlineData(CharacterType.Wizard, typeof(Wizard))]
    [InlineData(CharacterType.Support, typeof(Support))]
    public void CharacterFactory_ShouldCreateExpectedType(CharacterType characterType, Type expectedType)
    {
        var factory = new CharacterFactory();

        CharacterBase character = factory.CreateCharacter(characterType);

        Assert.IsType(expectedType, character);
    }

    /// <summary>
    /// Ensures validator accepts and rejects expected inputs.
    /// </summary>
    /// <param name="input">Raw input value.</param>
    /// <param name="expectedValid">Expected validation result.</param>
    /// <param name="expectedSelection">Expected parsed selection output.</param>
    [Theory]
    [InlineData("1", true, 1)]
    [InlineData("2", true, 2)]
    [InlineData("4", true, 4)]
    [InlineData("0", false, 0)]
    [InlineData("abc", false, 0)]
    [InlineData("", false, 0)]
    [InlineData(null, false, 0)]
    public void SelectionValidator_ShouldValidateExpectedValues(string? input, bool expectedValid, int expectedSelection)
    {
        var sut = new SelectionValidator();

        bool isValid = sut.TryValidate(input, new[] { 1, 2, 3, 4 }, out int selection);

        Assert.Equal(expectedValid, isValid);
        Assert.Equal(expectedSelection, selection);
    }

    /// <summary>
    /// Verifies health bonuses are applied according to character and equipment combination.
    /// </summary>
    /// <param name="type">Character type.</param>
    /// <param name="equipment">Health equipment choice.</param>
    /// <param name="initialHealth">Starting health value.</param>
    /// <param name="expectedHealth">Expected health after bonus.</param>
    [Theory]
    [InlineData(CharacterType.Warrior, HealthEquipment.BlueSpell, 95, 105)]
    [InlineData(CharacterType.Warrior, HealthEquipment.GreenSpell, 95, 100)]
    [InlineData(CharacterType.Wizard, HealthEquipment.BlueSpell, 100, 150)]
    [InlineData(CharacterType.Wizard, HealthEquipment.GreenSpell, 100, 130)]
    public void CharacterEquipmentService_ShouldApplyHealthBonuses(
        CharacterType type,
        HealthEquipment equipment,
        int initialHealth,
        int expectedHealth)
    {
        var sut = new CharacterEquipmentService();
        CharacterBase character = CreateCharacter(type, initialHealth, 20);

        sut.ApplyHealthEquipment(character, equipment);

        Assert.Equal(expectedHealth, character.HealthPoint);
    }

    /// <summary>
    /// Verifies attack bonuses are applied according to character and equipment combination.
    /// </summary>
    /// <param name="type">Character type.</param>
    /// <param name="equipment">Attack equipment choice.</param>
    /// <param name="initialAttack">Starting attack value.</param>
    /// <param name="expectedAttack">Expected attack after bonus.</param>
    [Theory]
    [InlineData(CharacterType.Warrior, AttackEquipment.Sword, 30, 50)]
    [InlineData(CharacterType.Warrior, AttackEquipment.Weapon, 30, 80)]
    [InlineData(CharacterType.Support, AttackEquipment.Sword, 30, 40)]
    [InlineData(CharacterType.Support, AttackEquipment.Weapon, 30, 50)]
    public void CharacterEquipmentService_ShouldApplyAttackBonuses(
        CharacterType type,
        AttackEquipment equipment,
        int initialAttack,
        int expectedAttack)
    {
        var sut = new CharacterEquipmentService();
        CharacterBase character = CreateCharacter(type, 100, initialAttack);

        sut.ApplyAttackEquipment(character, equipment);

        Assert.Equal(expectedAttack, character.AttackPower);
    }

    /// <summary>
    /// Ensures formatter returns the agreed multiline output format.
    /// </summary>
    [Fact]
    public void CharacterFormatter_ShouldFormatCharacterOutput()
    {
        var sut = new CharacterFormatter();
        CharacterBase character = new Warrior();

        string result = sut.Format(character);

        Assert.Equal(
            "Type: Warrior\nName: Ashe\nHealth Value: 95 HP\nAttack Power: 30 XP",
            result);
    }

    /// <summary>
    /// Creates character instances with test-specific stats.
    /// </summary>
    /// <param name="type">Character type to instantiate.</param>
    /// <param name="healthPoint">Health value override.</param>
    /// <param name="attackPower">Attack value override.</param>
    /// <returns>Concrete character instance.</returns>
    private static CharacterBase CreateCharacter(CharacterType type, int healthPoint, int attackPower)
    {
        return type switch
        {
            CharacterType.Warrior => new Warrior(healthPoint: healthPoint, attackPower: attackPower),
            CharacterType.Wizard => new Wizard(healthPoint: healthPoint, attackPower: attackPower),
            CharacterType.Support => new Support(healthPoint: healthPoint, attackPower: attackPower),
            _ => throw new NotSupportedException()
        };
    }
}
