using ChuyenDoiSoServer.Models;
using Microsoft.EntityFrameworkCore;
namespace ChuyenDoiSoServer.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions option) : base(option) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<UserLogin>()
                .HasKey(e => new { e.ProviderName, e.ProviderKey });
    }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserLogin> UserLogins { get; set; }
}