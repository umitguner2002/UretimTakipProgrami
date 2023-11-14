
using UretimTakipProgrami.DataAccess.Repositories.Abstractions;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.DataAccess.Repositories.Concretes
{
    public class MachineProgramRepository : Repository<MachineProgram>, IMachineProgramRepository
    {
        public MachineProgramRepository(ProductionDbContext context) : base(context)
        {
        }
    }
}
