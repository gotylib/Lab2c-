
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Manager> Managers { get; set; } = null!;

    public DbSet<Shop> Shops { get; set; } = null!;

    public DbSet<Сategory> Categories { get; set; } = null!;

    public DbSet<Book> Books { get; set; } = null!;

}

