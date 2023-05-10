using Vidly.Models;

namespace Vidly.Repositories;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<IEnumerable<Customer>> GetAsync(string query);
    Task<Customer> GetAsync(int id);
    Task<Customer> AddAsync(Customer customer);
    Task<Customer> UpdateAsync(int id, Customer customer);
    Task<Customer> DeleteAsync(int id);
}
