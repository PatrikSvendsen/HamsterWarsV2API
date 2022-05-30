using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.Match;

public record MatchForCreationDto
{
    [Required(ErrorMessage = "WinnerId field is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "WinnerId field is required.")]
    public int WinnerId { get; set; }

    [Required(ErrorMessage = "LoserId field is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "LoserId field is required.")]
    public int LoserId { get; set; }
    
    public DateTime TimeStamp { get { return DateTime.Now; } }
}
