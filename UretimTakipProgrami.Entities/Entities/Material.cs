
using UretimTakipProgrami.Entities.Common;

namespace UretimTakipProgrami.Entities
{
    public class Material : BaseEntity
    {
        public Material()
        {
            Products = new HashSet<Product>();
        }

        public string Name { get; set; }

        public int Length { get; set; }

        public int OuterDiameter { get; set; }

        public int HoleDiameter { get; set; }

        public Guid MaterialTypeId { get; set; }

        public Guid MaterialShapeId { get; set; }

        public MaterialType MaterialType { get; set; }

        public MaterialShape MaterialShape { get; set; }

        public ICollection<Product> Products { get; set;}
    }
}
