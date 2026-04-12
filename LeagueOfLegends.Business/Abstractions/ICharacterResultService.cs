using LeagueOfLegends.Character.Models;

namespace LeagueOfLegends.Business.Abstractions
{
    /// <summary>
    /// Displays the final character result.
    /// </summary>
    public interface ICharacterResultService
    {
        /// <summary>
        /// Shows the prepared character output.
        /// </summary>
        /// <param name="character">Character to display.</param>
        void ShowResult(CharacterBase character);
    }
}
