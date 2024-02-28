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
            List<Flight> lstFlight = dal.Airlines();
            ViewBag.Flight = new SelectList(lstFlight, "Id", "Title");
            return View();

            
        }

        public IActionResult GetFlight(int? Id)
        {
            
                if (Id == null)
                {
                    return BadRequest(); 
                }

                
                Flight foundFlight = db.Airlines.FirstOrDefault(f => f.Id == Id);

                if (foundFlight == null)
                {
                    return NotFound(); 
                }

                return View(foundFlight); 
            
        }

        public IActionResult GetReservedFlight(int? id, int? FlightNumber)
        {
            
            return View(Flight);
        }

        public IActionResult SearchFlight(int FlightNumber)
        {

            if (string.IsNullOrEmpty(Airline))
            {
                return View("ReservedFlight", dal.FlightNumber);
            }
            return View("ReservedFlight", dal.GetReservedFlight().Where(x => x.FlightNumber));
        }
        public IActionResult CancelFlight(int? Id)
        {
            dal.RemoveMovie(Id);
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
