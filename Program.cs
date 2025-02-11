using Spectre.Console;

using System.Net.Http;

namespace swAPI_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // initialize application menu, repos and services
            var menu = new Menu();

            //// test that API is reachable
            //var httpClient = new HttpClient();
            //httpClient.BaseAddress = new System.Uri("https://swapi.dev/api/");
            //var response = httpClient.GetAsync("starships/").Result;
            //Console.WriteLine(response);

            // show menu
            menu.Show();
        }
    }
}
