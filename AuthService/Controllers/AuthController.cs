using System.Net;
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
        LoginResponse response = null;

        try
        {
            response = await _service.RegisterUserAsync(createUserRequest);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }


        return Ok(response);
    }


    [HttpPost(ApiRoutes.Auth.LoginUser)]
    [ProducesResponseType(typeof(UserResponse), 200)]
    [ProducesResponseType(typeof(Error), 400)]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginRequest)
    {
        LoginResponse response = null;

        try
        {
            response = await _service.LoginUserAsync(loginRequest);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }


        return Ok(response);
    }
}