
using UretimTakipProgrami.DataAccess.Repositories.Abstractions;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.DataAccess.Repositories.Concretes
{
    public class MachineRepository : Repository<Machine>, IMachineRepository
    {
        public MachineRepository(ProductionDbContext context) : base(context)
        {

        }
    }
}
