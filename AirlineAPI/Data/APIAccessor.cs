using AirlineAPI.Models;
using Newtonsoft.Json;

namespace AirlineAPI.Data
{
	public class APIAccessor
	{
		static HttpClient client = new HttpClient();
		static string[] apiKeys = new string[1]
		{
			"example"
		};
		public static async Task<List<Flight>?> getFlights(string departureIATA, string arrivalIATA, 
			string? airlineIATA = null, int flightNumber = 0)
		{
			int attempts = 0;
			HttpResponseMessage response = null;
			do
			{
				string address = "https://api.aviationstack.com/v1/flights?access_key=" + getKey();
				address += "&dep_iata=" + departureIATA;
				address += "&arr_iata=" + arrivalIATA;
				address += airlineIATA != null ? "&airline_iata=" + airlineIATA : "";
				address += flightNumber > 0 ? "&flight_number=" + flightNumber : "";
				response = await client.GetAsync(address);
				attempts++;
			}
			while (!response.IsSuccessStatusCode && attempts < 50);
			if(response.IsSuccessStatusCode)
			{
				string result = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<Flight>>(result);
			}
			return null;
		}
		private static string getKey()
		{
			return apiKeys[new Random().Next(apiKeys.Length)];
		}

	}
}
