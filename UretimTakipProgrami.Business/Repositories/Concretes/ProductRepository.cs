
using UretimTakipProgrami.Business.Repositories.Abstractions;
using UretimTakipProgrami.DataAccess;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Business.Repositories.Concretes
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ProductionDbContext context) : base(context)
        {
        }
    }
}
