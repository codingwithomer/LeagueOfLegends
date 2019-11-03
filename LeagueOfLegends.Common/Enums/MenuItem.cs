using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegends.Common.Enums
{
    public enum MenuItem
    {
        [Display(Name = "Savaşçı")]
        Warrior = 1,
        [Display(Name = "Sihirbaz")]
        Wizard = 2,
        [Display(Name = "Destek")]
        Support = 3,
        [Display(Name = "Çıkış")]
        Exit = 4
    }
}
