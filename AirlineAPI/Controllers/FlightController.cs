using Microsoft.AspNetCore.Mvc;
using AirlineAPI.Models;

namespace AirlineAPI.Controllers
{
    public class FlightController : Controller
    {
         
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddFlight()
        {

            return View();
        }

        public IActionResult CancelFlight()
        {
            return View();
        }

        public IActionResult SearchFlight() 
        {
            return View();
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
