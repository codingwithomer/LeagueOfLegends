using LeagueOfLegends.Character.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfLegends.Character.Factory
{
    public interface ICharacterFactory
    {
        CharacterBase CreateCharacter(int characterType);
        bool CharacterIsNull(CharacterBase character);
    }
}
