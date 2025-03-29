namespace Lxf.Support.BuildingBlocks;

public class ElementNotFoundException : Exception
{
    public ElementNotFoundException(string message, params object?[] args)
        : base(string.Format(message, args))
    {
        Message = string.Format(message, args);
        Args = args;
    }

    public string Message { get; }

    public object?[] Args { get; }
}
