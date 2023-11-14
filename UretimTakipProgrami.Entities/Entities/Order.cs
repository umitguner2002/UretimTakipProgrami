﻿
using UretimTakipProgrami.Entities.Common;

namespace UretimTakipProgrami.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            Productions = new HashSet<Production>();
        }

        public int Quantity { get; set; }

        public string? Description { get; set; }

        public DateTime DeliveryDate { get; set; }

        public bool IsUrgent { get; set; } = false;

        public bool IsWaiting { get; set; } = true;

        public bool IsProduction { get; set; } = false;

        public bool IsReady { get; set; } = false;

        public DateTime? FinishDate { get; set; }

        public Guid ProductId { get; set; }

        public Guid CustomerId { get; set; }

        public Guid? UserId { get; set; }

        public Guid? MachineId { get; set; }        

        public Product Product { get; set; }

        public Customer Customer { get; set; }

        public User? User { get; set; }

        public Machine? Machine { get; set; }

        public ICollection<Production>? Productions { get; set; }
    }
}
