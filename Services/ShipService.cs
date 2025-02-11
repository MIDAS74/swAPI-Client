using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swAPI_Client.Models;
using swAPI_Client.Repos;

namespace swAPI_Client.Services
{
    internal class ShipService
    {
        private List<Ship> ships = new List<Ship>();

        public void GetShips()
        {
            ShipRepo shipRepo = new ShipRepo();
            ships.Add(shipRepo.GetShipsAsync)
        }
    }
}
