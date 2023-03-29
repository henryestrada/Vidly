using Vidly.Models;

namespace Vidly.Repositories;

public interface IMembershipTypeRepository
{
    Task<IEnumerable<MembershipType>> GetAllAsync();
}
