using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.Hamster;

public record HamsterForCreationDto
{
    [Required(ErrorMessage = "Name field is required")]
    [MaxLength(20, ErrorMessage = "Maximum length for the Name is 30 characters.")]
    public string? Name { get; init; }

    [Range(1, 5, ErrorMessage = "Age is required and it can't be higher than 5")]
    public int Age { get; init; }

    [Required(ErrorMessage = "Loves field is required")]
    [MaxLength(20, ErrorMessage = "Maximum length for the Name is 20 characters.")]
    public string? Loves{ get; init; }

    [Required(ErrorMessage = "Food field is required")]
    [MaxLength(20, ErrorMessage = "Maximum length for the Name is 20 characters.")]
    public string? FavFood { get; init; }

    public string? ImgName { get; init; }
}
