namespace Entities.Exceptions;

public class MatchesNotFoundException : NotFoundException
{
    public MatchesNotFoundException()
        : base($"No matches was found in the database")
    {
    }
}
