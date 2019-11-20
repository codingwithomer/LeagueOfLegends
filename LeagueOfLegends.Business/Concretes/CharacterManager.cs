using LeagueOfLegends.Business.Abracts;
using LeagueOfLegends.Character.Models;
using LeagueOfLegends.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LeagueOfLegends.Business.Concretes
{
    public class CharacterManager : ICharacterService
    {
        private Dictionary<string,string> menuItems = new Dictionary<string, string>()
        {
            {"1",MenuConstants.Warrior},
            {"2",MenuConstants.Wizard},
            {"3",MenuConstants.Support},
            {"4",MenuConstants.Exit}
        };

        public void DisplayCharacterMenu()
        {
            Console.WriteLine("Lütfen bir karakter seçiniz. Karakter seçimini yanlarında belirtilen sayılar ile yapınız ve ardından Enter'a basınız. ");

            foreach (var menuItem in menuItems)
            {
                 Console.WriteLine($"{menuItem.Key} - {menuItem.Value}");
            }            

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
            Console.WriteLine(character.ToString());

            Console.ReadLine();
        }

        public void ShowSelection(string input)
        {
            string selection = menuItems.Where(x => x.Key == input).Select(y => y.Value).SingleOrDefault();
            Console.Write($"Seçiminiz : {selection}");
            Thread.Sleep(1750);
        }
    }
}
