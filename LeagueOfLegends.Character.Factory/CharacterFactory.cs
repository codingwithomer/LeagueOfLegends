using LeagueOfLegends.Business.Abstractions;
using LeagueOfLegends.Character.Models;

namespace LeagueOfLegends.Character.Factory
{
    /// <summary>
    /// Creates concrete character instances from character type values.
    /// </summary>
    public class CharacterFactory : ICharacterFactory
    {
        /// <summary>
        /// Returns a concrete character implementation for the given type.
        /// </summary>
        /// <param name="characterType">Character type selected by user.</param>
        /// <returns>Initialized character instance.</returns>
        public CharacterBase CreateCharacter(CharacterType characterType)
        {
            return characterType switch
            {
                CharacterType.Warrior => new Warrior(),
                CharacterType.Wizard => new Wizard(),
                CharacterType.Support => new Support(),
                _ => throw new NotSupportedException($"Unsupported character type: {characterType}")
            };
        }
    }
}
