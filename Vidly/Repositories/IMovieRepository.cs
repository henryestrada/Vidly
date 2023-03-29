using Vidly.Models;

namespace Vidly.Repositories;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllAsync();
    Task<Movie> GetAsync(int id);
    Task<Movie> AddAsync(Movie Movie);
    Task<Movie> UpdateAsync(Movie Movie);
    Task<Movie> DeleteAsync(int id);
}
