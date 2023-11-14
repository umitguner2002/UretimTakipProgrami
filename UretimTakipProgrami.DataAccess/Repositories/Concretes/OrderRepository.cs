
using UretimTakipProgrami.DataAccess.Repositories.Abstractions;
using UretimTakipProgrami.Entities;

namespace UretimTakipProgrami.DataAccess.Repositories.Concretes
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ProductionDbContext context) : base(context)
        {
            
        }
    }
}
