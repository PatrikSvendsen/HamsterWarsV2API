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

        var userToReturn = await _service.UserService.GetUserByEmailAsync(userToRegister.Email, trackChanges: false);

        return CreatedAtRoute("GetUser", new { id = userToReturn.Id}, userToReturn);
    }

    [HttpPost]
    [Route("/login")]
    // Metod som skall ta hand om inloggningen
    public async Task<IActionResult> Login([FromBody]UserLoginDto userLogin)
    {
        // Kontroll görs om användaren får logga in
        if (await _service.UserService.LoginAsync(userLogin, trackChanges: false) is false)
        {
            return BadRequest("Login failed");
        }

        // Rollen hämtas för användaren
        var userFromDb = await _service.UserService.GetUserByEmailAsync(userLogin.Email, trackChanges: false);

        // Claims läggs till for token
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userLogin.Email),
            new Claim(ClaimTypes.Role, userFromDb.Role)
        };

        // Man hämtar "saltet" från AppSettings.filen
        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            _configuration.GetSection("Appsettings:Token").Value));

        //Man "skapar/gör om" nyckeln så att nyckeln blir hel
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        // Token skapas med de olika claims samt en komplett nyckel och hur länge nyckeln skall gälla
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: cred
            );
        // Man skriver om nyckeln till jwt.format 
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(jwt);
    }

    [HttpGet]
    [Route("/users", Name = "GetUser")]
    public async Task<IActionResult> GetUser(string email)
    {
        var user =
            await _service.UserService.GetUserByEmailAsync(email, trackChanges: false);
        return Ok(user);
    }
}
