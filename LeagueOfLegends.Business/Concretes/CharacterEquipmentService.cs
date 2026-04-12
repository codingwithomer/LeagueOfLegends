using LeagueOfLegends.Business.Abstractions;
using LeagueOfLegends.Character.Models;

namespace LeagueOfLegends.Business.Concretes
{
    /// <summary>
    /// Applies equipment bonuses based on character and equipment types.
    /// </summary>
    public class CharacterEquipmentService : ICharacterEquipmentService
    {
        private static readonly IReadOnlyDictionary<CharacterType, IReadOnlyDictionary<HealthEquipment, int>> HealthBonuses =
            new Dictionary<CharacterType, IReadOnlyDictionary<HealthEquipment, int>>
            {
                {
                    CharacterType.Warrior,
                    new Dictionary<HealthEquipment, int>
                    {
                        { HealthEquipment.BlueSpell, 10 },
                        { HealthEquipment.GreenSpell, 5 }
                    }
                },
                {
                    CharacterType.Wizard,
                    new Dictionary<HealthEquipment, int>
                    {
                        { HealthEquipment.BlueSpell, 50 },
                        { HealthEquipment.GreenSpell, 30 }
                    }
                }
            };

        private static readonly IReadOnlyDictionary<CharacterType, IReadOnlyDictionary<AttackEquipment, int>> AttackBonuses =
            new Dictionary<CharacterType, IReadOnlyDictionary<AttackEquipment, int>>
            {
                {
                    CharacterType.Warrior,
                    new Dictionary<AttackEquipment, int>
                    {
                        { AttackEquipment.Sword, 20 },
                        { AttackEquipment.Weapon, 50 }
                    }
                },
                {
                    CharacterType.Support,
                    new Dictionary<AttackEquipment, int>
                    {
                        { AttackEquipment.Sword, 10 },
                        { AttackEquipment.Weapon, 20 }
                    }
                }
            };

        /// <summary>
        /// Indicates whether the character type accepts health equipment.
        /// </summary>
        /// <param name="characterType">Character type to evaluate.</param>
        /// <returns><see langword="true"/> if health equipment is supported.</returns>
        public bool RequiresHealthEquipment(CharacterType characterType)
        {
            return HealthBonuses.ContainsKey(characterType);
        }

        /// <summary>
        /// Indicates whether the character type accepts attack equipment.
        /// </summary>
        /// <param name="characterType">Character type to evaluate.</param>
        /// <returns><see langword="true"/> if attack equipment is supported.</returns>
        public bool RequiresAttackEquipment(CharacterType characterType)
        {
            return AttackBonuses.ContainsKey(characterType);
        }

        /// <summary>
        /// Adds health bonus from selected equipment to character stats.
        /// </summary>
        /// <param name="character">Character receiving the bonus.</param>
        /// <param name="equipment">Selected health equipment.</param>
        public void ApplyHealthEquipment(CharacterBase character, HealthEquipment equipment)
        {
            ArgumentNullException.ThrowIfNull(character);

            if (!HealthBonuses.TryGetValue(character.CharacterType, out IReadOnlyDictionary<HealthEquipment, int>? bonuses))
            {
                throw new InvalidOperationException($"Health equipment is not supported for {character.CharacterType}.");
            }

            if (!bonuses.TryGetValue(equipment, out int bonus))
            {
                throw new InvalidOperationException($"Health equipment {equipment} is not supported for {character.CharacterType}.");
            }

            character.HealthPoint += bonus;
        }

        /// <summary>
        /// Adds attack bonus from selected equipment to character stats.
        /// </summary>
        /// <param name="character">Character receiving the bonus.</param>
        /// <param name="equipment">Selected attack equipment.</param>
        public void ApplyAttackEquipment(CharacterBase character, AttackEquipment equipment)
        {
            ArgumentNullException.ThrowIfNull(character);

            if (!AttackBonuses.TryGetValue(character.CharacterType, out IReadOnlyDictionary<AttackEquipment, int>? bonuses))
            {
                throw new InvalidOperationException($"Attack equipment is not supported for {character.CharacterType}.");
            }

            if (!bonuses.TryGetValue(equipment, out int bonus))
            {
                throw new InvalidOperationException($"Attack equipment {equipment} is not supported for {character.CharacterType}.");
            }

            character.AttackPower += bonus;
        }
    }
}
