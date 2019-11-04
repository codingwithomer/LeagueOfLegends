using System;

namespace LeagueOfLegends.Character.Models
{
    public abstract class CharacterBase
    {
        private int _healthPoint;
        private int _attackPower;

        public CharacterBase(CharacterType characterType,
                             string name,
                             int healthPoint,
                             int attackPower)
        {
            CharacterType = characterType;
            Name = name;
            _healthPoint = healthPoint;
            _attackPower = attackPower;
        }

        public CharacterType CharacterType { get; }

        public string Name { get; set; }

        public int HealthPoint
        {
            get
            {
                return _healthPoint;
            }
            set
            {
                if (value < 0)
                    throw new InvalidOperationException("Sağlık değeri 0'dan küçük olamaz.");

                _healthPoint = value;
            }
        }

        public int AttackPower
        {
            get
            {
                return _attackPower;
            }
            set
            {
                if (value < 0)
                    throw new InvalidOperationException("Atak değeri 0'dan küçük olamaz.");

                _attackPower = value;
            }
        }

    }
}
