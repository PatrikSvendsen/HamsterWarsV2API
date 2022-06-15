namespace Entities.Exceptions.BadRequestException;

public class UserBadRequestException : BadRequestException
{
    public UserBadRequestException()
        : base($"Password is wrong, please try again")
    {
    }
}
