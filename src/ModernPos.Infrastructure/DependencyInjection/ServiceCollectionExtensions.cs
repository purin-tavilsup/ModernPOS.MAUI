using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModernPos.Application.Abstractions;
using ModernPos.Infrastructure.Persistence;

namespace ModernPos.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string dbPath)
	{
		services.AddDbContext<AppDbContext>(options =>
		{
			options.UseSqlite($"Data Source={dbPath}");
		});

		services.AddScoped<ICustomerRepository, CustomerRepository>();
		
		return services;
	}
}