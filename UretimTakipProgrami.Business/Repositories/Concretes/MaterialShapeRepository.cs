
using UretimTakipProgrami.Business.Repositories.Abstractions;
using UretimTakipProgrami.DataAccess;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Business.Repositories.Concretes
{
    public class MaterialShapeRepository : Repository<MaterialShape>, IMaterialShapeRepository
    {
        public MaterialShapeRepository(ProductionDbContext context) : base(context)
        {

        }
    }
}
