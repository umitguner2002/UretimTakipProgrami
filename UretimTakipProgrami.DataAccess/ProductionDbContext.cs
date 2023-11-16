using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using UretimTakipProgrami.Entities;
using UretimTakipProgrami.Entities.Common;

namespace UretimTakipProgrami.DataAccess
{
    public class ProductionDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("User ID=postgres;Password=admin;Host=192.168.0.23;Port=5432;Database=DbUretim;"); 
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=DbUretim;User Id=postgres;Password=admin;");
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Machine> Machines { get; set; }

        public DbSet<MachineProgram> MachinePrograms { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Production> Productions { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<MaterialType> MaterialTypes { get; set; }

        public DbSet<MaterialShape> MaterialShapes { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedFirstUser(modelBuilder);
            SeedMaterialShapes(modelBuilder);
            SeedMaterialTypes(modelBuilder);
        }

        private void SeedFirstUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.UtcNow,
                    Name = "ÜMİT",
                    Username = "umt",
                    Password = SHA256Hash("dev"),
                    Phone = "",
                    Email = "",
                    IsAdmin = true,
                    IsManager = false,
                    IsOperator = false,
                    IsActive = true,
                    IsDeleted = false
                }
            );
        }

        private void SeedMaterialShapes(ModelBuilder modelBuilder)
        {
            var materialShapeNames = new List<string> { "DOLU", "DELİKLİ", "BOYDAN", "BORU", "MİL" };

            foreach (var name in materialShapeNames)
            {
                var materialShape = new MaterialShape
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.UtcNow,
                    Name = name
                };

                modelBuilder.Entity<MaterialShape>().HasData(materialShape);
            }
        }

        private void SeedMaterialTypes(ModelBuilder modelBuilder)
        {
            var materialTypeNames = new List<string> { "DEMİR", "ÇELİK", "BAKIR", "PİRİNÇ", "ALÜMİNYUM", "DERLİN" };

            foreach (var name in materialTypeNames)
            {
                var materialType = new MaterialType
                {
                    Id= Guid.NewGuid(),
                    CreatedDate = DateTime.UtcNow,
                    Name = name
                };

                modelBuilder.Entity<MaterialType>().HasData(materialType);
            }            
        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker : Entityler üzerinden yapılan değişiklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.

            var datas = ChangeTracker
                 .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        private string SHA256Hash(string text)
        {
            string source = text;
            using (SHA256 sha1Hash = SHA256.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                return hash;
            }
        }

    }


}
