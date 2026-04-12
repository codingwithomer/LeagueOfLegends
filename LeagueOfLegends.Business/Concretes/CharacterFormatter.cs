using LeagueOfLegends.Business.Abstractions;
using LeagueOfLegends.Character.Models;

namespace LeagueOfLegends.Business.Concretes
{
    /// <summary>
    /// Converts character entities into printable text blocks.
    /// </summary>
    public class CharacterFormatter : ICharacterFormatter
    {
        /// <summary>
        /// Formats character details for final output.
        /// </summary>
        /// <param name="character">Character instance to format.</param>
        /// <returns>Formatted multiline string.</returns>
        public string Format(CharacterBase character)
        {
            ArgumentNullException.ThrowIfNull(character);

            return string.Concat(
                $"Type: {GetTypeName(character.CharacterType)}\n",
                $"Name: {character.Name}\n",
                $"Health Value: {character.HealthPoint} HP\n",
                $"Attack Power: {character.AttackPower} XP");
        }

        /// <summary>
        /// Converts character enum value to display text.
        /// </summary>
        /// <param name="characterType">Character type value.</param>
        /// <returns>Localized type name for output.</returns>
        private static string GetTypeName(CharacterType characterType)
        {
            return characterType switch
            {
                CharacterType.Warrior => "Warrior",
                CharacterType.Wizard => "Wizard",
                CharacterType.Support => "Support",
                _ => throw new NotSupportedException()
            };
        }
    }
}
