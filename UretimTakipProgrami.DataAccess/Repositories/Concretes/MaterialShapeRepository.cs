
using UretimTakipProgrami.DataAccess.Repositories.Abstractions;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.DataAccess.Repositories.Concretes
{
    public class MaterialShapeRepository : Repository<MaterialShape>, IMaterialShapeRepository
    {
        public MaterialShapeRepository(ProductionDbContext context) : base(context)
        {

        }
    }
}
