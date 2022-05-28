namespace Shared.DataTransferObjects.Match;

//TODO Göra DateTime snyggare när objectet hämtas?
public record MatchDto(int Id, int WinnerId, int LoserId, DateTime TimeStamp);
