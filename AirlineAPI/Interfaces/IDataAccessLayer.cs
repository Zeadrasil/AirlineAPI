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
		List<Flight> searchFlights(DateOnly leaveAfter, DateOnly leaveBefore,
			string? departureIATA = null, string? arrivalIATA = null,
			DateOnly? arriveAfter = null, DateOnly? arriveBefore = null,
			string? airlineIATA = null, string? aircraftIATA = null);

	}
}
