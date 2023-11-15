
using UretimTakipProgrami.Business.Repositories.Abstractions;
using UretimTakipProgrami.DataAccess;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Business.Repositories.Concretes
{
    public class MachineProgramRepository : Repository<MachineProgram>, IMachineProgramRepository
    {
        public MachineProgramRepository(ProductionDbContext context) : base(context)
        {
        }
    }
}
