using AirlineAPI.Interfaces;
using AirlineAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AirlineAPI.Data
{
    public class FlightListDal : IDataAccessLayer
    {
        private ApplicationDbContext db;
        //List<Airline> Airlines;
        public FlightListDal (ApplicationDbContext indb)
        {
            db = indb;
        }

        public void AddFlight(Flight flight)
        {
            db.Flights.Add(flight);
            db.SaveChanges();
        }

        public Flight? GetFlight(int? id)
        {
            //Movie? foundMovie = MovieList.Where(movie => movie.Id == id).FirstOrDefault();
            Flight? foundFlight = db.Flights.FirstOrDefault(f => f.Id == id);
            return foundFlight;
        }

        public List<Flight> GetFlight()
        {
            throw new NotImplementedException();
        }

        public Flight? GetFlightByFlightNumber(int FlightNumber)
        {
            return db.Flights.FirstOrDefault(f => f.FlightNumber == FlightNumber);
        }

        public IEnumerable<Flight> GetFlights()
        {
            //return MovieList;
            return db.Flights;
        }

        //public void CancelFlight(string? title)
        //{
        //    Airline? foundAirlines = GetFlight(title);
        //    if (foundAirlines != null)
        //    {
        //        //MovieList.Remove(foundMovie);
        //        db.Airlines.Remove(foundAirlines);
        //        db.SaveChanges();
        //    }
        //}


        //public List<Airline> FilterFlights(string? title, string? countryiso)
        //{
        //    // Check for null inputs and handle empty string case
        //    title ??= string.Empty;
        //    countryiso ??= string.Empty;

        //    // Get all flights if both title and countryiso are empty
        //    if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(countryiso))
        //        return GetFlight().ToList();

        //    // Get all flights
        //    var allFlights = GetFlight();

        //    // Filter flights by title
        //    var flightsByTitle = allFlights.Where(m => !string.IsNullOrEmpty(m.Title) && m.Title.ToLower().Contains(title.ToLower()));

        //    // Filter flights by country ISO
        //    var flightsByCountryISO = allFlights.Where(m => !string.IsNullOrEmpty(m.CountryISO) && m.CountryISO.ToLower().Contains(countryiso.ToLower()));

        //    // Return flights that match both conditions
        //    return flightsByTitle.Intersect(flightsByCountryISO).ToList();
        //}

        public void RemoveFlight(int? id)
        {
            db.Flights.Remove(GetFlight(id));
            db.SaveChanges();
        }

        public List<Flight> searchFlights(DateOnly leaveAfter, DateOnly leaveBefore, string? departureIATA = null, string? arrivalIATA = null, DateOnly? arriveAfter = null, DateOnly? arriveBefore = null, string? airlineIATA = null, string? aircraftIATA = null)
        {
            return db.Flights.Where(f => f.DepartureIATA.Equals(departureIATA) || f.ArrivalIATA.Equals(arrivalIATA) || f.AirlineIATA.Equals(airlineIATA)).ToList();
        }
        public List<Flight> findFlights(DateOnly leaveAfter, DateOnly leaveBefore, string? departureIATA = null, string? arrivalIATA = null, DateOnly? arriveAfter = null, DateOnly? arriveBefore = null, string? airlineIATA = null, string? aircraftIATA = null)
        {
            return APIAccessor.getFlights(leaveAfter, leaveBefore, departureIATA, arrivalIATA, arriveAfter, arriveBefore, airlineIATA, -1, aircraftIATA).Result;
        }

        public List<Flight> GetFlights(string userId)
        {
            return db.Flights.Where(f => f.ReserverID ==  userId).ToList();
        }

        public Airline? getAirline(string airlineIATA)
        {
            return db.Airlines.Where(a => a.IATACode == airlineIATA).FirstOrDefault();
        }
    }
}
