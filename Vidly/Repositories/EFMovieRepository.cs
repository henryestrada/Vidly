using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;

namespace Vidly.Repositories;

public class EFMovieRepository : IMovieRepository
{
    private readonly VidlyDbContext _vidlyDbContext;

    public EFMovieRepository(VidlyDbContext vidlyDbContext)
    {
        _vidlyDbContext = vidlyDbContext;
    }
    public Task<Movie> AddAsync(Movie Movie)
    {
        throw new NotImplementedException();
    }

    public Task<Movie> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        return await _vidlyDbContext.Movies.Include(x => x.Genre).ToListAsync();
    }

    public async Task<Movie> GetAsync(int id)
    {
        return await _vidlyDbContext.Movies.Include(x => x.Genre).FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<Movie> UpdateAsync(Movie Movie)
    {
        throw new NotImplementedException();
    }
}