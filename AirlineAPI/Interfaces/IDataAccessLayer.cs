using AirlineAPI.Models;
namespace AirlineAPI.Interfaces
{
    public interface IDataAccessLayer
    {
        IEnumerable<Flight> GetFlights(string userId);

        void AddFlight(Flight flight);
        bool RemoveFlight(Flight flight);

        Flight? GetFlight(int id);

		//void UpdateFlight(Flight Flight);
		List<Flight> searchFlights(DateOnly leaveAfter, DateOnly leaveBefore,
			string? departureIATA = null, string? arrivalIATA = null,
			DateOnly? arriveAfter = null, DateOnly? arriveBefore = null,
			string? airlineIATA = null, string? aircraftIATA = null);

	}
}
