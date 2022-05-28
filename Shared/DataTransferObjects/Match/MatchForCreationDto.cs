namespace Shared.DataTransferObjects.Match;

public record MatchForCreationDto
{
    public int WinnerId { get; set; }
    public int LoserId { get; set; }
    
    public DateTime TimeStamp { get { return DateTime.Now; } }
}
