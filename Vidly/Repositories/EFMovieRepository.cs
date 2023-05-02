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

    public async Task<Movie> AddAsync(Movie movie)
    {
        movie.Id = 0;
        await _vidlyDbContext.AddAsync(movie);
        await _vidlyDbContext.SaveChangesAsync();

        return movie;
    }

    public async Task<Movie> DeleteAsync(int id)
    {
        var movie = await _vidlyDbContext.Movies.SingleAsync(x => x.Id == id);

        if (movie == null) return null;

        _vidlyDbContext.Movies.Remove(movie);

        await _vidlyDbContext.SaveChangesAsync();

        return movie;
    }

    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        return await _vidlyDbContext.Movies.Include(x => x.Genre).ToListAsync();
    }

    public async Task<Movie> GetAsync(int id)
    {
        return await _vidlyDbContext.Movies.Include(x => x.Genre).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Movie> UpdateAsync(Movie movie)
    {

        var existingMovie = await _vidlyDbContext.Movies.SingleAsync(x => x.Id == movie.Id);

        existingMovie.Name = movie.Name;
        existingMovie.ReleaseDate = movie.ReleaseDate;
        existingMovie.DateAdded = movie.DateAdded;
        existingMovie.GenreId = movie.GenreId;
        existingMovie.NumberInStock = movie.NumberInStock;

        await _vidlyDbContext.SaveChangesAsync();

        return existingMovie;
    }
}