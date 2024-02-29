using AirlineAPI.Models;
namespace AirlineAPI.Interfaces
{
    public interface IDataAccessLayer
    {
        IEnumerable<Flight> GetMovies();

        void AddFlight(Flight Flight);
        void RemoveFlight(int? id);

        Flight? GetFlight(int? id);

        //void UpdateFlight(Flight Flight);
    }
}
