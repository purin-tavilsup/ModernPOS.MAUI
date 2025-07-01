using Microsoft.EntityFrameworkCore;
using ModernPos.Application.Abstractions;
using ModernPos.Domain.Models;

namespace ModernPos.Infrastructure.Persistence;

public class CustomerRepository : ICustomerRepository
{
	private readonly AppDbContext _dbContext;
	
	public CustomerRepository(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<List<Customer>> GetAllCustomersAsync()
	{
		return await _dbContext.Customers.ToListAsync();
	}

	public async Task AddCustomerAsync(Customer customer)
	{
		_dbContext.Customers.Add(customer);
		await _dbContext.SaveChangesAsync();
	}
	
	public async Task DeleteCustomerAsync(Customer customer)
	{
		_dbContext.Customers.Remove(customer);
		await _dbContext.SaveChangesAsync();
	}

	public async Task DeleteCustomerByIdAsync(int id)
	{
		var customer = await GetCustomerByIdAsync(id);

		if (customer is null)
		{
			return;
		}
		
		await DeleteCustomerAsync(customer);
	}
	
	public async Task<Customer?> GetCustomerByIdAsync(int id)
	{
		return await _dbContext.Customers.FindAsync(id);
	}
}