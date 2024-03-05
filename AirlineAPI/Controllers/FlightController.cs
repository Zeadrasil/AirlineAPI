using Microsoft.AspNetCore.Mvc;
using AirlineAPI.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc.Rendering;
using AirlineAPI.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AirlineAPI.Data;
using System.Security.Claims;

namespace AirlineAPI.Controllers
{
    public class FlightController : Controller
    {
        IDataAccessLayer dal;
        private readonly APIAccessor apiAccessor;

        

        private ApplicationDbContext db;

        public FlightController(IDataAccessLayer indal, APIAccessor apiAccessor)
        {
            dal = indal;
            this.apiAccessor = apiAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetFlight(string? Title)
        {

            if (Title == null)
            {
                return BadRequest();
            }


            Airline? foundFlight = db.Airlines.FirstOrDefault(f => f.Title == Title);

            if (foundFlight == null)
            {
                return NotFound();
            }

            return View(foundFlight);

        }

        public IActionResult GetReservedFlight(string? Title, string? CountryISO)
        {

            return View(Title, CountryISO);
        }

        public IActionResult SearchFlight(string Title)
        {

            if (string.IsNullOrEmpty(Title))
            {
                return View("ReservedFlight", dal.AddFlight);
            }
            //return View("ReservedFlight", dal.GetFlight().Where(x => x.Title));
            return View();
        }
        public IActionResult CancelFlight(string? Title)
        {
            //dal.CancelFlight(Title);
            TempData["success"] = "Flight removed!";
            return RedirectToAction("ReservedFlight", "Flight");

        }

        // this might work idk
        public async Task<IActionResult> ListFlights()
        {
            DateOnly leaveAfter = DateOnly.FromDateTime(DateTime.UtcNow);
            DateOnly leaveBefore = leaveAfter.AddDays(7);

            string departureIATA = "JFK";
            string arrivalIATA = "LAX";

            // Call APIAccessor to get flights
            var flights = await APIAccessor.getFlights(leaveAfter, leaveBefore, departureIATA, arrivalIATA);

            // Pass the flights to the view
            return View(flights); // Return the result of the action
        }



        public IActionResult deleteFlight()
        {
            return View();
        }

        //public Flight? getFlight() 
        //{
        //    Flight? foundflight = 
        //    return foundflight();
        //}
    }
}
