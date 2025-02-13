using Microsoft.EntityFrameworkCore;
using Shop2.Entities;

namespace Shop2.Database;

public class ApplicationContext:DbContext
{
    public ApplicationContext(DbContextOptions options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasIndex(x => x.NationalCode).IsUnique();
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; }
}