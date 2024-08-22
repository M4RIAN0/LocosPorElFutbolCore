namespace Lxf.Support.BuildingBlocks;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(Type entityType, object entityKey)
        : base($"Entity '{entityType}' with key '{entityKey}' not found.")
    {
        EntityType = entityType;
        EntityKey = entityKey;
    }

    public Type EntityType { get; }

    public object EntityKey { get; }
}
