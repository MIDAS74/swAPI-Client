using swAPI_Client.Repos;
using swAPI_Client.Services;
using swAPI_Client.Menus;
using swAPI_Client.Menus.SpectreConsole;
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
                .AddSingleton<IConsoleOutput, SpectreConsoleOutput>()
                .AddSingleton<IConsoleInput, SpectreConsoleInput>()
                .AddSingleton<Menu>()
                .BuildServiceProvider();

            // initialise ShipService list
            var shipService = serviceProvider.GetService<IShipService>();
            await shipService.PopulateList();

            // initialize and show menu
            var consoleOutput = serviceProvider.GetService<IConsoleOutput>();
            var consoleInput = serviceProvider.GetService<IConsoleInput>();
            var menu = serviceProvider.GetService<Menu>();
            menu.Show();


            // OLD CODE
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
