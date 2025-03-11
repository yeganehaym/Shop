using Microsoft.EntityFrameworkCore;
using Shop2.Entities;
using Shop2.Entities.Configs;
using Shop2.Entities.Dto;

namespace Shop2.Database;

public class ApplicationContext:DbContext
{
    public ApplicationContext(DbContextOptions options):base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);
        modelBuilder.Entity<Product>().HasQueryFilter(x => x.RemoveTime.HasValue == false);

        modelBuilder.Entity<CategoryFamily>().HasNoKey().ToView("CategoryFamily");
        
        base.OnModelCreating(modelBuilder);
    }

    //====================== Entity ===================================
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceItem> InvoiceItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    //=============================================================== Dto =========================
    public DbSet<CategoryFamily> CategoryFamily { get; set; }
}