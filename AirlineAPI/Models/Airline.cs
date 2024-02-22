using System.ComponentModel.DataAnnotations;

namespace AirlineAPI.Models
{
	public class Airline
	{
		[Required]
		[MaxLength(255)]
		public string Title { get; set; }
		[Key]
		[MinLength(2)]
		[MaxLength(3)]
		public string IATACode { get; set; }
		[Required]
		[StringLength(3)]
		public string IATAAccounting {  get; set; }
		[Required]
		[StringLength(3)]
		public string ICAOCode { get; set; }
		[Required]
		public string Callsign { get; set; }
		[Required]
		public string Type { get; set; }
		[Required]
		public string Status { get; set; }
		[Required]
		[Range(1, int.MaxValue)]
		public int FleetSize { get; set; }
		[Required]
		[Range(0, float.MaxValue)]
		public float FleetAge { get; set; }
		[Required]
		public DateTime Founded { get; set; }
		[Required]
		[StringLength(2)]
		public string CountryISO { get; set; }
		public Airline(string title, string iATACode, string iATAAccounting, string iCAOCode, string callsign, string type, string status, int fleetSize, float fleetAge, DateTime founded, string countryISO)
		{
			Title = title;
			IATACode = iATACode;
			IATAAccounting = iATAAccounting;
			ICAOCode = iCAOCode;
			Callsign = callsign;
			Type = type;
			Status = status;
			FleetSize = fleetSize;
			FleetAge = fleetAge;
			Founded = founded;
			CountryISO = countryISO;
		}

		public Airline() { }
	}
}
