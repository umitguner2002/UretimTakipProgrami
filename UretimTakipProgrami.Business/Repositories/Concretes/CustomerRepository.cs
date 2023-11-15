
using UretimTakipProgrami.Business.Repositories.Abstractions;
using UretimTakipProgrami.DataAccess;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Business.Repositories.Concretes
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ProductionDbContext context) : base(context)
        {
            
        }
    }
}
