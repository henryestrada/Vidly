using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;

namespace Vidly.Data;

public class VidlyDbContext : IdentityDbContext
{
    public VidlyDbContext(DbContextOptions<VidlyDbContext> options)
        : base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; }
}