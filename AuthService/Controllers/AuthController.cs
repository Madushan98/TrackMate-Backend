using AuthService.Contract;
using AuthService.Services;
using AutoMapper;
using DTOLibrary.Exceptions;
using DTOLibrary.UserDto;
using DTOLibrary.UserDto.Login;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers;

public class AuthController : Controller
{
    private readonly IMapper _mapper;
    private readonly IAuthService _service;

    public AuthController(IAuthService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }


    [HttpPost(ApiRoutes.Auth.RegisterUser)]
    [ProducesResponseType(typeof(UserResponse), 200)]
    [ProducesResponseType(typeof(Error), 400)]
    public async Task<IActionResult> RegisterAsync([FromBody] CreateUserRequest createUserRequest)
    {
        var response = await _service.RegisterUserAsync(createUserRequest);

        return Ok(response);
    }


    [HttpPost(ApiRoutes.Auth.LoginUser)]
    [ProducesResponseType(typeof(UserResponse), 200)]
    [ProducesResponseType(typeof(Error), 400)]
    public async Task<IActionResult> RegisterAsync([FromBody] LoginRequest loginRequest)
    {
        var response = await _service.LoginUserAsync(loginRequest);

        return Ok(response);
    }
}