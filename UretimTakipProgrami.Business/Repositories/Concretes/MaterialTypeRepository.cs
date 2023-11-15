
using UretimTakipProgrami.Business.Repositories.Abstractions;
using UretimTakipProgrami.DataAccess;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Business.Repositories.Concretes
{
    public class MaterialTypeRepository : Repository<MaterialType>, IMaterialTypeRepository
    {
        public MaterialTypeRepository(ProductionDbContext context) : base(context)
        {

        }
    }
}
