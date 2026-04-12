using LeagueOfLegends.App.DependencyResolver;
using LeagueOfLegends.Business.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace LeagueOfLegends.App
{
    /// <summary>
    /// Application entry point that configures dependency injection and starts the game flow.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Bootstraps services and executes the game use case.
        /// </summary>
        /// <param name="args">Command-line arguments (currently unused).</param>
        private static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            DependencyInjectionConfig.ConfigureServices(services);

            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            using IServiceScope scope = serviceProvider.CreateScope();

            IGameService gameService = scope.ServiceProvider.GetRequiredService<IGameService>();
            gameService.Intro();
            gameService.Run();
        }
    }
}
