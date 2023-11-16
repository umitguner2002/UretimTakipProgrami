
using System.ComponentModel.DataAnnotations.Schema;
using UretimTakipProgrami.Entities.Common;

namespace UretimTakipProgrami.Entities
{
    public class MachineProgram : BaseEntity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public virtual Product Product { get; set; }
    }
}
