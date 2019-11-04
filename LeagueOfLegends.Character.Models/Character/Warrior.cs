namespace LeagueOfLegends.Character.Models
{
    public class Warrior : CharacterBase
    {
        public Warrior(CharacterType characterType = CharacterType.Warrior,
                       string name = "Ashe",
                       int healthPoint = 95,
                       int attackPower = 30)
            : base(characterType, name, healthPoint, attackPower)
        {

        }
    }
}
