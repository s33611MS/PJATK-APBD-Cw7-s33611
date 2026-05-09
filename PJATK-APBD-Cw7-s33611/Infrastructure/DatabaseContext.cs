using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s33611.Models;


namespace PJATK_APBD_Cw7_s33611.Infrastructure;

public class DatabaseContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<PC> PCs { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<PC>().HasData([
            new PC
            {
                Id = 1,
                Name = "SomePC1",
                Weight = 15.5f,
                Warranty = 3,
                CreatedAt = new DateTime(2026, 5, 9),
                Stock = 10
            },
            new PC
            {
                Id = 2,
                Name = "SomeOtherPC2",
                Weight = 20,
                Warranty = 1,
                CreatedAt = new DateTime(2024, 10, 16),
                Stock = 3
            }
        ]);

        modelBuilder.Entity<Component>().HasData([
            new Component
            {
                Code = "MOBO123456",
                Name = "MOBO",
                Description =  "Description of this mobo",
                ComponentsManufacturersId = 1,
                ComponentsTypesId = 1
            },
            new Component
            {
                Code = "MOBO098765",
                Name = "MOBOX1",
                Description =  "Description of other mobo",
                ComponentsManufacturersId = 2,
                ComponentsTypesId = 1
            },
            new Component
            {
            Code = "RAM1234567",
            Name = "RAMX1",
            Description =  "Description of some RAM",
            ComponentsManufacturersId = 2,
            ComponentsTypesId = 2
            }
        ]);

        modelBuilder.Entity<ComponentManufacturer>().HasData([
            new ComponentManufacturer
            {
                Id = 1,
                Abbreviation = "ABR",
                FullName = "AbbreviationManufacturer",
                FoundationDate = new DateTime(2015, 1, 5),
            },
            new ComponentManufacturer
            {
                Id = 2,
                Abbreviation = "X1",
                FullName = "X1Industries",
                FoundationDate = new DateTime(2001, 11, 9),
            }
        ]);

        modelBuilder.Entity<ComponentType>().HasData([
            new ComponentType
            {
                Id = 1,
                Abbreviation = "MOBO",
                Name = "Motherboard",
            },
            new ComponentType
            {
                Id = 2,
                Abbreviation = "RAM",
                Name = "Random Access Memory",
            }
        ]);

        modelBuilder.Entity<PCComponent>().HasData([
            new PCComponent
            {
                PCId = 1,
                ComponentCode =  "MOBO123456",
                Amount = 1
            },
            new PCComponent
            {
                PCId = 1,
                ComponentCode =  "RAM1234567",
                Amount = 2
            },
            new PCComponent
            {
                PCId = 2,
                ComponentCode =  "MOBO098765",
                Amount = 1
            }
        ]);
    }
}