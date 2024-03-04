using AirlineAPI.Models;

namespace AirlineAPI.Interfaces
{
    public interface IDataAccessLayer
    {
        List<Airline> GetFlight();



        void AddFlight(Airline airline);

        void CancelFlight(string? Title);

        Airline? GetFlight(string? Title);

        IEnumerable<Airline> FilterAirlines(string? title, string? countryiso);
        
    }
}
