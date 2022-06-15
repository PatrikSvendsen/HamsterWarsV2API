using AutoMapper;
using Contracts;
using Entities.Exceptions.BadRequestException;
using Entities.Exceptions.NotFoundException.NotFoundException;
using Entities.Models;
using Service.Contracts.ModelServiceContracts;
using Shared.DataTransferObjects.User;
using System.Security.Cryptography;

namespace Service.ModelService;

internal sealed class UserService : IUserService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public UserService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task DeleteUserAsync(string email, bool trackChanges)
    {
        var userToDelete = await _repository.User.GetUserByEmail(email, trackChanges);
        if (userToDelete is null)
        {
            throw new UserNotFoundException(email);
        }

        _repository.User.DeleteUser(userToDelete);
        await _repository.SaveAsync();
    }

    public async Task<bool> LoginAsync(UserLoginDto userLogin, bool trackChanges)
    {
        var userDb = await _repository.User.GetUserByEmail(userLogin.Email, trackChanges: false);
         
        if (userDb is null)
        {
            throw new UserNotFoundException(userLogin.Email);
        }
        else if (userDb.Role != "Admin")
        {
            throw new UserBadRequestException("User is not an Admin");
        }
        else if (!VerifyPasswordHash(userLogin.Password, userDb.PasswordHash, userDb.PasswordSalt))
        {
            throw new UserBadRequestException("Password is wrong, please try again");
        }
        return true;
    }

    public async Task<UserDto> RegisterAsync(UserRegisterDto userRegisterDto, string password)
    {
        var userExist = await _repository.User.GetUserByEmail(userRegisterDto.Email, trackChanges: false);
        if (userExist is not null)
        {
            throw new UserExistBadRequestException($"This email already exist: {userRegisterDto.Email}");
        }
        var userRegisterEntity = _mapper.Map<UserRegister>(userRegisterDto);

        var newUser = new UserDto();

        _mapper.Map(userRegisterEntity, newUser);

        CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
        newUser.PasswordHash = passwordHash;
        newUser.PasswordSalt = passwordSalt;

        var userToRegister = _mapper.Map<User>(newUser);

        _repository.User.RegisterUser(userToRegister);

        await _repository.SaveAsync();

        var userToReturn = _mapper.Map<UserDto>(newUser);

        return userToReturn;
    }

    public async Task<UserDto> GetUserByEmailAsync(string email, bool trackChanges)
    {
        var user = await _repository.User.GetUserByEmail(email, trackChanges);

        if (user is null)
        {
            throw new UserNotFoundException(email);
        }

        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        // Denna hmac genererar en "nyckel" för salt som används för att kryptera lösenord
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac
                .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computeHash.SequenceEqual(passwordHash);
        }
    }
}
