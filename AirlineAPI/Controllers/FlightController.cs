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
            List<Airline> lstFlight = dal.GetFlight();
            ViewBag.Airline = new SelectList(lstFlight, "Id", "Title");
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
            return View("ReservedFlight", dal.GetFlight().Where(x => x.Title));
        }
        public IActionResult CancelFlight(string? Title)
        {
            dal.CancelFlight(Title);
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
