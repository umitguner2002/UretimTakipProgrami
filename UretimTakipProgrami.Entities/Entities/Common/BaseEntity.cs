namespace UretimTakipProgrami.Entities.Common
{
    public class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
