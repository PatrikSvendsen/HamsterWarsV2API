namespace Entities.Exceptions.NotFoundException.NotFoundException;

public sealed class HamstersNotFoundException : NotFoundException
{
    public HamstersNotFoundException()
        : base("No hamsters was found.")
    {
    }
}
