namespace LeagueOfLegends.Character.Models
{
    /// <summary>
    /// Support character with default Alistar stats.
    /// </summary>
    public class Support : CharacterBase
    {
        /// <summary>
        /// Initializes a support character.
        /// </summary>
        /// <param name="characterType">Character type value.</param>
        /// <param name="name">Character name.</param>
        /// <param name="healthPoint">Initial health value.</param>
        /// <param name="attackPower">Initial attack power value.</param>
        public Support(
            CharacterType characterType = CharacterType.Support,
            string name = "Alistar",
            int healthPoint = 100,
            int attackPower = 30)
            : base(characterType, name, healthPoint, attackPower)
        {
        }
    }
}
