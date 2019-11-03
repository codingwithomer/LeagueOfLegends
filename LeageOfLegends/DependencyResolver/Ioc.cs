using LeagueOfLegends.Business;
using LeagueOfLegends.Business.Abracts;
using LeagueOfLegends.Business.Concretes;
using LeagueOfLegends.Character.Factory;
using LeagueOfLegends.Common.Validators.Abracts;
using LeagueOfLegends.Common.Validators.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeageOfLegends.DependencyResolver
{
    public static class Ioc
    {
        private static ServiceProvider _serviceProvider;

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGameService, GameManager>();
            services.AddScoped<IHealthEquipmentService, HealthEquipmentManager>();
            services.AddScoped<ICharacterService, CharacterManager>();
            services.AddScoped<ICharacterFactory, CharacterFactory>();
            services.AddScoped<IValidatorFactory, ValidatorFactory>();


            _serviceProvider = services.BuildServiceProvider();
        }

        public static T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }
}
