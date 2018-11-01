using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfLegends.Character.Models
{
    public class Support : CharacterBase
    {
        public Support(CharacterType characterType = CharacterType.Support,
                       string name = "Alistar",
                       int healthPoint = 0,
                       int attackPower = 30)
            : base(characterType, name, healthPoint, attackPower)
        {

        }
    }
}