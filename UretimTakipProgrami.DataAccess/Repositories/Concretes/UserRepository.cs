
using UretimTakipProgrami.DataAccess.Repositories.Abstractions;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.DataAccess.Repositories.Concretes
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ProductionDbContext context) : base(context)
        {

        }
    }
}
