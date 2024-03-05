using AirlineAPI.Data;
using AirlineAPI.Interfaces;
using AirlineAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Claims;

namespace AirlineAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IDataAccessLayer dal;
        public HomeController(ILogger<HomeController> logger, IDataAccessLayer indal)
        {
            _logger = logger;
            dal = indal;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize]
        public IActionResult Search()
        {
            return View();
        }

        [Authorize]
        public IActionResult ReservationPage()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult FindResults(string leaveAfter, string leaveBefore, 
            string? departureIATA = null, string? arrivalIATA = null, 
            string? arriveAfter = null, string? arriveBefore = null, 
            string? airlineIATA = null, string? aircraftIATA = null)
        {
            List<Flight> flights = dal.searchFlights(Helpers.getDateFromString(leaveAfter),
                Helpers.getDateFromString(leaveBefore), departureIATA, arrivalIATA,
                string.IsNullOrEmpty(arriveAfter) ? null : Helpers.getDateFromString(arriveAfter),
                string.IsNullOrEmpty(arriveBefore) ? null : Helpers.getDateFromString(arriveBefore),
                airlineIATA, aircraftIATA);
            TempData["results"] = JsonConvert.SerializeObject(flights.ToArray());
            return View("SearchResults", flights);
        }
        [Authorize]
        public IActionResult SearchResults(List<Flight> results)
        {
            return View(results);
        }
        [Authorize]
        public IActionResult AddFlight(Flight addedFlight)
        {
            List<Flight> flights = new List<Flight>();
            flights.AddRange(JsonConvert.DeserializeObject<Flight[]>(TempData["results"] as string));
            int index = flights.IndexOf(addedFlight);
            addedFlight.ReserverID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dal.AddFlight(addedFlight);
            flights[index] = addedFlight;
            return View("SearchResults", flights);
        }
    }
}
