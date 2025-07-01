using Microsoft.EntityFrameworkCore;
using ModernPos.Domain.Models;

namespace ModernPos.Infrastructure.Persistence;

public class AppDbContext: DbContext
{
	public DbSet<Customer> Customers => Set<Customer>();

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
		
		base.OnModelCreating(modelBuilder);
	}
}