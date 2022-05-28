namespace Entities.Exceptions.NotFoundException.NotFoundException;

public sealed class MatchNotFoundException : NotFoundException
{
    public MatchNotFoundException(int matchId)
        : base($"Match with id: {matchId} does not exist in the database.")
    {
    }
}
