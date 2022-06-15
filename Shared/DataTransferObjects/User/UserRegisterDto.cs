using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.User;

public record UserRegisterDto
{
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required, StringLength(50, MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;

    [Compare("Password", ErrorMessage = "The passwords do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "This is required for creating a new user")]
    public string Role { get; set; } = string.Empty;
}
