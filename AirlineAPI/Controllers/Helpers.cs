namespace AirlineAPI.Controllers
{
	public abstract class Helpers
	{

		public static DateTime getDateTimeFromString(string str)
		{
			DateTime dt = new DateTime();
			if (int.Parse(str.Substring(0, 4)) > 0)
			{
				dt.AddYears(int.Parse(str.Substring(0, 4)) - 1);
			}
			if (int.Parse(str.Substring(5, 2)) > 0)
			{
				dt.AddMonths(int.Parse(str.Substring(5, 2)) - 1);
			}
			if (int.Parse(str.Substring(8, 2)) > 0)
			{
				dt.AddDays(int.Parse(str.Substring(8, 2)) - 1);
			}
			return dt;
		}
		public static DateOnly getDateFromString(string str)
		{
			string[] times = str.Split('-');
			DateOnly dt = new DateOnly();
            dt = dt.AddYears(int.Parse(times[0]) - 1);
            dt = dt.AddMonths(int.Parse(times[1]) - 1);
            dt = dt.AddDays(int.Parse(times[2]) - 1);
			return dt;
        }
	}
}
