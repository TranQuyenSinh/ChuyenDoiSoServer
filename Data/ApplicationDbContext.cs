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
    }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }

}