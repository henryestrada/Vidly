using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;

namespace Vidly.Repositories;

public class EFMembershipTypeRepository : IMembershipTypeRepository
{
    private readonly VidlyDbContext _vidlyDbContext;

    public EFMembershipTypeRepository(VidlyDbContext vidlyDbContext)
    {
        _vidlyDbContext = vidlyDbContext;
    }
    public async Task<IEnumerable<MembershipType>> GetAllAsync()
    {
        return await _vidlyDbContext.MembershipTypes.ToListAsync();
    }
}