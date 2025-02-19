using swAPI_Client.Repos;
using swAPI_Client.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace swAPI_Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // configure service provider and http client
            var serviceProvider = new ServiceCollection()
                .AddSingleton<HttpClient>()
                .AddSingleton<IShipRepo, ShipRepo>()
                .AddSingleton<IShipService, ShipService>()
                .AddSingleton<Menu>()
                .BuildServiceProvider();

            var menu = serviceProvider.GetService<Menu>();
            menu.Show();

            //// initialize application menu, repos and services
            //var menu = new Menu();
            //var shipService = new ShipService();

            //// populate ship list
            //await shipService.PopulateList();

            //// show menu
            //menu.Show(shipService);
        }
    }
}
