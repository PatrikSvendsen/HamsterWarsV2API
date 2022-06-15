using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects.User;

public class UserLoginDto
{
    [Required]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    public string Password { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;

}
