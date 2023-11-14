
using UretimTakipProgrami.DataAccess.Repositories.Abstractions;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.DataAccess.Repositories.Concretes
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductionDbContext context) : base(context)
        {
        }
    }
}
