namespace LeagueOfLegends.Character.Models
{
    /// <summary>
    /// Wizard character with default Annie stats.
    /// </summary>
    public class Wizard : CharacterBase
    {
        /// <summary>
        /// Initializes a wizard character.
        /// </summary>
        /// <param name="characterType">Character type value.</param>
        /// <param name="name">Character name.</param>
        /// <param name="healthPoint">Initial health value.</param>
        /// <param name="attackPower">Initial attack power value.</param>
        public Wizard(
            CharacterType characterType = CharacterType.Wizard,
            string name = "Annie",
            int healthPoint = 100,
            int attackPower = 20)
            : base(characterType, name, healthPoint, attackPower)
        {
        }
    }
}
