using AirlineAPI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AirlineAPI.Data
{
	public class APIAccessor
	{
		static HttpClient client = new HttpClient();
		static string[] apiKeys = new string[1]
		{
			"example"
		};
		public static async Task<List<Flight>?> getFlights(DateOnly leaveAfter, DateOnly leaveBefore, 
			string departureIATA, string arrivalIATA, DateOnly? arriveAfter = null, DateOnly? arriveBefore = null,
			string? airlineIATA = null, int flightNumber = 0, string? aircraftIATA = null)
		{
			List<Flight> flights = new List<Flight>();
			do
			{
				do
				{
					int attempts = 0;
					HttpResponseMessage response = null;
					do
					{
						string address = "https://api.aviationstack.com/v1/flights?access_key=" + getKey();
						address += "&dep_iata=" + departureIATA;
						address += "&arr_iata=" + arrivalIATA;
						address += !string.IsNullOrEmpty(airlineIATA) ? "&airline_iata=" + airlineIATA : "";
						address += flightNumber > 0 ? "&flight_number=" + flightNumber : "";
						address += arriveAfter != null ? "&arr_scheduled_time_arr=" + arriveAfter?.ToString("yyyy-MM-dd") : "";
						address += "&arr_scheduled_time_dep=" + leaveAfter.ToString("yyyy-MM-dd");
						response = await client.GetAsync(address);
						attempts++;
					}
					while (!response.IsSuccessStatusCode && attempts < 50);
					if (response.IsSuccessStatusCode)
					{
						string result = await response.Content.ReadAsStringAsync();
						flights.AddRange(parseFlight(result));
					}
					arriveAfter?.AddDays(1);
				}
				while (arriveAfter != null && arriveBefore != null && arriveAfter < arriveBefore);
				leaveAfter.AddDays(1);
			}
			while (leaveAfter < leaveBefore);
			return flights;
		}
		private static string getKey()
		{
			return apiKeys[new Random().Next(apiKeys.Length)];
		}

		private static List<Flight> parseFlight(string json)
		{
			JObject details = JObject.Parse(File.ReadAllText("C:\\Users\\dgriffith\\Videos\\bruh.txt"));
			List<Flight> flights = new List<Flight>();
			foreach (var stuff in details["data"])
			{
				Flight flight = new Flight();
				flight.ScheduledDeparture = DateTime.Parse(stuff["departure"]["scheduled"].ToString());
				flight.FlightNumber = int.Parse(stuff["flight"]["number"].ToString());
				flight.AirlineIATA = stuff["airline"]["iata"].ToString();
				flight.EstimatedDeparture = stuff["departure"]["actual"].ToString().Length > 0 ? DateTime.Parse(stuff["departure"]["actual"].ToString()) : DateTime.Parse(stuff["departure"]["estimated"].ToString());
				flight.DepartureTerminal = stuff["departure"]["terminal"].ToString();
				flight.ArrivalTerminal = stuff["arrival"]["terminal"].ToString();
				flight.DepartureIATA = stuff["departure"]["iata"].ToString();
				flight.ArrivalIATA = stuff["arrival"]["iata"].ToString();
				flight.Status = stuff["flight_status"].ToString();
				flight.ScheduledArrival = DateTime.Parse(stuff["arrival"]["scheduled"].ToString());
				flight.EstimatedArrival = stuff["arrival"]["actual"].ToString().Length > 0 ? DateTime.Parse(stuff["arrival"]["actual"].ToString()) : DateTime.Parse(stuff["arrival"]["estimated"].ToString());
				flight.DepartureGate = stuff["departure"]["gate"].ToString();
				flight.ArrivalGate = stuff["arrival"]["gate"].ToString();
				flights.Add(flight);
			}
			return flights;
		}

	}
}
