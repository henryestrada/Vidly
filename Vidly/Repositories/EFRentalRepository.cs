using Vidly.Data;
using Vidly.Models;

namespace Vidly.Repositories;

public class EFRentalRepository : IRentalRepository
{
    private readonly VidlyDbContext _vidlyDbContext;

    public EFRentalRepository(VidlyDbContext vidlyDbContext)
    {
        _vidlyDbContext = vidlyDbContext;
    }
    public Task<IEnumerable<Rental>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Rental> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Rental> AddAsync(Rental rental)
    {
        rental.Id = 0;
        await _vidlyDbContext.AddAsync(rental);
        rental.Movie.NumberAvailable--;

        await _vidlyDbContext.SaveChangesAsync();

        return rental;
    }

    public Task<Rental> UpdateAsync(int id, Rental rental)
    {
        throw new NotImplementedException();
    }

    public Task<Rental> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
