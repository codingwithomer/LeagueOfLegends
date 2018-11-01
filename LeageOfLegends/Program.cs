using LeagueOfLegends.Character.Factory;
using LeagueOfLegends.Character.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace LeageOfLegends
{
    class Program
    {
        private static ICharacterFactory _characterFactory = new CharacterFactory();

        static void Main(string[] args)
        {
            Intro();

            #region Character Selection
            bool isCharacterValid = false;
            int characterType = 0;

            while (!isCharacterValid)
            {
                DisplayCharacterMenu();

                string input = GetUserForCharacterInput();
                isCharacterValid = IsValidInputForCharacter(input, ref characterType);

                if (isCharacterValid == false)
                    continue;
                else
                    break;
            }

            CharacterBase character = _characterFactory.CreateCharacter(characterType);

            if (!_characterFactory.CharacterIsNull(character))
                Environment.Exit(0);

            #endregion

            #region Health Equipment Selection
            bool isHealtEquipmentValid = false;
            int healthEquipmentType = 0;

            while (!isHealtEquipmentValid)
            {
                DisplayHealthEquipmentMenu();

                string input = GetUserInputForHealthEquipmentInput();
                isHealtEquipmentValid = IsValidInputForHealthEquipment(input, ref healthEquipmentType);

                if (isHealtEquipmentValid == false)
                    continue;
                else
                    break;
            }
            #endregion

            #region Attack Equipment Selection
            bool isAttackEquipmentValid = false;
            int attackEquipmentType = 0;

            while (!isHealtEquipmentValid)
            {
                DisplayAttackEquipmentMenu();

                string input = GetUserInputForHealthEquipmentInput();
                isAttackEquipmentValid = IsValidInputForHealthEquipment(input, ref attackEquipmentType);

                if (isHealtEquipmentValid == false)
                    continue;
                else
                    break;
            }
            #endregion

            ShowResult(character);
        }

        #region Show Result
        private static void ShowResult(CharacterBase character)
        {
            Console.WriteLine($"İsim: {character.Name}");
            Console.WriteLine($"Sağlık Değeri: {character.HealthPoint.ToString()} HP");
            Console.WriteLine($"Atak Gücü: {character.AttackPower.ToString()} XP");

            Console.ReadLine();
        } 
        #endregion

        #region Character Operations
        private static void Intro()
        {
            Console.WriteLine("League of Legends'a hoşgeldiniz.");
            Thread.Sleep(4000);
            Console.Clear();
        }

        private static void DisplayCharacterMenu()
        {
            Console.WriteLine("Lütfen bir karakter seçiniz. Karakter seçimini belirtilen sayı ile yapınız ve ardından Entera basınız. ");
            Console.WriteLine("1-Savaşçı");
            Console.WriteLine("2-Sihirbaz");
            Console.WriteLine("3-Destek");
            Console.WriteLine("4-Çıkış");

            Thread.Sleep(7000);
            Console.Clear();
        }

        private static string GetUserForCharacterInput()
        {
            string input = Console.ReadLine();
            Console.Clear();
            return input;
        }

        private static bool IsValidInputForCharacter(string input, ref int characterType)
        {
            bool isValid = false;

            if (string.IsNullOrWhiteSpace(input))
                return isValid;

            List<int> validKeys = new List<int> { 1, 2, 3, 4 };

            isValid = int.TryParse(input, out int result);

            if (isValid)
                isValid = validKeys.Contains(result);

            if (isValid == true)
                characterType = result;

            return isValid;
        }
        #endregion

        #region HealthEquipment
        private static void DisplayHealthEquipmentMenu()
        {
            Console.WriteLine("Lütfen bir sağlık ekipman seçiniz. Ekipman seçimini belirtilen sayı ile yapınız ve ardından Entera basınız. ");
            Console.WriteLine("1-Mavi Büyü");
            Console.WriteLine("2-Yeşil Büyü");
            Thread.Sleep(7000);
            Console.Clear();
        }

        private static string GetUserInputForHealthEquipmentInput()
        {
            string input = Console.ReadLine();
            Console.Clear();
            return input;
        }

        private static bool IsValidInputForHealthEquipment(string input, ref int healthEquipmentType)
        {
            bool isValid = false;

            if (string.IsNullOrWhiteSpace(input))
                return isValid;

            List<int> validKeys = new List<int> { 1, 2 };

            isValid = int.TryParse(input, out int result);

            if (isValid)
                isValid = validKeys.Contains(result);

            if (isValid == true)
                healthEquipmentType = result;

            return isValid;
        }
        #endregion

        #region AttackEquipment
        private static void DisplayAttackEquipmentMenu()
        {
            Console.WriteLine("Lütfen bir atak ekipmanı seçiniz. Ekipman seçimini belirtilen sayı ile yapınız ve ardından Entera basınız. ");
            Console.WriteLine("1-Kılıç");
            Console.WriteLine("2-Silah");

            Thread.Sleep(7000);
            Console.Clear();
        }

        private static string GetUserInputForAttackEquipmentInput()
        {
            string input = Console.ReadLine();
            Console.Clear();
            return input;
        }

        private static bool IsValidInputForAttackEquipment(string input, ref int attackEquipmentType)
        {
            bool isValid = false;

            if (string.IsNullOrWhiteSpace(input))
                return isValid;

            List<int> validKeys = new List<int> { 1, 2 };

            isValid = int.TryParse(input, out int result);

            if (isValid)
                isValid = validKeys.Contains(result);

            if (isValid == true)
                attackEquipmentType = result;

            return isValid;
        }
        #endregion
    }
}