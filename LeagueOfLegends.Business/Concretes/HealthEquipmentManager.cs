using LeagueOfLegends.Business.Abracts;
using System;
using System.Threading;

namespace LeagueOfLegends.Business.Concretes
{
    public class HealthEquipmentManager : IHealthEquipmentService
    {
        public void DisplayHealthEquipmentMenu()
        {
            Console.WriteLine("Lütfen bir sağlık ekipman seçiniz. Ekipman seçimini belirtilen sayı ile yapınız ve ardından Entera basınız. ");
            Console.WriteLine("1-Mavi Büyü");
            Console.WriteLine("2-Yeşil Büyü");

            Console.WriteLine();
        }

        public string GetHealthEquipmentInput()
        {
            string input = Console.ReadLine();
            Console.Clear();
            return input;
        }
    }
}
