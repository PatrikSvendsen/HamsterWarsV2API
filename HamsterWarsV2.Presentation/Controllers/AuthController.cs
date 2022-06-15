using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.DataTransferObjects.User;

namespace HamsterWarsV2.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IServiceManager _service;
    private readonly IConfiguration _configuration;
    public AuthController(IServiceManager service, IConfiguration configuration)
    {
        _service = service;
        _configuration = configuration;
    }

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

    [HttpPost]
    [Route("/login")]
    public async Task<IActionResult> Login([FromBody]UserLoginDto userLogin)
    {
        if (await _service.UserService.LoginAsync(userLogin, trackChanges: false) is false)
        {
            return BadRequest("Login failed");
        }

        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userLogin.Email),
            new Claim(ClaimTypes.Role, userLogin.Role)
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            _configuration.GetSection("Appsettings:Token").Value));

        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: cred
            );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(jwt);
    }
}
