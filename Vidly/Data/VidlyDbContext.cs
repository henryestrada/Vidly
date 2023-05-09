using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;

namespace Vidly.Data;

public class VidlyDbContext : IdentityDbContext<User>
{
    public VidlyDbContext(DbContextOptions<VidlyDbContext> options)
        : base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<MembershipType> MembershipTypes { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Customer>()
            .HasOne(c => c.MembershipType)
            .WithMany()
            .HasForeignKey(c => c.MembershipTypeId);

        builder.Entity<Movie>()
            .HasOne(c => c.Genre)
            .WithMany()
            .HasForeignKey(c => c.GenreId);

        base.OnModelCreating(builder);
    }
}