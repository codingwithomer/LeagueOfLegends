using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueOfLegends.Character.Models
{
    public abstract class CharacterBase
    {
        private string _name;
        private int _healthPoint;
        private int _attackPower;
        private CharacterType _characterType;

        public CharacterBase(CharacterType characterType, string name, int healthPoint, int attackPower)
        {
            _characterType = characterType;
            _name = name;
            _healthPoint = healthPoint;
            _attackPower = attackPower;
        }

        public string Name { get { return _name; } set { _name = value; } }

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
