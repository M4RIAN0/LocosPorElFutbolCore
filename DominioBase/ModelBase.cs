using System.ComponentModel.DataAnnotations;

namespace DominioBase
{
    public abstract class IEntity;

    public abstract class EntityModel : IEntity
    {
        [Key]
        public int ID { get; set; }
    }

    public abstract class MasterEntityModel : EntityModel
    {
        public bool IsEnabled { get; set; }
        public bool IsDeleted { get; set; }
    }

}
