using Spectre.Console;
using swAPI_Client.Services;
using System.Net.Http;

namespace swAPI_Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // initialize application menu, repos and services
            var menu = new Menu();
            var shipService = new ShipService();

            // populate ship list
            await shipService.PopulateList();



            // show menu
            menu.Show(shipService);
        }
    }
}
