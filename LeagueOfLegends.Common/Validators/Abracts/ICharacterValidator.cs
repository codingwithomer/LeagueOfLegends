using LeagueOfLegends.Character.Models;

namespace LeagueOfLegends.Common.Validators.Abracts
{
    public interface ICharacterValidator
    {
        bool CharacterIsNull(CharacterBase character);
    }
}
