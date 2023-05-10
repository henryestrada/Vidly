using Vidly.Models;

namespace Vidly.Repositories;

public interface IRentalRepository
{
    Task<IEnumerable<Rental>> GetAllAsync();
    Task<Rental> GetAsync(int id);
    Task<Rental> AddAsync(Rental rental);
    Task<Rental> UpdateAsync(int id, Rental rental);
    Task<Rental> DeleteAsync(int id);
}
