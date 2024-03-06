using AirlineAPI.Interfaces;
using AirlineAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace AirlineAPI.Data
{
    public class FlightListDal : IDataAccessLayer
    {
        private ApplicationDbContext db;
        List<Airline> Airlines;
        public FlightListDal (ApplicationDbContext indb)
        {
            db = indb;
        }

        public void AddFlight(Flight flight)
        {
            db.Flights.Add(flight);
            db.SaveChanges();
        }

        public Flight? GetFlight(int id)
        {
            return db.Flights.Where(f => f.Id == id).FirstOrDefault();
        }

        public IEnumerable<Airline> GetFlight()
        {
            //return MovieList;
            return db.Airlines;
        }

        public bool RemoveFlight(Flight flight)
        {
            db.Flights.Remove(flight);
            db.SaveChanges();
            return true;
        }


        public List<Flight> searchFlights(DateOnly leaveAfter, DateOnly leaveBefore, string? departureIATA = null, string? arrivalIATA = null, DateOnly? arriveAfter = null, DateOnly? arriveBefore = null, string? airlineIATA = null, string? aircraftIATA = null)
        {
            return APIAccessor.getFlights(leaveAfter, leaveBefore, departureIATA, arrivalIATA, arriveAfter, arriveBefore, airlineIATA, 0, aircraftIATA).Result;
        }

        public IEnumerable<Flight> GetFlights(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
