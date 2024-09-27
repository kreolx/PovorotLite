using Microsoft.EntityFrameworkCore;
using PL.Engine.Storage.Models;
using PL.Engine.Storage.Models.Configurations;

namespace PL.Engine.Storage.DbContexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Request> Requests { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RequestCfg());
        base.OnModelCreating(modelBuilder);
    }
}