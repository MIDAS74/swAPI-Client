using swAPI_Client.Models;

namespace swAPI_Client.Repos
{
    public interface IShipRepo
    {
        Task<List<Ship>> GetShipsAsync();
    }
}
