using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.User;

namespace HamsterWarsV2.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IServiceManager _service;
    public AuthController(IServiceManager service) => _service = service;

    [HttpPost]
    [Route("/register")]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDto userRegisterDto)
    {
        if (userRegisterDto is null)
        {
            return BadRequest("UserRegisterDto object is null");
        }
        if (ModelState.IsValid is false)
        {
            return UnprocessableEntity(ModelState);
        }

        var userToRegister = await _service.UserService.RegisterAsync(userRegisterDto, userRegisterDto.Password);

        //TODO Här måste en "GetUserById ligga för att kunna returnera id
        return CreatedAtRoute(new { id = userToRegister.Id }, userToRegister);
    }
}
