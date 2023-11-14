
using UretimTakipProgrami.DataAccess.Repositories.Abstractions;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.DataAccess.Repositories.Concretes
{
    public class ProductionRepository : Repository<Production>, IProductionRepository
    {
        public ProductionRepository(ProductionDbContext context) : base(context)
        {
        }
    }
}
