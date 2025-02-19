using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swAPI_Client.Models;

namespace swAPI_Client.Repos
{
    public interface IShipRepo
    {
        Task<List<Ship>> GetShipsAsync(HttpClient httpClient);
    }
}
