using Microsoft.EntityFrameworkCore;
using webistem.Models;

namespace webistem.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
		{
		}
		public DbSet<Abouts>? Abouts { get; set; }
		public DbSet<Awards>? Awards { get; set; }
		public DbSet<Education>? Educations { get; set; }
		public DbSet<Experience>? Experiences { get; set; }
		public DbSet<Interests>? Interests { get; set; }
		public DbSet<Skılls>? Skills { get; set; }

	}
}
