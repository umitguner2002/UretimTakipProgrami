
using UretimTakipProgrami.Entities.Common;

namespace UretimTakipProgrami.Entities
{
    public class Production : BaseEntity
    {
        public int Quantity { get; set; } = 0;

        public int Wastage { get; set; } = 0;

        public DateTime? FinishDate { get; set; }

        public bool IsStarted { get; set; } = false;

        public Guid OrderId { get; set; }

        public Order Order { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
