
using UretimTakipProgrami.Business.Repositories.Abstractions;
using UretimTakipProgrami.DataAccess;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.Business.Repositories.Concretes
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ProductionDbContext context) : base(context)
        {
            
        }
    }
}
