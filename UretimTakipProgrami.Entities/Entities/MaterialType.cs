
using UretimTakipProgrami.Entities.Common;

namespace UretimTakipProgrami.Entities
{
    public class MaterialType : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Material> Materials { get; set;}
    }
}
