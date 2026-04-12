namespace LeagueOfLegends.Character.Models
{
    /// <summary>
    /// Base entity that defines common character attributes and invariants.
    /// </summary>
    public abstract class CharacterBase
    {
        private int _healthPoint;
        private int _attackPower;

        /// <summary>
        /// Initializes a character with baseline attributes.
        /// </summary>
        /// <param name="characterType">Character category.</param>
        /// <param name="name">Display name.</param>
        /// <param name="healthPoint">Initial health value.</param>
        /// <param name="attackPower">Initial attack value.</param>
        protected CharacterBase(CharacterType characterType, string name, int healthPoint, int attackPower)
        {
            CharacterType = characterType;
            Name = name;
            _healthPoint = healthPoint;
            _attackPower = attackPower;
        }

        /// <summary>
        /// Gets character category.
        /// </summary>
        public CharacterType CharacterType { get; }

        /// <summary>
        /// Gets character display name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets health value. Value cannot be negative.
        /// </summary>
        public int HealthPoint
        {
            get => _healthPoint;
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Health value cannot be less than 0.");
                }

                _healthPoint = value;
            }
        }

        /// <summary>
        /// Gets or sets attack power value. Value cannot be negative.
        /// </summary>
        public int AttackPower
        {
            get => _attackPower;
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Attack value cannot be less than 0.");
                }

                _attackPower = value;
            }
        }
    }
}
