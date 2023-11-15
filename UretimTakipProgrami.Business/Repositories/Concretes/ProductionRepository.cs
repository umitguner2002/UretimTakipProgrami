
using UretimTakipProgrami.Business.Repositories.Abstractions;
using UretimTakipProgrami.DataAccess;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Business.Repositories.Concretes
{
    public class ProductionRepository : Repository<Production>, IProductionRepository
    {
        public ProductionRepository(ProductionDbContext context) : base(context)
        {
        }
    }
}
