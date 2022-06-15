namespace Entities.Exceptions.BadRequestException;

public class UserExistBadRequestException : BadRequestException
{
    public UserExistBadRequestException(string message) 
        : base(message)
    {
    }
}
