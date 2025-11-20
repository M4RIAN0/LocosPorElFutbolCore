namespace Lxf.Support.BuildingBlocks;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(Type entityType, object entityKey)
        : base($"La entidad '{entityType}' con clave '{entityKey}' no se econtro.")
    {
        EntityType = entityType;
        EntityKey = entityKey;
    }

    public Type EntityType { get; }

    public object EntityKey { get; }
}
