namespace LeagueOfLegends.Character.Models
{
    /// <summary>
    /// Warrior character with default Ashe stats.
    /// </summary>
    public class Warrior : CharacterBase
    {
        /// <summary>
        /// Initializes a warrior character.
        /// </summary>
        /// <param name="characterType">Character type value.</param>
        /// <param name="name">Character name.</param>
        /// <param name="healthPoint">Initial health value.</param>
        /// <param name="attackPower">Initial attack power value.</param>
        public Warrior(
            CharacterType characterType = CharacterType.Warrior,
            string name = "Ashe",
            int healthPoint = 95,
            int attackPower = 30)
            : base(characterType, name, healthPoint, attackPower)
        {
        }
    }
}
