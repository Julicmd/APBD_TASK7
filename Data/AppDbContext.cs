using APBDTask9.Models;
using Microsoft.EntityFrameworkCore;

namespace APBDTask9.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<PCs> PCs { get; set; }
    public DbSet<PcComponets> PcComponents { get; set; }
    public DbSet<Components> Components { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacture> ComponentManufactures { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //ids
        modelBuilder.Entity<PcComponets>().HasKey(pc => new {pc.PcId, pc.ComponentCode});
        modelBuilder.Entity<Components>().HasKey(c => new {c.Code});

        //connections
       modelBuilder.Entity<ComponentManufacture>().HasMany(cm => cm.Components)
           .WithOne().HasForeignKey(cm => cm.ComponentManufactorId);
       
       modelBuilder.Entity<ComponentType>().HasMany(ct => ct.Components)
           .WithOne().HasForeignKey(ct => ct.ComponentTypeId);
       
       //many to many 
       modelBuilder.Entity<PcComponets>()
           .HasOne(x => x.Pc)
           .WithMany(p => p.PcComponets)
           .HasForeignKey(x => x.PcId);
       
       modelBuilder.Entity<PcComponets>()
           .HasOne(x => x.Component)
           .WithMany(c => c.PcComponets)
           .HasForeignKey(x => x.ComponentCode);
       
       
       
       //Data
       modelBuilder.Entity<PCs>().HasData(
           new PCs
           {
               Id = 1, Name = "Gaming Beast X", Weight = 12.5f, Warranty = 36, CreatedAt = new DateTime(2026, 5, 8),
               Stock = 5
           },
           new PCs
           {
               Id = 2, Name = "Office Mini Pro", Weight = 4.2f, Warranty = 24, CreatedAt = new DateTime(2026, 4, 15),
               Stock = 12
           },
           new PCs
           {
               Id = 3, Name = "Workstation Pro", Weight = 8.0f, Warranty = 48, CreatedAt = new DateTime(2026, 3, 10),
               Stock = 3
           });
       
       modelBuilder.Entity<PcComponets>().HasData(
           new PcComponets { PcId = 1, ComponentCode = 'A', ComponetAmount = 1 },
           new PcComponets { PcId = 1, ComponentCode = 'B', ComponetAmount = 2 },
           new PcComponets { PcId = 2, ComponentCode = 'C', ComponetAmount = 1 }
       );
       
       modelBuilder.Entity<Components>().HasData(
           new Components { Code = 'A', Name = "Intel Core i9", Description = "High end CPU", ComponentManufactorId = 1, ComponentTypeId = 1 },
           new Components { Code = 'B', Name = "AMD Radeon RX", Description = "High end GPU", ComponentManufactorId = 2, ComponentTypeId = 2 },
           new Components { Code = 'C', Name = "Nvidia RTX 4090", Description = "Top tier GPU", ComponentManufactorId = 3, ComponentTypeId = 2 }
       );
       
       modelBuilder.Entity<ComponentManufacture>().HasData(
           new ComponentManufacture { Id = 1, Abbreviation = "INTL", FullName = "Intel Corporation", FoundationDate = new DateTime(1968, 7, 18) },
           new ComponentManufacture { Id = 2, Abbreviation = "AMD", FullName = "Advanced Micro Devices", FoundationDate = new DateTime(1969, 5, 1) },
           new ComponentManufacture { Id = 3, Abbreviation = "NVDIA", FullName = "Nvidia Corporation", FoundationDate = new DateTime(1993, 4, 5) }
       );
       
       modelBuilder.Entity<ComponentType>().HasData(
           new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Central Processing Unit" },
           new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics Processing Unit" },
           new ComponentType { Id = 3, Abbreviation = "RAM", Name = "Random Access Memory" }
       );





    }
    
}