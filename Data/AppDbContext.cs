using APBDTask9.Models;
using Microsoft.EntityFrameworkCore;

namespace APBDTask9.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<PCs> PCs { get; set; }
    public DbSet<PCComponets> PCComponets { get; set; }
    public DbSet<Componets> Componets { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacture> ComponentManufactures { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //ids
        modelBuilder.Entity<PCComponets>().HasKey(pc => new { pc.PCId , pc.ComponetCode });
        modelBuilder.Entity<Componets>().HasKey(c => new {c.Code});

        //connections
       modelBuilder.Entity<PCs>().HasMany(pc => pc.PcComponets)
           .WithOne().HasForeignKey(pc => pc.PCId);

       modelBuilder.Entity<Componets>().HasMany(c => c.PcComponets)
           .WithOne().HasForeignKey(c => c.ComponetCode);

       modelBuilder.Entity<ComponentManufacture>().HasMany(cm => cm.Components)
           .WithOne().HasForeignKey(cm => cm.ComponentManufactorId);
       
       modelBuilder.Entity<ComponentType>().HasMany(ct => ct.Components)
           .WithOne().HasForeignKey(ct => ct.ComponentTypeId);
    }
    
}