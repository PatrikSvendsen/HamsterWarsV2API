namespace Shared.DataTransferObjects.Hamster;

public record MatchDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? FavFood { get; set; }
    public string? Loves { get; set; }
    public int Wins { get; set; }
    public int Defeats { get; set; }
    public int Games { get; set; }
}
