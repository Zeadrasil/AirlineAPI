using AirlineAPI.Controllers;
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
			JObject details = JObject.Parse(json);
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

		private static List<Airport> parseAirport(string json)
		{
			JObject details = JObject.Parse(json);
			List<Airport> airports = new List<Airport>();
			foreach(var stuff in details["data"])
			{
				Airport airport = new Airport();
				airport.IATACode = stuff["iata_code"].ToString();
				airport.Latitude = float.Parse(stuff["latitude"].ToString());
				airport.Longitude = float.Parse(stuff["longitude"].ToString());
				airport.GMTOffset = float.Parse(stuff["gmt"].ToString());
				airport.CountryISO = stuff["country_iso2"].ToString();
				airport.CityIATA = stuff["city_iata_code"].ToString();
				airports.Add(airport);
			}
			return airports;
		}

		private static List<Airline> parseAirline(string json)
		{
			JObject details = JObject.Parse(json);
			List<Airline> airlines = new List<Airline>();
			foreach(var stuff in details["data"])
			{
				Airline airline = new Airline();
				airline.Title = stuff["airline_name"].ToString();
				airline.IATACode = stuff["iata_code"].ToString();
				airline.ICAOCode = stuff["icao_code"].ToString();
				airline.IATAAccounting = stuff["iata_prefix_accounting"].ToString();
				airline.Callsign = stuff["callsign"].ToString();
				airline.FleetSize = int.Parse(stuff["fleet_size"].ToString());
				airline.FleetAge = float.Parse(stuff["fleet_average_age"].ToString());
				try
				{
					airline.Founded = DateTime.Parse(stuff["date_founded"].ToString());
				}
				catch
				{
					airline.Founded = new DateTime();
					airline.Founded = airline.Founded.AddYears(int.Parse(stuff["date_founded"].ToString()) - 1);
				}
				airline.CountryISO = stuff["country_iso2"].ToString();
				airlines.Add(airline);
			}
			return airlines;
		}

		private static List<Airplane> parseAirplane(string json)
		{
			JObject details = JObject.Parse(json);
			List<Airplane> airplanes = new List<Airplane>();
			foreach (var stuff in details["data"])
			{
				Airplane airplane = new Airplane();
				airplane.RegistrationCode = stuff["registration_number"].ToString();
				airplane.ProductionLine = stuff["production_line"].ToString();
				airplane.ModelName = stuff["model_name"].ToString();
				airplane.ModelCode = stuff["model_code"].ToString();
				airplane.ICAOHex = stuff["icao_code_hex"].ToString();
				airplane.ShortIATACode = stuff["iata_code_short"].ToString();
				airplane.ConstructionID = stuff["construction_number"].ToString();
				airplane.TestNumber = stuff["test_registration_number"].ToString();
				airplane.RolloutDate = DateTime.TryParse(stuff["rollout_date"].ToString(), out DateTime datetime) ? datetime : null;
				airplane.FirstFlight = DateTime.TryParse(stuff["first_flight_date"].ToString(), out datetime) ? datetime : null;
				airplane.DeliveryDate = DateTime.TryParse(stuff["delivery_date"].ToString(), out datetime) ? datetime : null;
				airplane.RegistrationDate = DateTime.TryParse(stuff["registration_date"].ToString(), out datetime) ? datetime : DateOnly.TryParse(stuff["registration_date"].ToString(), out DateOnly date) ? date.ToDateTime(new TimeOnly()) : Helpers.getDateTimeFromString(stuff["registration_date"].ToString());
				airplane.OwnerIATACode = stuff["airline_iata_code"].ToString();
				airplane.EngineCount = int.Parse(stuff["engines_count"].ToString());
				airplane.EngineType = stuff["engines_type"].ToString();
				airplane.Age = float.Parse(stuff["plane_age"].ToString());
				airplane.Status = stuff["plane_status"].ToString();
				airplane.ClassData = stuff["plane_class"].ToString();
				airplanes.Add(airplane);
			}
			return airplanes;
		}

        private static List<AircraftType> parseAircraftType(string json)
        {
			JObject details = JObject.Parse(json);
			List<AircraftType> aircraftTypes = new List<AircraftType>();
			foreach (var stuff in details["data"])
			{
				AircraftType aircraftType = new AircraftType();
				aircraftType.Name = stuff["name"].ToString();
				aircraftType.IATACode = stuff["iata_code"].ToString();
				aircraftType.AircraftTypeID = stuff["aircraf_type_id"].ToString();
				aircraftType.PlaneTypeID = stuff["plane_type_id"].ToString();
				aircraftTypes.Add(aircraftType);
			}

			return aircraftTypes;
        }

	}
}
