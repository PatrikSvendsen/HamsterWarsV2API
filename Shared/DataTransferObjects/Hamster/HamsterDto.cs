using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.DataTransferObjects.Hamster;

public record HamsterDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? ImgName { get; set; }
    public string? FavFood { get; set; }
    public string? Loves { get; set; }
    public int Wins { get; set; }
    public int Defeats { get; set; }
    public int Games { get; set; }
}
