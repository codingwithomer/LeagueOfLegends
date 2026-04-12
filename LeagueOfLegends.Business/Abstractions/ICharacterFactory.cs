using LeagueOfLegends.Character.Models;

namespace LeagueOfLegends.Business.Abstractions
{
    /// <summary>
    /// Creates domain character instances from selected character types.
    /// </summary>
    public interface ICharacterFactory
    {
        /// <summary>
        /// Builds a new character instance for the provided type.
        /// </summary>
        /// <param name="characterType">Character type selected by the player.</param>
        /// <returns>A concrete <see cref="CharacterBase"/> implementation.</returns>
        CharacterBase CreateCharacter(CharacterType characterType);
    }
}
