using AB.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AB.Persistence;

public sealed class RepoDbContext : DbContext
{

    public RepoDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Supplier> Suppliers { get; set; }

    public DbSet<Product> Products { get; set; }

}
