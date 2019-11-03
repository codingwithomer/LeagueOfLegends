using LeageOfLegends.DependencyResolver;
using LeagueOfLegends.Business;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeageOfLegends
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().Build();

            IServiceCollection services = new ServiceCollection();

            Ioc.ConfigureServices(services, configuration);

            IGameService gameService = Ioc.GetService<IGameService>();

            gameService.Intro();

            gameService.Run();
        }
    }
}