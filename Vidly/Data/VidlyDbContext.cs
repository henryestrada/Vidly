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
    public DbSet<MembershipType> MembershipTypes { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Customer>()
            .HasOne(c => c.MembershipType)
            .WithMany()
            .HasForeignKey(c => c.MembershipTypeId);

        base.OnModelCreating(builder);
    }
}