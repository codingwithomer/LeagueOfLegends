using LeagueOfLegends.App.Infrastructure;
using LeagueOfLegends.Business.Abstractions;
using LeagueOfLegends.Business.Concretes;
using LeagueOfLegends.Character.Factory;
using LeagueOfLegends.Common.Validators.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace LeagueOfLegends.App.DependencyResolver
{
    /// <summary>
    /// Registers application dependencies in the DI container.
    /// </summary>
    public static class DependencyInjectionConfig
    {
        /// <summary>
        /// Adds all services required by the application layers.
        /// </summary>
        /// <param name="services">Target service collection.</param>
        /// <returns>The same service collection for chaining.</returns>
        public static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGameConsole, SystemGameConsole>();

            services.AddScoped<CharacterManager>();
            services.AddScoped<ICharacterSelectionService>(sp => sp.GetRequiredService<CharacterManager>());
            services.AddScoped<ICharacterResultService>(sp => sp.GetRequiredService<CharacterManager>());

            services.AddScoped<HealthEquipmentManager>();
            services.AddScoped<IEquipmentSelectionService>(sp => sp.GetRequiredService<HealthEquipmentManager>());

            services.AddScoped<IGameService, GameManager>();
            services.AddScoped<ICharacterFactory, CharacterFactory>();
            services.AddScoped<ICharacterEquipmentService, CharacterEquipmentService>();
            services.AddScoped<ISelectionValidator, SelectionValidator>();
            services.AddScoped<ICharacterFormatter, CharacterFormatter>();

            return services;
        }
    }
}
