using Vidly.Models;

namespace Vidly.Repositories;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAllAsync();
    Task<Movie> GetAsync(int id);
    Task<IEnumerable<Movie>> GetAsync(List<int> movieIdCollection);
    Task<IEnumerable<Movie>> GetAsync(string query);
    Task<Movie> AddAsync(Movie movie);
    Task<Movie> UpdateAsync(int id, Movie movie);
    Task<Movie> DeleteAsync(int id);
}
