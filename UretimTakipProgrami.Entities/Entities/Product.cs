
using System.ComponentModel.DataAnnotations.Schema;
using UretimTakipProgrami.Entities.Common;

namespace UretimTakipProgrami.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string? ImageName { get; set; }

        public string? ImagePath { get; set; }

        [ForeignKey(nameof(MachineProgram))]
        public Guid MachineProgramId { get; set; }

        public Guid MaterialId { get; set; }

        public virtual MachineProgram MachineProgram { get; set; }

        public virtual Material Material { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
