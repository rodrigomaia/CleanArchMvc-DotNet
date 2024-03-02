using Microsoft.EntityFrameworkCore;
using CleanArchMvc.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CleanArchMvc.Infra.Data.Identity;

namespace CleanArchMvc.Infra.Data.Context;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext() : base()
    {}
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql("Host=localhost;Port=5432;Database=CleanArchDB1;Username=postgres;Password=postgres;",
                                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
    }
}