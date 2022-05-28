namespace Entities.Exceptions.NotFoundException.NotFoundException;

public sealed class MatchesNotFoundException : NotFoundException
{
    public MatchesNotFoundException()
        : base($"No matches was found in the database")
    {
    }
}
