using System.ComponentModel.DataAnnotations;

namespace AirlineAPI.Models
{
	public class Airplane
	{
		[Key]
		[MinLength(2)]
		[MaxLength(6)]
		public string RegistrationCode { get; set; }
		[Required]
		public string ProductionLine { get; set; }
		[Required]
		public string ModelName { get; set; }
		[Required]
		public string ModelCode { get; set; }
		[Required]
		public int ICAOHex { get; set; }
		[Required]
		[StringLength(3)]
		public string ShortIATACode { get; set; }
		[Required]
		public string ConstructionID { get; set; }
		[Required]
		[MinLength(2)]
		[MaxLength(6)]
		public string TestNumber { get; set; }
		[Required]
		public DateTime RolloutDate { get; set; }
		[Required]
		public DateTime FirstFlight {  get; set; }
		[Required]
		public DateTime DeliveryDate { get; set; }
		[Required]
		public DateTime RegistrationDate { get; set; }
		[Required]
		[MinLength(2)]
		[MaxLength(3)]
		public string OwnerIATACode { get; set; }
		[Required]
		[Range(1, 14)]
		public int EngineCount { get; set; }
		[Required]
		public string EngineType {  get; set; }
		[Required]
		[Range(0, 300)]
		public float Age { get; set; }
		[Required]
		public string Status { get; set; }
		[Required]
		public string ClassData { get; set; }

		public Airplane() { }
		public Airplane(string registrationCode, string productionLine, string modelName, string modelCode, int iCAOHex, string shortIATACode, string constructionID, string testNumber, DateTime rolloutDate, DateTime firstFlight, DateTime deliveryDate, DateTime registrationDate, string ownerIATACode, int engineCount, string engineType, float age, string status, string classData)
		{
			RegistrationCode = registrationCode;
			ProductionLine = productionLine;
			ModelName = modelName;
			ModelCode = modelCode;
			ICAOHex = iCAOHex;
			ShortIATACode = shortIATACode;
			ConstructionID = constructionID;
			TestNumber = testNumber;
			RolloutDate = rolloutDate;
			FirstFlight = firstFlight;
			DeliveryDate = deliveryDate;
			RegistrationDate = registrationDate;
			OwnerIATACode = ownerIATACode;
			EngineCount = engineCount;
			EngineType = engineType;
			Age = age;
			Status = status;
			ClassData = classData;
		}
	}
}
