using System.ComponentModel.DataAnnotations;

namespace AirlineAPI.Models
{
	public class Flight
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public DateTime ScheduledDeparture { get; set; }
		[Range(0, 9999)]
		[Required]
		public int FlightNumber { get; set; }
		[Required]
		[StringLength(3)]
		public string AirlineIATA { get; set; }

		public DateTime? EstimatedDeparture { get; set; }
		[Required]
		public string DepartureTerminal { get; set; }
		public string? ArrivalTerminal { get; set; }
		[Required]
		public string DepartureIATA { get; set; }
		[Required]
		public string ArrivalIATA { get; set; }
		[Required]
		public string Status { get; set; }
		[Required]
		public DateTime ScheduledArrival { get; set; }
		public DateTime? EstimatedArrival { get; set; }
		[Required]
		public int ReserverID {  get; set; }
		[Required]
		public string DepartureGate { get; set; }
		public string? ArrivalGate { get; set; }
	}
}
