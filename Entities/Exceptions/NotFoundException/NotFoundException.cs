namespace Entities.Exceptions.NotFoundException.NotFoundException;

public abstract class NotFoundException : Exception
{
    protected NotFoundException(string message)
        : base(message)
    {
    }
}
