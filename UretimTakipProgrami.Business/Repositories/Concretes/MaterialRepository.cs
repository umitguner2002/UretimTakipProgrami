
using UretimTakipProgrami.Business.Repositories.Abstractions;
using UretimTakipProgrami.DataAccess;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Business.Repositories.Concretes
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        public MaterialRepository(ProductionDbContext context) : base(context)
        {

        }
    }
}
