using Microsoft.EntityFrameworkCore;
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

    }


}
