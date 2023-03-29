using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Vidly.Data;

public class VidlyDbContext : IdentityDbContext
{
    public VidlyDbContext(DbContextOptions<VidlyDbContext> options)
        : base(options)
    {

    }
}