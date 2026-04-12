using LeagueOfLegends.Character.Models;

namespace LeagueOfLegends.Business.Abstractions
{
    /// <summary>
    /// Applies character-specific equipment rules and stat bonuses.
    /// </summary>
    public interface ICharacterEquipmentService
    {
        /// <summary>
        /// Determines whether the selected character can use health equipment.
        /// </summary>
        /// <param name="characterType">Selected character type.</param>
        /// <returns><see langword="true"/> if health equipment is supported; otherwise <see langword="false"/>.</returns>
        bool RequiresHealthEquipment(CharacterType characterType);

        /// <summary>
        /// Determines whether the selected character can use attack equipment.
        /// </summary>
        /// <param name="characterType">Selected character type.</param>
        /// <returns><see langword="true"/> if attack equipment is supported; otherwise <see langword="false"/>.</returns>
        bool RequiresAttackEquipment(CharacterType characterType);

        /// <summary>
        /// Applies the selected health equipment bonus to a character.
        /// </summary>
        /// <param name="character">Target character to mutate.</param>
        /// <param name="equipment">Selected health equipment.</param>
        void ApplyHealthEquipment(CharacterBase character, HealthEquipment equipment);

        /// <summary>
        /// Applies the selected attack equipment bonus to a character.
        /// </summary>
        /// <param name="character">Target character to mutate.</param>
        /// <param name="equipment">Selected attack equipment.</param>
        void ApplyAttackEquipment(CharacterBase character, AttackEquipment equipment);
    }
}
