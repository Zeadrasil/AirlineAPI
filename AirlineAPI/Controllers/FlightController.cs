using Microsoft.AspNetCore.Mvc;
using AirlineAPI.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc.Rendering;
using AirlineAPI.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AirlineAPI.Data;

namespace AirlineAPI.Controllers
{
    public class FlightController : Controller
    {
        IDataAccessLayer dal;

        

        private ApplicationDbContext db;

        public FlightController(IDataAccessLayer indal)
        {
            dal = indal;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddFlight()
        {
            List<Flight> lstFlight = dal.GetFlight();
            ViewBag.Flight = new SelectList(lstFlight, "Id", "Title");
            return View();


        }

        public IActionResult GetFlight(int? flightNumber)
        {

            if (flightNumber == null)
            {
                return BadRequest();
            }


            Flight? foundFlight = db.Flights.FirstOrDefault(f => f.FlightNumber == flightNumber);

            if (foundFlight == null)
            {
                return NotFound();
            }

            return View(foundFlight);

        }

        public IActionResult GetReservedFlight(int? FlightNumber, string? Status)
        {
            Flight flight = dal.GetFlightByFlightNumber(FlightNumber.Value);
            
            return View(flight);
        }

        public IActionResult SearchFlight(int? FlightNumber)
        {

            if (FlightNumber != null )
            {
                return View("ReservedFlight", dal.GetFlightByFlightNumber(FlightNumber.Value));
            }
            else
            {
                return BadRequest("Nothing found");
            }
            
        }

        public IActionResult CancelFlight(int? id)
        {
            dal.RemoveFlight(id);
            TempData["success"] = "Flight removed!";
            return RedirectToAction("ReservedFlight", "Flight");

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
