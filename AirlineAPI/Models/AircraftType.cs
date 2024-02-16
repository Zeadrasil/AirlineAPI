using System.ComponentModel.DataAnnotations;

namespace AirlineAPI.Models
{
	public class AircraftType
	{
		[Required]
		public string Name { get; set; }
		[Required]
		[StringLength(3)]
		public string IATACode { get; set; }
		[Required]
		public string AircraftTypeID { get; set; }
		[Key]
		public string PlaneTypeID { get; set; }
	}
}
