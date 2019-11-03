using LeagueOfLegends.Business.Abracts;
using LeagueOfLegends.Character.Models;
using LeagueOfLegends.Common.Enums;
using System;
using System.Threading;

namespace LeagueOfLegends.Business.Concretes
{
    public class CharacterManager : ICharacterService
    {
        public void DisplayCharacterMenu()
        {
            Console.WriteLine("Lütfen bir karakter seçiniz. Karakter seçimini yanlarında belirtilen sayılar ile yapınız ve ardından Entera basınız. ");
            Console.WriteLine($"{(int)MenuItem.Warrior} - {MenuItem.Warrior}");
            Console.WriteLine($"{(int)MenuItem.Wizard} - {MenuItem.Wizard}");
            Console.WriteLine($"{(int)MenuItem.Support} - {MenuItem.Support}");
            Console.WriteLine($"{(int)MenuItem.Exit} - {MenuItem.Exit}");
            Console.WriteLine();
        }

        public string GetCharacterInput()
        {
            string input = Console.ReadLine();
            Console.Clear();
            return input;
        }

        public void ShowInvalidSelectionMessage()
        {
            Console.WriteLine("Geçersiz seçim! Lütfen listedeki öğelerden birinin sayısal değerini giriniz..");
            Thread.Sleep(2500);
            Console.Clear();
        }

        public void ShowResult(CharacterBase character)
        {
            Console.WriteLine($"İsim: {character.Name}");
            Console.WriteLine($"Sağlık Değeri: {character.HealthPoint.ToString()} HP");
            Console.WriteLine($"Atak Gücü: {character.AttackPower.ToString()} XP");

            Console.ReadLine();
        }

        public void ShowSelection(string input)
        {
            Console.Write($"Seçiminiz : {input}");
            Thread.Sleep(1750);
        }
    }
}
