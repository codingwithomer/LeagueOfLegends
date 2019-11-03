using LeagueOfLegends.Character.Models;

namespace LeagueOfLegends.Business.Abracts
{
    public interface ICharacterService
    {
        void DisplayCharacterMenu();

        string GetCharacterInput();

        void ShowResult(CharacterBase character);

        void ShowSelection(string input);

        void ShowInvalidSelectionMessage();
    }
}
