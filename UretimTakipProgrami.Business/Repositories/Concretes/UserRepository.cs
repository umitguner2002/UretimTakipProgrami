
using UretimTakipProgrami.Business.Repositories.Abstractions;
using UretimTakipProgrami.DataAccess;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Business.Repositories.Concretes
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ProductionDbContext context) : base(context)
        {

        }
    }
}
