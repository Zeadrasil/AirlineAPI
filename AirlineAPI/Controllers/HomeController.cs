using AirlineAPI.Data;
using AirlineAPI.Interfaces;
using AirlineAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        public IActionResult Search()
        {
            return View();
        }

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

        public IActionResult SearchResults(string leaveAfter, string leaveBefore, 
            string? departureIATA = null, string? arrivalIATA = null, 
            string? arriveAfter = null, string? arriveBefore = null, 
            string? airlineIATA = null, string? aircraftIATA = null)
        {
            return View(dal.searchFlights(DateOnly.FromDateTime(Helpers.getDateTimeFromString(leaveAfter)), 
                DateOnly.FromDateTime(Helpers.getDateTimeFromString(leaveBefore)), departureIATA, arrivalIATA, 
                string.IsNullOrEmpty(arriveAfter) ? null : DateOnly.FromDateTime(Helpers.getDateTimeFromString(arriveAfter)),
                string.IsNullOrEmpty(arriveBefore) ? null : DateOnly.FromDateTime(Helpers.getDateTimeFromString(arriveBefore)), airlineIATA, aircraftIATA));
        }

    }
}
