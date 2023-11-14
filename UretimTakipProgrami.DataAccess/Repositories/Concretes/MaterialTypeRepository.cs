
using UretimTakipProgrami.DataAccess.Repositories.Abstractions;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.DataAccess.Repositories.Concretes
{
    public class MaterialTypeRepository : Repository<MaterialType>, IMaterialTypeRepository
    {
        public MaterialTypeRepository(ProductionDbContext context) : base(context)
        {

        }
    }
}
