using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PROG7311_POE_Part2_ST10257863.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Farmer> Farmers
		{
			get; set;
		}
		public DbSet<Employee> Employees
		{
			get; set;
		}
		public DbSet<Products> Products
		{
			get; set;
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<ApplicationUser>()
				.HasOne(u => u.FarmerProfile)
				.WithOne(f => f.User)
				.HasForeignKey<Farmer>(f => f.UserId);

			builder.Entity<ApplicationUser>()
				.HasOne(u => u.EmployeeProfile)
				.WithOne(e => e.User)
				.HasForeignKey<Employee>(e => e.UserId);

			builder.Entity<Farmer>()
				.HasMany(f => f.Products)
				.WithOne(p => p.Farmer)
				.HasForeignKey(p => p.FarmerId)
				.IsRequired();
		}
	}
}