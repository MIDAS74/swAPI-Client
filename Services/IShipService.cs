using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swAPI_Client.Services
{
    public interface IShipService
    {
        Task PopulateList();
        List<string> ListShips();
        List<string> CalculatePitstops(decimal megalights);
        string GetShipByName(string name);
    }
}
