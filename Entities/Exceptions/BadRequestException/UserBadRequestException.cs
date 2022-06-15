namespace Entities.Exceptions.BadRequestException;

public class UserBadRequestException : BadRequestException
{
    public UserBadRequestException(string message)
        : base(message)
    {
    }
}
