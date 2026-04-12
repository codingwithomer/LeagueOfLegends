using LeagueOfLegends.Character.Models;

namespace LeagueOfLegends.Business.Abstractions
{
    /// <summary>
    /// Provides text formatting for character output.
    /// </summary>
    public interface ICharacterFormatter
    {
        /// <summary>
        /// Creates a human-readable representation of a character.
        /// </summary>
        /// <param name="character">Character to format.</param>
        /// <returns>Formatted text output.</returns>
        string Format(CharacterBase character);
    }
}
