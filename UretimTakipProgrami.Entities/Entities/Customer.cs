
using UretimTakipProgrami.Entities.Common;

namespace UretimTakipProgrami.Entities
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public string Name { get; set; }

        public string? Phone1 { get; set; }

        public string? Phone2 { get; set; }

        public string? Address { get; set; }

        public string? Mail { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
