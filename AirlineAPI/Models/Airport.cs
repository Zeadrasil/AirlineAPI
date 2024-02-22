using System.ComponentModel.DataAnnotations;

namespace AirlineAPI.Models
{
	public class Airport
	{
		[Required]
		public string Name { get; set; }
		[Key]
		[StringLength(3)]
		public string IATACode { get; set; }
		[Required]
		public float Latitude { get; set; }
		[Required]
		public float Longitude { get; set; }
		[Required]
		public float GMTOffset { get; set; }
		[Required]
		[MinLength(2)]
		[MaxLength(3)]
		public string CountryISO { get; set; }
		[Required]
		public string CountryName { get; set; }
		[StringLength(3)]
		public string? CityIATA { get; set; }
	}
}
