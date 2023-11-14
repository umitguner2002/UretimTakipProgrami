
using UretimTakipProgrami.Entities.Common;

namespace UretimTakipProgrami.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string? ImageName { get; set; }

        public string? ImagePath { get; set; }      

        public ICollection<Order> Orders { get; set; }

        public MachineProgram MachineProgram { get; set; }

        public Material Material { get; set; }
    }
}
