using LeagueOfLegends.Character.Models;

namespace LeagueOfLegends.Character.Factory
{
    public class CharacterFactory : ICharacterFactory
    {

        public CharacterBase CreateCharacter(int characterType)
        {
            CharacterBase character = null;

            switch (characterType)
            {
                case 1:
                    character = new Warrior();
                    break;
                case 2:
                    character = new Wizard();
                    break;
                case 3:
                    character = new Support();
                    break;
                default:
                    break;
            }

            return character;
        }
    }
}
