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
        List<Airline> Airlines;
        public FlightListDal (ApplicationDbContext indb)
        {
            db = indb;
        }

        public void AddFlight(Airline airline)
        {
            //MovieList.Add(movie);
            db.Airlines.Add(airline);
            db.SaveChanges();
        }

        public Airline? GetFlight(string? Title)
        {
            //Movie? foundMovie = MovieList.Where(movie => movie.Id == id).FirstOrDefault();
            Airline? foundAirline = db.Airlines.Where(airline => airline.Title == Title).FirstOrDefault();
            return foundAirline;
        }

        public IEnumerable<Airline> GetFlight()
        {
            //return MovieList;
            return db.Airlines;
        }

        public void CancelFlight(string? title)
        {
            Airline? foundAirlines = GetFlight(title);
            if (foundAirlines != null)
            {
                //MovieList.Remove(foundMovie);
                db.Airlines.Remove(foundAirlines);
                db.SaveChanges();
            }
        }


        public List<Airline> FilterFlights(string? title, string? countryiso)
        {
            // Check for null inputs and handle empty string case
            title ??= string.Empty;
            countryiso ??= string.Empty;

            // Get all flights if both title and countryiso are empty
            if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(countryiso))
                return GetFlight().ToList();

            // Get all flights
            var allFlights = GetFlight();

            // Filter flights by title
            var flightsByTitle = allFlights.Where(m => !string.IsNullOrEmpty(m.Title) && m.Title.ToLower().Contains(title.ToLower()));

            // Filter flights by country ISO
            var flightsByCountryISO = allFlights.Where(m => !string.IsNullOrEmpty(m.CountryISO) && m.CountryISO.ToLower().Contains(countryiso.ToLower()));

            // Return flights that match both conditions
            return flightsByTitle.Intersect(flightsByCountryISO).ToList();
        }

        List<Airline> IDataAccessLayer.GetFlight()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Airline> FilterAirlines(string? title, string? countryiso)
        {
            throw new NotImplementedException();
        }
    }
}
