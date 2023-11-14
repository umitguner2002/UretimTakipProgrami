
using UretimTakipProgrami.Entities.Common;

namespace UretimTakipProgrami.Entities
{
    public class MachineProgram : BaseEntity
    {
        public MachineProgram()
        {
            Products = new HashSet<Product>();
        }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
