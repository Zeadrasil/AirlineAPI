﻿using AirlineAPI.Models;
namespace AirlineAPI.Interfaces
{
    public interface IDataAccessLayer
    {
        IEnumerable<Flight> GetFlights();
        List<Flight> GetFlights(string userId);

        void AddFlight(Flight flight);
        void RemoveFlight(int? id);

        Flight? GetFlight(int? id);

        Flight? GetFlightByFlightNumber(int FlightNumber);

		//void UpdateFlight(Flight Flight);
		List<Flight> searchFlights(DateOnly leaveAfter, DateOnly leaveBefore,
			string? departureIATA = null, string? arrivalIATA = null,
			DateOnly? arriveAfter = null, DateOnly? arriveBefore = null,
			string? airlineIATA = null, string? aircraftIATA = null);
        List<Flight> GetFlight();
        public List<Flight> findFlights(DateOnly leaveAfter, DateOnly leaveBefore,
            string? departureIATA = null, string? arrivalIATA = null,
            DateOnly? arriveAfter = null, DateOnly? arriveBefore = null,
            string? airlineIATA = null, string? aircraftIATA = null);

        public Airline? getAirline(string airlineIATA);
    }
}
