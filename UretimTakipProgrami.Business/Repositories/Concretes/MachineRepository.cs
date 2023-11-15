
using UretimTakipProgrami.Business.Repositories.Abstractions;
using UretimTakipProgrami.DataAccess;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Business.Repositories.Concretes
{
    public class MachineRepository : Repository<Machine>, IMachineRepository
    {
        public MachineRepository(ProductionDbContext context) : base(context)
        {

        }
    }
}
