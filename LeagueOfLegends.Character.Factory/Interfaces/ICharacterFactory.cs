using LeagueOfLegends.Character.Models;

namespace LeagueOfLegends.Character.Factory
{
    public interface ICharacterFactory
    {
        CharacterBase CreateCharacter(int characterType);
    }
}
