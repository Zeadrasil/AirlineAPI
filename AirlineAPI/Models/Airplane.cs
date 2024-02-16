using System.ComponentModel.DataAnnotations;

namespace AirlineAPI.Models
{
	public class Airplane
	{
		[Key]
		[MinLength(2)]
		[MaxLength(6)]
		public string RegistrationCode { get; set; }

	}
}
