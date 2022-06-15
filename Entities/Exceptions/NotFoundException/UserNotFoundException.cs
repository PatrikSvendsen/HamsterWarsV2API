namespace Entities.Exceptions.NotFoundException.NotFoundException;

public sealed class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(string email) 
        : base($"User with this email: {email} cannot be found.")
    {
    }
}
