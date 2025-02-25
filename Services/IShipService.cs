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
