using System;

namespace LeagueOfLegends.Character.Models
{
    public abstract class CharacterBase
    {
        private int _healthPoint;
        private int _attackPower;
        private string _type;
    

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

        public string Type 
        { 
            get
            {
                return _type;
            }
            private set{;}
        }

        public override string ToString()
        {
            return string.Concat($"Tip: {GetTypeName(CharacterType)}\n",
                                 $"İsim: {Name}\n",
                                 $"Sağlık Değeri: {HealthPoint.ToString()} HP\n",
                                 $"Atak Gücü: {AttackPower.ToString()} XP");//$"İsim: {Name}\nSağlık Değeri: {HealthPoint.ToString()} HP";
        }

        private string GetTypeName(CharacterType characterType)
        {
            string name = string.Empty;

            switch (characterType)
            {
                case CharacterType.Warrior:
                    name ="Savaşçı";
                    break;
                case CharacterType.Wizard:
                    name = "Sihirbaz";
                    break;
                case CharacterType.Support:
                    name = "Destek";
                    break;
                default:
                    throw new NotSupportedException();
            }

            return name;
        }
    }
}
