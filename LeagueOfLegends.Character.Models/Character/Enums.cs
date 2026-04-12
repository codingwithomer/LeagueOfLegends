namespace LeagueOfLegends.Character.Models
{
    /// <summary>
    /// Available attack equipment options.
    /// </summary>
    public enum AttackEquipment
    {
        /// <summary>
        /// Basic sword option.
        /// </summary>
        Sword = 1,

        /// <summary>
        /// Advanced weapon option.
        /// </summary>
        Weapon = 2
    }

    /// <summary>
    /// Available health equipment options.
    /// </summary>
    public enum HealthEquipment
    {
        /// <summary>
        /// Blue spell option.
        /// </summary>
        BlueSpell = 1,

        /// <summary>
        /// Green spell option.
        /// </summary>
        GreenSpell = 2
    }

    /// <summary>
    /// Available playable character types.
    /// </summary>
    public enum CharacterType
    {
        /// <summary>
        /// Warrior character type.
        /// </summary>
        Warrior = 1,

        /// <summary>
        /// Wizard character type.
        /// </summary>
        Wizard = 2,

        /// <summary>
        /// Support character type.
        /// </summary>
        Support = 3
    }
}
