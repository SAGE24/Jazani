using AutoMapper;
using Jazani.Application.Admins.Dtos.Users;
using Jazani.Application.Cores.Exceptions;
using Jazani.Core.Securities.Services;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Microsoft.Extensions.Configuration;

namespace Jazani.Application.Admins.Services.Implementations;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ISecurityService _securityService;
    private readonly IConfiguration _configuration;

    public UserService(IUserRepository userRepository, IMapper mapper, ISecurityService securityService,
        IConfiguration configuration) { 
        _userRepository = userRepository;
        _mapper = mapper;
        _securityService = securityService;
        _configuration = configuration;
    }

    public async Task<UserDto> CreateAsync(UserSaveDto saveDto)
    {
        User user = _mapper.Map<User>(saveDto);
        user.RegistrationDate = DateTime.Now;
        user.State = true;
        user.Password = _securityService.HashPassword(saveDto.Email, saveDto.Password);

        await _userRepository.SaveAsync(user);

        return _mapper.Map<UserDto>(user);
    }

    public Task<UserDto> EditAsync(int id, UserSaveDto saveDto)
    {
        throw new NotImplementedException();
    }

    public async Task<UserSecurityDto> LoginAsync(UserAuthDto userAuthDto)
    {
        User? user = await _userRepository.FindByEmailAsync(userAuthDto.Email) ?? throw new NotFoundCoreException("Usuario no esta registrado en nuestro sistema");
        if(!user.State) throw new NotFoundCoreException("El usuario no esta activo. Comuniquese con el administrador");

        bool isCorrect = _securityService.VerifyHashedPassword(user.Email, user.Password, userAuthDto.Password);

        if (!isCorrect) throw new NotFoundCoreException("La contraseña que ingreso no es correcta");

        UserSecurityDto userSecurityDto = _mapper.Map<UserSecurityDto>(user);

        string jwtSecurityKey = _configuration.GetSection("Security:JwtSecrectKey").Get<string>();

        userSecurityDto.Security = _securityService.JwtSecurity(jwtSecurityKey);

        return userSecurityDto;
    }
}
