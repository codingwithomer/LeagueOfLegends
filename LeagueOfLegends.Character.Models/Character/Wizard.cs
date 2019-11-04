using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfLegends.Character.Models
{
    public class Wizard : CharacterBase
    {
        public Wizard(CharacterType characterType = CharacterType.Wizard,
                      string name = "Annie",
                      int healthPoint = 100,
                      int attackPower = 0
            ) : base(characterType, name, healthPoint, attackPower)
        {

        }
    }
}
