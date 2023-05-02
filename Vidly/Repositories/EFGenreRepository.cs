using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;

namespace Vidly.Repositories;

public class EFGenreRepository : IGenreRepository
{
    private readonly VidlyDbContext _vidlyDbContext;

    public EFGenreRepository(VidlyDbContext vidlyDbContext)
    {
        _vidlyDbContext = vidlyDbContext;
    }
    public async Task<IEnumerable<Genre>> GetAllAsync()
    {
        return await _vidlyDbContext.Genres.ToListAsync();
    }
}
