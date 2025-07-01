using ModernPos.Domain.Models;

namespace ModernPos.Application.Abstractions;

public interface ICustomerRepository
{
	Task<List<Customer>> GetAllCustomersAsync();

	Task AddCustomerAsync(Customer customer);

	Task DeleteCustomerAsync(Customer customer);

	Task DeleteCustomerByIdAsync(int id);

	Task<Customer?> GetCustomerByIdAsync(int id);
}