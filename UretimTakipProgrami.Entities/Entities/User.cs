using UretimTakipProgrami.Entities.Common;

namespace UretimTakipProgrami.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsManager { get; set; }

        public bool IsOperator { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Production> Productions { get; set; }
    }
}
