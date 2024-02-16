using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AirlineAPI.Models;

namespace AirlineAPI.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Airline> Airlines { get; set; }
		public DbSet<AircraftType> AircraftTypes { get; set;}
	}
}