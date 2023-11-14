
using UretimTakipProgrami.Entities.Common;

namespace UretimTakipProgrami.Entities
{
    public class Machine : BaseEntity
    {
        public Machine()
        {
            Orders = new HashSet<Order>();
        }

        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
