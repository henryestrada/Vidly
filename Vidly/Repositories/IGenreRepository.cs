using Vidly.Models;

namespace Vidly.Repositories;

public interface IGenreRepository
{
    Task<IEnumerable<Genre>> GetAllAsync();
}
